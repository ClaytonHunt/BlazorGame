window.BlazorGame = window.BlazorGame || {};
(function (ns) {
    var renderTargets = [];
    var canvasId = "default";
    var context = null;
    var program = null;
    var dotnetGraphics = null;
    var rootDirectory = "";
    var contents = [];
    var previousTimestamp = 0;
    var keys = new Set();
    var positionAttributeLocation = null;
    var colorLocation = null;
    var positionBuffer = null;
    var vao = null;

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


    ns.initialize = (dotnetHelper, drawId, presentationParameters) => {
        dotnetGraphics = dotnetHelper;

        canvasId = drawId;

        var renderTarget = {
            id: canvasId,
            width: presentationParameters.backBufferWidth,
            height: presentationParameters.backBufferHeight
        };

        ns.setRenderTarget(renderTarget);

        window.requestAnimationFrame(ns.render);
    };

    ns.createRenderTarget2D = (renderTarget) => {
        if (renderTarget == null) {
            renderTarget = { id: canvasId };
        }

        var canvas = document.getElementById(renderTarget.id);

        if (!canvas) {
            canvas = document.createElement("canvas");
            canvas.id = renderTarget.id;
        }

        canvas.height = renderTarget.height;
        canvas.width = renderTarget.width;

        var ctx = canvas.getContext("webgl2");

        var vertexShader = createShader(ctx, ctx.VERTEX_SHADER, ns.vertexShader2D);
        var fragmentShader = createShader(ctx, ctx.FRAGMENT_SHADER, ns.fragmentShader2D);

        program = createProgram(ctx, vertexShader, fragmentShader);

        ctx.viewport(0, 0, canvas.width, canvas.height);
        ctx.useProgram(program);

        var resolutionUniformLocation = ctx.getUniformLocation(program, "u_resolution");
        ctx.uniform2f(resolutionUniformLocation, canvas.width, canvas.height);

        renderTargets.push({ id: renderTarget.id, context: ctx, program: program });
    };

    ns.setRenderTarget = (renderTarget) => {
        if (renderTarget == null) {
            renderTarget = { id: canvasId };
        }

        var target = renderTargets.find(t => t.id === renderTarget.id);

        if (!target) {
            ns.createRenderTarget2D(renderTarget);

            target = renderTargets.find(t => t.id === renderTarget.id);
        }

        context = target.context;
        program = target.program;
    };

    ns.render = (timestamp) => {
        const currentTimeStamp = timestamp - previousTimestamp;
        previousTimestamp = timestamp;

        dotnetGraphics.invokeMethod('Render', currentTimeStamp);

        window.requestAnimationFrame(ns.render);
    };

    ns.present = (batch) => {
        positionAttributeLocation = context.getAttribLocation(program, "a_position");
        colorLocation = context.getUniformLocation(program, "u_color");
        positionBuffer = context.createBuffer();
        vao = context.createVertexArray();

        context.bindVertexArray(vao);
        context.enableVertexAttribArray(positionAttributeLocation);
        context.bindBuffer(context.ARRAY_BUFFER, positionBuffer);

        var size = 2;               // 2 components per iteration
        var type = context.FLOAT;   // the data is 32bit floats
        var normalize = false;      // don't normalize the data
        var stride = 0;             // 0 = move forward size * sizeof(type) each iteration to get the next position
        var offset = 0;             // start at the beginning of the buffer

        context.vertexAttribPointer(positionAttributeLocation, size, type, normalize, stride, offset);

        for (let i = 0; i < batch.length; i++) {
             ns[batch[i].key](...batch[i].value);
        }
    };

    ns.clear = (color) => {
        context.clearColor(color.r / 255, color.g / 255, color.b / 255, color.a / 255);
        context.clear(context.COLOR_BUFFER_BIT);
    };

    ns.drawUserPrimitives = (type, data, offset, count) => {
        context.bufferData(context.ARRAY_BUFFER,
            new Float32Array(data),
            context.STATIC_DRAW);

            // Set a random color.
            context.uniform4f(colorLocation, Math.random(), Math.random(), Math.random(), 1);

        // Draw the shape
        const primitiveType = type === 2 ? context.TRIANGLES : context.LINES;

        context.drawArrays(primitiveType, offset, count);
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
                importSound(content, resolve);
            } else if (ext === "spritefont" || ext === "xml") {
                fetch(`${rootDirectory}/${content.path}`).then(response => {
                    var result = {
                        characters: ["A", "B", "C", "D"],
                        lineSpacing: 18,
                        spacing: 5,
                        name: content.name,
                        path: content.path
                    };

                    resolve(result);
                }).catch(e => console.error(e));
            } else {
                importImage(content, resolve);
            }
        });


        return result;
    };

    ns.unloadContent = (name) => {
        let content = contents.filter(x => x.name === name)[0];

        delete content.texture;
        delete content.content;
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

    ns.setRootDirectory = (path) => {
        rootDirectory = path;
    };

    ns.getKeyState = () => {
        const result = new Promise((resolve, fail) => {
            resolve({ keys: [...keys] });
        });

        return result;
    }

    ns.vertexShader2D = `#version 300 es

in vec2 a_position;
uniform vec2 u_resolution;
 
void main() {
    // convert the position from pixels to 0.0 to 1.0
    vec2 zeroToOne = a_position / u_resolution;

    // convert from 0->1 to 0->2
    vec2 zeroToTwo = zeroToOne * 2.0;

    // convert from 0->2 to -1->+1 (clip space)
    vec2 clipSpace = zeroToTwo - 1.0;

    gl_Position = vec4(clipSpace * vec2(1, -1), 0, 1);
}`;

    ns.fragmentShader2D = `#version 300 es
 
precision highp float;
uniform vec4 u_color;

out vec4 outColor;
 
void main() {
  outColor = u_color;
}
`;

    function createShader(gl, type, source) {
        const shader = gl.createShader(type);
        gl.shaderSource(shader, source);
        gl.compileShader(shader);
        const success = gl.getShaderParameter(shader, gl.COMPILE_STATUS);

        if (success) {
            return shader;
        }

        console.log(gl.getShaderInfoLog(shader));
        gl.deleteShader(shader);

        return null;
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

        return null;
    }

    function importSound(content, cb) {
        const sound = new Audio();
        sound.src = `${rootDirectory}/${content.path}`;
        sound.oncanplay = () => {
            content.isReady = true;

            cb(content);
        };

        content.content = sound;
    }

    function importImage(content, cb) {
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

            cb(content);
        };
        image.src = `${rootDirectory}/${content.path}`;
    }

    function setRectangle(gl, x, y, width, height) {
        const x1 = x;
        const x2 = x + width;
        const y1 = y;
        const y2 = y + height;

        gl.bufferData(gl.ARRAY_BUFFER,
            new Float32Array([
                x1, y1,
                x2, y1,
                x1, y2,
                x1, y2,
                x2, y1,
                x2, y2
            ]),
            gl.STATIC_DRAW);
    }

    function randomInt(range) {
        return Math.floor(Math.random() * range);
    }
})(window.BlazorGame);