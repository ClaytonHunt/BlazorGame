class Game {
    game = null;
    gl = null;
    gameTime = 0;
    boundRender = null;

    vertexShader2D = `
        attribute vec4 aVertexPosition;

        uniform mat4 uModelViewMatrix;
        uniform mat4 uProjectionMatrix;

        void main() {
            gl_Position = uProjectionMatrix * uModelViewMatrix * aVertexPosition;
        }
    `;

    fragmentShader2D = `
        void main() {
            gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0);
        }
    `;

    registerGame(game) {
        this.game = game;
    }

    initialize(canvasId) {
        const canvas = document.getElementById(canvasId);

        this.gl = canvas.getContext("webgl2");

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

    clear(colorAddress) {
        const color = Blazor.platform.readStructField(colorAddress, 0);
        const red = Blazor.platform.readFloatField(color, 0);
        const green = Blazor.platform.readFloatField(color, 4);
        const blue = Blazor.platform.readFloatField(color, 8);
        const alpha = Blazor.platform.readFloatField(color, 12);

        this.gl.clearColor(red, green, blue, alpha);
        
        ////////
        this.gl.clearDepth(1.0);
        this.gl.enable(this.gl.DEPTH_TEST);
        this.gl.depthFunc(this.gl.LEQUAL);
        ///////

        this.gl.clear(this.gl.COLOR_BUFFER_BIT | this.gl.DEPTH_BUFFER_BIT);
    }

    loadShader(type, source) {
        const shader = this.gl.createShader(type);

        //// Send the source to the shader object
        this.gl.shaderSource(shader, source);

        //// Compile the shader program

        this.gl.compileShader(shader);

        // See if it compiled successfully

        if (!this.gl.getShaderParameter(shader, this.gl.COMPILE_STATUS)) {
            throw {
                isSuccess: false,
                errorMessage: `An error occurred compileing the shaders: ${this.gl.getShaderInfoLog(shader)}`
            };
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
            throw {
                isSuccess: false,
                errorMessage: `Unable to initailize the shader program: ${this.gl.getProgramInfoLog(shaderProgram)}`
            };
        }

        return shaderProgram;
    }

    createShader() {
        const shaderProgram = this.initShaderProgram(this.vertexShader2D, this.fragmentShader2D);

        return {
            program: shaderProgram,
            attribLocations: {
                vertexPosition: this.gl.getAttribLocation(shaderProgram, 'aVertexPosition')
            },
            uniformLocations: {
                projectionMatrix: this.gl.getUniformLocation(shaderProgram, 'uProjectionMatrix'),
                modelViewMatrix: this.gl.getUniformLocation(shaderProgram, 'uModelViewMatrix')
            }
        };
    }

    initBuffers() {
        // Create a buffer for th square's positions.
        const positionBuffer = this.gl.createBuffer();

        // Select het positionBuffer as the one to apply buffer
        // operations to from here out.

        this.gl.bindBuffer(this.gl.ARRAY_BUFFER, positionBuffer);

        // Now create an array of positions for the square

        const positions = [
            -1.0, 1.0,
            1.0, 1.0,
            -1.0, -1.0,
            1.0, -1.0
        ];

        // Now pass the list of positions into WebGL to build the
        // shape. We do this by creating a Float32Array from the
        // JavaScript array, then use it to fill the current buffer.

        this.gl.bufferData(this.gl.ARRAY_BUFFER,
            new Float32Array(positions),
            this.gl.STATIC_DRAW);

        return {
            position: positionBuffer
        };
    }

    drawScene() {
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

        {
            const offset = 0;
            const vertexCount = 4;
            this.gl.drawArrays(this.gl.TRIANGLE_STRIP, offset, vertexCount);
        }
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