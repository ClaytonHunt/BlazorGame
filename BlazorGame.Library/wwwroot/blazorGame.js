class Game {
    game = null;
    gl = null;
    gameTime = 0;
    boundRender = null;
    buffers = null;
    textures = new Map();

    vertexShader2D = `
        attribute vec4 aVertexPosition;
        attribute vec4 aVertexColor;
        attribute vec2 aTextureCoord;

        uniform mat4 uModelViewMatrix;
        uniform mat4 uProjectionMatrix;

        varying lowp vec4 vColor;
        varying highp vec2 vTextureCoord;

        void main(void) {
            gl_Position = uProjectionMatrix * uModelViewMatrix * aVertexPosition;
            vColor = aVertexColor;
            vTextureCoord = aTextureCoord;
        }
    `;

    fragmentShader2D = `
        precision highp float;

        varying lowp vec4 vColor;
        varying highp vec2 vTextureCoord;

        uniform sampler2D uSampler;
    
        void main(void) {
            vec4 color = texture2D(uSampler, vTextureCoord);
            color.rgba *= vColor;

            gl_FragColor = color;
        }
    `;

    registerGame(game) {
        this.game = game;
    }

    initialize(canvasId) {
        const canvas = document.getElementById(canvasId);

        this.gl = canvas.getContext("webgl2");

        this.gl.enable(this.gl.BLEND);
        this.gl.blendFunc(this.gl.SRC_ALPHA, this.gl.ONE_MINUS_SRC_ALPHA);

        if (this.gl === null) {
            return {
                isSuccess: false,
                errorMessage: "Unable to initialize WebGL. Your browser or machine may not support it."
            };
        }

        // TODO: figure out where to do this
        ////////
        try {
            this.programInfo = this.createShader();
            this.buffers = this.initBuffers();
            this.loadDefaultTexture();
        } catch (ex) {
            return ex;
        }
        ///////

        this.boundRender = this.render.bind(this);

        window.requestAnimationFrame(this.boundRender);

        return { isSuccess: true };
    }

    render(timestamp) {
        const currentTimeStamp = timestamp - this.gameTime;
        this.gameTime = timestamp;

        this.game.invokeMethod('Loop', currentTimeStamp);

        window.requestAnimationFrame(this.boundRender);
    }

    readColor(colorAddress, offset) {
        const color = Blazor.platform.readStructField(colorAddress, offset);
        const red = Blazor.platform.readFloatField(color, 0);
        const green = Blazor.platform.readFloatField(color, 4);
        const blue = Blazor.platform.readFloatField(color, 8);
        const alpha = Blazor.platform.readFloatField(color, 12);

        return {
            red: red,
            green: green,
            blue: blue,
            alpha: alpha
        };
    }

    clear(colorAddress) {
        const color = this.readColor(colorAddress, 0);

        this.gl.clearColor(color.red, color.green, color.blue, color.alpha);
        
        ////////
        this.gl.clearDepth(1.0);
        this.gl.enable(this.gl.DEPTH_TEST);
        this.gl.depthFunc(this.gl.LEQUAL);
        ///////

        this.gl.clear(this.gl.COLOR_BUFFER_BIT | this.gl.DEPTH_BUFFER_BIT);
    }

    drawRectangle(baseAddress) {
        const rect = Blazor.platform.readStructField(baseAddress, 0);
        const top = Blazor.platform.readFloatField(rect, 0);
        const left = Blazor.platform.readFloatField(rect, 4);
        const bottom = Blazor.platform.readFloatField(rect, 8);
        const right = Blazor.platform.readFloatField(rect, 12);
        const colorRect = Blazor.platform.readStructField(baseAddress, 16);
        const colorTopLeft = this.readColor(colorRect, 0);
        const colorTopRight = this.readColor(colorRect, 16);
        const colorBottomLeft = this.readColor(colorRect, 32);
        const colorBottomRight = this.readColor(colorRect, 48);
        const textureName = Blazor.platform.readStringField(baseAddress, 80);
        const rotation = Blazor.platform.readFloatField(baseAddress, 84);

        // Now create an array of positions for the square
        const positions = [
            right, bottom,
            left, bottom,
            right, top,
            left, top
        ];

        // Now pass the list of positions into WebGL to build the
        // shape. We do this by creating a Float32Array from the
        // JavaScript array, then use it to fill the current buffer.
        this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffers.position);
        this.gl.bufferData(this.gl.ARRAY_BUFFER,
            new Float32Array(positions),
            this.gl.STATIC_DRAW);

        const colors = [
            colorTopRight.red, colorTopRight.green, colorTopRight.blue, colorTopRight.alpha,
            colorTopLeft.red, colorTopLeft.green, colorTopLeft.blue, colorTopLeft.alpha,
            colorBottomRight.red, colorBottomRight.green, colorBottomRight.blue, colorBottomRight.alpha,
            colorBottomLeft.red, colorBottomLeft.green, colorBottomLeft.blue, colorBottomLeft.alpha
        ];

        this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffers.color);
        this.gl.bufferData(this.gl.ARRAY_BUFFER, new Float32Array(colors), this.gl.STATIC_DRAW);

        const textureCoordBuffer = this.gl.createBuffer();
        this.gl.bindBuffer(this.gl.ARRAY_BUFFER, textureCoordBuffer);

        const textureCoordinates = [
            // Front
            1.0, 0.0,
            0.0, 0.0,
            1.0, 1.0,
            0.0, 1.0
        ];

        this.gl.bufferData(this.gl.ARRAY_BUFFER, new Float32Array(textureCoordinates), this.gl.STATIC_DRAW);

        const fieldOfView = 45 * Math.PI / 180; // in radians
        const aspect = this.gl.canvas.clientWidth / this.gl.canvas.clientHeight;
        const zNear = .01;
        const zFar = 100.0;
        const projectionMatrix = mat4.create();

        // note: glmatrix.js always has the first argument
        // as the destination to receive the result.
        mat4.perspective(projectionMatrix,
            fieldOfView,
            aspect,
            zNear,
            zFar);

        // Set the drawing postion to the "identity" point, which is
        // the center of the scene
        const modelViewMatrix = mat4.create();

        // Now move the drawing postion a bit to where we want to
        // start drawing the square.
        mat4.translate(modelViewMatrix, // destination matrix
            modelViewMatrix, // matrix to translate
            [-0.0, 0.0, -6.0]); // amount to translate

        mat4.rotate(modelViewMatrix, // destination matrix
            modelViewMatrix,        // matrix to rotate
            rotation,               // amount to rotate in radians
            [0, 0, 1]);             // axis to rotate around

        // Tell WebGL how to pull out hte positions from the position
        // buffer into the vertexPosition attribute.
        {
            const numComponents = 2;    // pull out he 2 values per iteration
            const type = this.gl.FLOAT; // the data in the buffer is 32bit floats
            const normalize = false;    // don't normalize
            const stride = 0;           // how many bytes to get from one set of values to the next
                                        // 0 = use type and numComponents above
            const offset = 0;           // how many bytes inside the buffer to start from
            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffers.position);
            this.gl.vertexAttribPointer(
                this.programInfo.attribLocations.vertexPosition,
                numComponents,
                type,
                normalize,
                stride,
                offset);
            this.gl.enableVertexAttribArray(
                this.programInfo.attribLocations.vertexPosition);
        }

        // Tell WebGL how to pull out the colors from the color buffer
        // into the vertexColor attribute.
        {
            const numComponents = 4;
            const type = this.gl.FLOAT;
            const normalize = false;
            const stride = 0;
            const offset = 0;

            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffers.color);
            this.gl.vertexAttribPointer(
                this.programInfo.attribLocations.vertexColor,
                numComponents,
                type,
                normalize,
                stride,
                offset);
            this.gl.enableVertexAttribArray(this.programInfo.attribLocations.vertexColor);
        }

        // Tell WebGL how to pull out the colors from the color buffer
        // into the vertexColor attribute.
        {
            const num = 2; // every coordinate composed of 2 values
            const type = this.gl.FLOAT; // the data in the buffer is 32 bit float
            const normalize = false; // don't normalize
            const stride = 0; // how many bytes to get from one set to the next
            const offset = 0; // how many bytes inside the buffer to start from

            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, textureCoordBuffer);
            this.gl.vertexAttribPointer(this.programInfo.attribLocations.textureCoord, num, type, normalize, stride, offset);
            this.gl.enableVertexAttribArray(this.programInfo.attribLocations.textureCoord);
        }

        this.gl.useProgram(this.programInfo.program);

        // Set the shader uniforms

        this.gl.uniformMatrix4fv(
            this.programInfo.uniformLocations.projectionMatrix,
            false,
            projectionMatrix);
        this.gl.uniformMatrix4fv(
            this.programInfo.uniformLocations.modelViewMatrix,
            false,
            modelViewMatrix);

        // Tell WebGL we want to affect texture unit 0
        this.gl.activeTexture(this.gl.TEXTURE0);

        // bind this texture to texture unit 0
        this.gl.bindTexture(this.gl.TEXTURE_2D, this.textures.get(textureName));

        // Tell the shader we bound the texture to texture unit 0
        this.gl.uniform1i(this.programInfo.uniformLocations.uSampler, 0);

        {
            const offset = 0;
            const vertexCount = 4;
            this.gl.drawArrays(this.gl.TRIANGLE_STRIP, offset, vertexCount);
        }
    }

    error(message) {
        return {
            isSuccess: false,
            errorMessage: message
        };
    }

    drawTexturedRectangle(baseAddress) {
        const rect = Blazor.platform.readStructField(baseAddress, 0);
        const top = Blazor.platform.readFloatField(rect, 0);
        const left = Blazor.platform.readFloatField(rect, 4);
        const bottom = Blazor.platform.readFloatField(rect, 8);
        const right = Blazor.platform.readFloatField(rect, 12);
        const textureName = Blazor.platform.readStringField(baseAddress, 16);
        const rotation = Blazor.platform.readFloatField(baseAddress, 24);

        // Now create an array of positions for the square
        const positions = [
            right, bottom,
            left, bottom,
            right, top,
            left, top
        ];

        // Now pass the list of positions into WebGL to build the
        // shape. We do this by creating a Float32Array from the
        // JavaScript array, then use it to fill the current buffer.
        this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffers.position);
        this.gl.bufferData(this.gl.ARRAY_BUFFER,
            new Float32Array(positions),
            this.gl.STATIC_DRAW);

        const textureCoordBuffer = this.gl.createBuffer();
        this.gl.bindBuffer(this.gl.ARRAY_BUFFER, textureCoordBuffer);

        const textureCoordinates = [
            // Front
            1.0, 0.0,
            0.0, 0.0,
            1.0, 1.0,
            0.0, 1.0
        ];

        this.gl.bufferData(this.gl.ARRAY_BUFFER, new Float32Array(textureCoordinates), this.gl.STATIC_DRAW);

        const fieldOfView = 45 * Math.PI / 180; // in radians
        const aspect = this.gl.canvas.clientWidth / this.gl.canvas.clientHeight;
        const zNear = .01;
        const zFar = 100.0;
        const projectionMatrix = mat4.create();

        // note: glmatrix.js always has the first argument
        // as the destination to receive the result.
        mat4.perspective(projectionMatrix,
            fieldOfView,
            aspect,
            zNear,
            zFar);

        // Set the drawing postion to the "identity" point, which is
        // the center of the scene
        const modelViewMatrix = mat4.create();

        // Now move the drawing postion a bit to where we want to
        // start drawing the square.
        mat4.translate(modelViewMatrix, // destination matrix
            modelViewMatrix, // matrix to translate
            [-0.0, 0.0, -6.0]); // amount to translate

        mat4.rotate(modelViewMatrix, // destination matrix
            modelViewMatrix,        // matrix to rotate
            rotation,               // amount to rotate in radians
            [0, 0, 1]);             // axis to rotate around

        // Tell WebGL how to pull out hte positions from the position
        // buffer into the vertexPosition attribute.
        {
            const numComponents = 2;    // pull out he 2 values per iteration
            const type = this.gl.FLOAT; // the data in the buffer is 32bit floats
            const normalize = false;    // don't normalize
            const stride = 0;           // how many bytes to get from one set of values to the next
                                        // 0 = use type and numComponents above
            const offset = 0;           // how many bytes inside the buffer to start from
            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffers.position);
            this.gl.vertexAttribPointer(
                this.programInfo.attribLocations.vertexPosition,
                numComponents,
                type,
                normalize,
                stride,
                offset);
            this.gl.enableVertexAttribArray(
                this.programInfo.attribLocations.vertexPosition);
        }

        // Tell WebGL how to pull out the colors from the color buffer
        // into the vertexColor attribute.
        {
            const num = 2; // every coordinate composed of 2 values
            const type = this.gl.FLOAT; // the data in the buffer is 32 bit float
            const normalize = false; // don't normalize
            const stride = 0; // how many bytes to get from one set to the next
            const offset = 0; // how many bytes inside the buffer to start from

            this.gl.bindBuffer(this.gl.ARRAY_BUFFER, textureCoordBuffer);
            this.gl.vertexAttribPointer(this.programInfo.attribLocations.textureCoord, num, type, normalize, stride, offset);
            this.gl.enableVertexAttribArray(this.programInfo.attribLocations.textureCoord);
        }

        this.gl.useProgram(this.programInfo.program);

        // Set the shader uniforms

        this.gl.uniformMatrix4fv(
            this.programInfo.uniformLocations.projectionMatrix,
            false,
            projectionMatrix);
        this.gl.uniformMatrix4fv(
            this.programInfo.uniformLocations.modelViewMatrix,
            false,
            modelViewMatrix);

        // Tell WebGL we want to affect texture unit 0
        this.gl.activeTexture(this.gl.TEXTURE0);

        // bind this texture to texture unit 0
        this.gl.bindTexture(this.gl.TEXTURE_2D, this.textures.get(textureName));

        // Tell the shader we bound the texture to texture unit 0
        this.gl.uniform1i(this.programInfo.uniformLocations.uSampler, 0);

        {
            const offset = 0;
            const vertexCount = 4;
            this.gl.drawArrays(this.gl.TRIANGLE_STRIP, offset, vertexCount);
        }
    }

    error(message) {
        return {
            isSuccess: false,
            errorMessage: message
        };
    }

    loadDefaultTexture() {
        const texture = this.gl.createTexture();
        this.gl.bindTexture(this.gl.TEXTURE_2D, texture);

        // Because images have to be downloaded over the internet
        // they might take a moment until they are ready.
        // Until then put a single pixel in the texture so we can
        // use it immediately. When the image has finished downloading
        // we'll update the texture with the contents of the image.
        const level = 0;
        const internalFormat = this.gl.RGBA;
        const width = 1;
        const height = 1;
        const border = 0;
        const srcFormat = this.gl.RGBA;
        const srcType = this.gl.UNSIGNED_BYTE;
        const pixel = new Uint8Array([255, 255, 255, 255]); // blank white

        this.gl.texImage2D(this.gl.TEXTURE_2D,
            level,
            internalFormat,
            width,
            height,
            border,
            srcFormat,
            srcType,
            pixel);

        this.textures.set("default", texture);
    }

    loadTexture(url, name) {
        const texture = this.gl.createTexture();
        this.gl.bindTexture(this.gl.TEXTURE_2D, texture);

        // Because images have to be downloaded over the internet
        // they might take a moment until they are ready.
        // Until then put a single pixel in the texture so we can
        // use it immediately. When the image has finished downloading
        // we'll update the texture with the contents of the image.
        const level = 0;
        const internalFormat = this.gl.RGBA;
        const width = 1;
        const height = 1;
        const border = 0;
        const srcFormat = this.gl.RGBA;
        const srcType = this.gl.UNSIGNED_BYTE;
        const pixel = new Uint8Array([255, 255, 255, 255]); // blank white

        this.gl.texImage2D(this.gl.TEXTURE_2D,
            level,
            internalFormat,
            width,
            height,
            border,
            srcFormat,
            srcType,
            pixel);

        const image = new Image();
        image.onload = () => {
            this.gl.bindTexture(this.gl.TEXTURE_2D, texture);
            this.gl.texImage2D(this.gl.TEXTURE_2D,
                level,
                internalFormat,
                srcFormat,
                srcType,
                image);

            // WebGL1 has different requirements for power of 2 images
            // vs non power of 2 images so check if the image is a
            // power of 2 in both dimensions.
            if (this.isPowerOf2(image.width) && this.isPowerOf2(image.height)) {
                // Yes, it's a power of 2. Generate mips.
                this.gl.generateMipmap(this.gl.TEXTURE_2D);
            } else {
                // No, it's not a power of 2. Turn off mips and set
                // wrapping to clamp to edge
                this.gl.texParameteri(this.gl.TEXTURE_2D, this.gl.TEXTURE_WRAP_S, this.gl.CLAMP_TO_EDGE);
                this.gl.texParameteri(this.gl.TEXTURE_2D, this.gl.TEXTURE_WRAP_T, this.gl.CLAMP_TO_EDGE);
                this.gl.texParameteri(this.gl.TEXTURE_2D, this.gl.TEXTURE_MIN_FILTER, this.gl.LINEAR);
            }
        };

        image.src = url;

        this.textures.set(name, texture);

        //return {
        //    name: name,
        //    width: image.width,
        //    height: image.height
        //};
    }

    loadShader(type, source) {
        const shader = this.gl.createShader(type);

        //// Send the source to the shader object
        this.gl.shaderSource(shader, source);

        //// Compile the shader program

        this.gl.compileShader(shader);

        // See if it compiled successfully

        if (!this.gl.getShaderParameter(shader, this.gl.COMPILE_STATUS)) {
            throw this.error(`An error occurred compileing the shaders: ${this.gl.getShaderInfoLog(shader)}`);
        }

        return shader;
    }

    initShaderProgram(vertexSource, fragmentSource) {
        const vertexShader = this.loadShader(this.gl.VERTEX_SHADER, vertexSource);
        const fragmentShader = this.loadShader(this.gl.FRAGMENT_SHADER, fragmentSource);

        // Create the shader program
        const shaderProgram = this.gl.createProgram();
        this.gl.attachShader(shaderProgram, vertexShader);
        this.gl.attachShader(shaderProgram, fragmentShader);
        this.gl.linkProgram(shaderProgram);

        // If creating th shader program failed, alert

        if (!this.gl.getProgramParameter(shaderProgram, this.gl.LINK_STATUS)) {
            throw this.error(`Unable to initailize the shader program: ${this.gl.getProgramInfoLog(shaderProgram)}`);
        }

        return shaderProgram;
    }

    createShader() {
        const shaderProgram = this.initShaderProgram(this.vertexShader2D, this.fragmentShader2D);

        return {
            program: shaderProgram,
            attribLocations: {
                vertexPosition: this.gl.getAttribLocation(shaderProgram, 'aVertexPosition'),
                vertexColor: this.gl.getAttribLocation(shaderProgram, 'aVertexColor'),
                textureCoord: this.gl.getAttribLocation(shaderProgram, 'aTextureCoord')
            },
            uniformLocations: {
                projectionMatrix: this.gl.getUniformLocation(shaderProgram, 'uProjectionMatrix'),
                modelViewMatrix: this.gl.getUniformLocation(shaderProgram, 'uModelViewMatrix'),
                uSampler: this.gl.getUniformLocation(shaderProgram, 'uSampler')
    }
        };
    }

    initBuffers() {
        // Create a buffer for th square's positions.
        const positionBuffer = this.gl.createBuffer();
        const colorBuffer = this.gl.createBuffer();

        return {
            position: positionBuffer,
            color: colorBuffer
        };
    }  

    isPowerOf2(value) {
        return (value & (value - 1)) === 0;
    }
}

