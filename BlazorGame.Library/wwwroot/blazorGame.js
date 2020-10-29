window.BlazorGame = window.BlazorGame || {};
(function (ns) {
    var context = null;
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
        context = canvas.getContext("2d");
        dotnetGraphics = dotnetHelper;

        window.requestAnimationFrame(ns.render);
    };

    ns.render = (timestamp) => {
        const currentTimeStamp = timestamp - previousTimestamp;
        previousTimestamp = timestamp;

        dotnetGraphics.invokeMethodAsync('Render', currentTimeStamp)
            .then(_ => window.requestAnimationFrame(ns.render));
    };

    ns.clear = (color) => {
        context.beginPath();
        context.rect(0, 0, context.canvas.width, context.canvas.height);
        context.fillStyle = `rgba(${color.r}, ${color.g}, ${color.b}, ${(color.a / 255)})`;
        context.fill();
        context.closePath();
    };

    ns.loadContent = (name) => {
        const result = new Promise((resolve, fail) => {
            let content = contents.filter(x => x.name == name)[0];

            console.log("Asset:", name, content);

            if (content == null) {
                fail(`${name} not found.`);
                return;
            }

            console.log(`Getting File: ${rootDirectory}/${content.path}`);            

            var ext = content.path.substring(content.path.length - 3, content.path.length);

            if (ext == "wav" || ext == "mp3") {                
                const sound = new Audio();
                sound.src = `${rootDirectory}/${content.path}`;
                sound.oncanplay = () => {
                    content.isReady = true;

                    resolve(content);
                };

                content.content = sound;
            } else {
                const image = new Image();
                image.src = `${rootDirectory}/${content.path}`;
                image.onload = () => {
                    content.isReady = true;
                    content.width = content.content.width;
                    content.height = content.content.height;

                    resolve(content);
                };

                content.content = image;
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

    ns.drawSprite = (name, x, y, color) => {
        let content = contents.filter(x => x.name == name)[0];

        context.drawImage(content.content, x, y);
    };

    ns.setRootDirectory = (path) => {
        console.log(`Setting Root Directory: ${path}`);
        rootDirectory = path;
    };

    ns.getBackBufferWidth = () => {
        const result = new Promise((resolve, fail) => {
            resolve(buffer.x);
        });

        return result;
    }

    ns.getBackBufferHeight = () => {
        const result = new Promise((resolve, fail) => {
            resolve(buffer.y);
        });

        return result;
    }

    ns.getKeyState = () => {
        const result = new Promise((resolve, fail) => {
            resolve({ keys: [...keys] });
        });

        return result;
    }
})(window.BlazorGame);