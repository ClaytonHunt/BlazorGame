window.BlazorGame = window.BlazorGame || {};
(function (ns) {
    var context = null;
    var program = null;
    var positionLocation = null;
    var positionBuffer = null;
    var texcoordLocation = null;
    var texcoordBuffer = null;
    var matrixLocation = null;
    var textureLocation = null;
    var textureMatrixLocation = null;
    var dotnetGraphics = null;
    var rootDirectory = "";
    var contents = [];
    var previousTimestamp = 0;
    var buffer = { x: 0, y: 0 };
    var keys = new Set();

    window.addEventListener("keydown",
        function (e) {
            keys.add(e.keyCode);
        },
        false);

    window.addEventListener('keyup',
        function (e) {
            keys.delete(e.keyCode);
        },
        false);


    ns.initialize = (dotnetHelper, canvasId) => {
        var canvas = document.getElementById(canvasId);

        buffer.x = canvas.width;
        buffer.y = canvas.height;
        context = canvas.getContext("webgl");
        dotnetGraphics = dotnetHelper;

        var vertexShader = createShader(context, context.VERTEX_SHADER, ns.vertexShader2D);
        var fragmentShader = createShader(context, context.FRAGMENT_SHADER, ns.fragmentShader2D);

        program = createProgram(context, vertexShader, fragmentShader);

        positionLocation = context.getAttribLocation(program, "a_position");
        texcoordLocation = context.getAttribLocation(program, "a_texcoord");
        matrixLocation = context.getUniformLocation(program, "u_matrix");
        textureLocation = context.getUniformLocation(program, "u_texture");
        textureMatrixLocation = context.getUniformLocation(program, "u_textureMatrix");

        positionBuffer = context.createBuffer();
        context.bindBuffer(context.ARRAY_BUFFER, positionBuffer);

        var positions = [
            0, 0,
            0, 1,
            1, 0,
            1, 0,
            0, 1,
            1, 1
        ];

        context.bufferData(context.ARRAY_BUFFER, new Float32Array(positions), context.STATIC_DRAW);

        texcoordBuffer = context.createBuffer();
        context.bindBuffer(context.ARRAY_BUFFER, texcoordBuffer);

        // Put texcoords in the buffer
        var texcoords = [
            0, 0,
            0, 1,
            1, 0,
            1, 0,
            0, 1,
            1, 1,
        ];
        context.bufferData(context.ARRAY_BUFFER, new Float32Array(texcoords), context.STATIC_DRAW);

        window.requestAnimationFrame(ns.render);
    };

    ns.render = (timestamp) => {
        const currentTimeStamp = timestamp - previousTimestamp;
        previousTimestamp = timestamp;

        dotnetGraphics.invokeMethodAsync('Render', currentTimeStamp)
            .then(_ => window.requestAnimationFrame(ns.render));
    };

    ns.clear = (color) => {
        context.viewport(0, 0, context.canvas.width, context.canvas.height);

        context.clearColor(color.r / 255, color.g / 255, color.b / 255, color.a / 255);

        context.clear(context.COLOR_BUFFER_BIT);
    };

    ns.loadContent = (name) => {
        const result = new Promise((resolve, fail) => {
            let content = contents.filter(x => x.name === name)[0];

            console.log("Asset:", name, content);

            if (content == null) {
                fail(`${name} not found.`);
                return;
            }            

            var ext = content.path.substring(content.path.length - 3, content.path.length);

            if (ext === "wav" || ext === "mp3") {                
                const sound = new Audio();
                sound.src = `${rootDirectory}/${content.path}`;
                sound.oncanplay = () => {
                    content.isReady = true;

                    resolve(content);
                };

                content.content = sound;
            } else {
                const texture = context.createTexture();
                context.bindTexture(context.TEXTURE_2D, texture);

                context.texImage2D(context.TEXTURE_2D, 0, context.RGBA, 1, 1, 0, context.RGBA, context.UNSIGNED_BYTE, new Uint8Array([0, 0, 255, 255]));

                context.texParameteri(context.TEXTURE_2D, context.TEXTURE_WRAP_S, context.CLAMP_TO_EDGE);
                context.texParameteri(context.TEXTURE_2D, context.TEXTURE_WRAP_T, context.CLAMP_TO_EDGE);
                context.texParameteri(context.TEXTURE_2D, context.TEXTURE_MIN_FILTER, context.LINEAR);

                content.width = 1;
                content.height = 1;
                content.texture = texture;
                    
                const image = new Image();
                image.onload = () => {
                    content.isReady = true;
                    content.width = image.width;
                    content.height = image.height;

                    context.bindTexture(context.TEXTURE_2D, content.texture);
                    context.texImage2D(context.TEXTURE_2D, 0, context.RGBA, context.RGBA, context.UNSIGNED_BYTE, image);

                    resolve(content);
                };
                image.src = `${rootDirectory}/${content.path}`;
            }
        });


        return result;
    };

    ns.playAudio = (name, isRepeating) => {
        let sound = contents.filter(x => x.name == name)[0];

        sound.content.loop = isRepeating;
        sound.content.play();
    };

    ns.registerContent = (name, filename) => {
        var content = {
            isReady: false,
            name: name,
            path: filename
        };

        content.position = contents.length;

        contents.push(content);
    };

    ns.drawImage = (texture, textureWidth, textureHeight, sourceX, sourceY, sourceWidth, sourceHeight, destinationX, destinationY, destinationWidth, destinationHeight) => {
        if (destinationX === undefined) {
            destinationX = sourceX;
            sourceX = 0;
        }

        if (destinationY === undefined) {
            destinationY = sourceY;
            sourceY = 0;
        }

        if (sourceWidth === undefined) {
            sourceWidth = textureWidth;
        }

        if (sourceHeight === undefined) {
            sourceHeight = textureHeight;
        }

        if (destinationWidth === undefined) {
            destinationWidth = sourceWidth;
            sourceWidth = textureWidth;
        }

        if (destinationHeight === undefined) {
            destinationHeight = sourceHeight;
            sourceHeight = textureHeight;
        }

        context.bindTexture(context.TEXTURE_2D, texture);

        // Tell WebGL to use our shader program pair
        context.useProgram(program);
 
        // Setup the attributes to pull data from our buffers
        context.bindBuffer(context.ARRAY_BUFFER, positionBuffer);
        context.enableVertexAttribArray(positionLocation);
        context.vertexAttribPointer(positionLocation, 2, context.FLOAT, false, 0, 0);
        context.bindBuffer(context.ARRAY_BUFFER, texcoordBuffer);
        context.enableVertexAttribArray(texcoordLocation);
        context.vertexAttribPointer(texcoordLocation, 2, context.FLOAT, false, 0, 0);
 
        // this matrix will convert from pixels to clip space
        var matrix = m4.orthographic(0, context.canvas.width, context.canvas.height, 0, -1, 1);
 
        // this matrix will translate our quad to dstX, dstY
        matrix = m4.translate(matrix, destinationX, destinationY, 0);
 
        // this matrix will scale our 1 unit quad
        // from 1 unit to texWidth, texHeight units
        matrix = m4.scale(matrix, destinationWidth, destinationHeight, 1);
 
        // Set the matrix.
        context.uniformMatrix4fv(matrixLocation, false, matrix);

        // Because texture coordinates go from 0 to 1
        // and because our texture coordinates are already a unit quad
        // we can select an area of the texture by scaling the unit quad
        // down
        var texMatrix = m4.translation(sourceX / textureWidth, sourceY / textureHeight, 0);
        texMatrix = m4.scale(texMatrix, sourceWidth / textureWidth, sourceHeight / textureHeight, 1);
 
        // Set the texture matrix.
        context.uniformMatrix4fv(textureMatrixLocation, false, texMatrix);
 
        // Tell the shader to get the texture from texture unit 0
        context.uniform1i(textureLocation, 0);
 
        // draw the quad (2 triangles, 6 vertices)
        context.drawArrays(context.TRIANGLES, 0, 6);
    }

    ns.drawTexture = (name, x, y, color) => {
        const content = contents.filter(x => x.name === name)[0];

        ns.drawImage(content.texture, content.width, content.height, x, y);
    };

    ns.drawSprite = (name, x, y, top, left, bottom, right, flipH, flipV, color) => {
        let content = contents.filter(x => x.name === name)[0];
        
        const spriteWidth = right - left;
        const spriteHeight = bottom - top;
        
        ns.drawImage(content.texture, left, top, spriteWidth, spriteHeight, flipH ? -x : x, y, flipH ? -spriteWidth : spriteWidth, spriteHeight);
    };

    ns.setRootDirectory = (path) => {        
        rootDirectory = path;
    };

    ns.getKeyState = () => {
        const result = new Promise((resolve, fail) => {
            resolve({ keys: [...keys] });
        });

        return result;
    }

    ns.vertexShader2D = (() => {
        var script = document.createElement("script");
        script.type = "x-shader/x-vertex";
        script.innerText = "attribute vec4 a_position;" +
            "attribute vec2 a_texcoord;" +
            "uniform mat4 u_matrix;" +
            "uniform mat4 u_textureMatrix;" +
            "varying vec2 v_texcoord;" +
            "void main() {" +
            "gl_Position = u_matrix * a_position;" +
            "v_texcoord = (u_textureMatrix * vec4(a_texcoord, 0, 1)).xy;" +
            "}";

        return script;
    })();

    ns.fragmentShader2D = (() => {
        var script = document.createElement("script");
        script.type = "x-shader/x-fragment";
        script.innerText = "precision mediump float;" +
            "varying vec2 v_texcoord;" +
            "uniform sampler2D u_texture;" +
            "void main() {" +
            "gl_FragColor = texture2D(u_texture, v_texcoord);" +
            "}";

        return script;
    })();

    function createShader(gl, type, source) {
        const shader = gl.createShader(type);
        gl.shaderSource(shader, source.text);
        gl.compileShader(shader);
        const success = gl.getShaderParameter(shader, gl.COMPILE_STATUS);

        if (success) {
            return shader;
        }

        console.log(source);
        console.log(gl.getShaderInfoLog(shader));
        gl.deleteShader(shader);
    }

    function createProgram(gl, vertexShader, fragmentShader) {
        const program = gl.createProgram();
        gl.attachShader(program, vertexShader);
        gl.attachShader(program, fragmentShader);
        gl.linkProgram(program);
        const success = gl.getProgramParameter(program, gl.LINK_STATUS);

        if (success) {
            return program;
        }
 
        console.log(gl.getProgramInfoLog(program));
        gl.deleteProgram(program);
    }
})(window.BlazorGame);