window.BlazorGame = {
    create: () => new Game()
};

////window.BlazorGame = window.BlazorGame || {};
////(function (ns) {
////    var dotnetGraphics = null;
////    var previousTimestamp = 0;
////    var keys = new Set();

////    window.addEventListener("keydown",
////        function (e) {
////            keys.add(e.keyCode);
////        },
////        false);

////    window.addEventListener('keyup',
////        function (e) {
////            keys.delete(e.keyCode);
////        },
////        false);


////    ns.initialize = (dotnetHelper, drawId) => {
////        dotnetGraphics = dotnetHelper;

////        canvasId = drawId;

////        window.requestAnimationFrame(ns.render);
////    };

////    ns.render = (timestamp) => {
////        const currentTimeStamp = timestamp - previousTimestamp;
////        previousTimestamp = timestamp;

////        dotnetGraphics.invokeMethodAsync('Render', currentTimeStamp)
////            .then(_ => window.requestAnimationFrame(ns.render));
////    };

////    ns.getKeyState = () => {
////        const result = new Promise((resolve, fail) => {
////            resolve({ keys: [...keys] });
////        });

////        return result;
////    }
////})(window.BlazorGame);

////class Game {
////    dotnetGraphics = null;
////    canvasId = null

////    constructor(dotnetHelper, canvas) {
////        dotnetGraphics = dotnetHelper;
////        canvasId = canvas;


////    }
////}