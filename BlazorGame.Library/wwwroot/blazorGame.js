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
        var sprite = content.content;
        if (color.r != 255 || color.g != 255 || color.b != 255) {
             sprite = filterImage(sprite, color);
        }        

        context.drawImage(sprite, x, y);
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

    function filterImage(img, color) {
        const density = 100;

        var rIntensity = (color.r * density + 255 * (100 - density)) / 25500;
        var gIntensity = (color.g * density + 255 * (100 - density)) / 25500;
        var bIntensity = (color.b * density + 255 * (100 - density)) / 25500;
 
        var canvas = document.createElement("canvas");
        canvas.width = img.width;
        canvas.height = img.height;
        var ctx = canvas.getContext("2d");
        ctx.drawImage(img, 0, 0);
 
        var imageData = ctx.getImageData(0, 0, img.width, img.height);
        var data = imageData.data;
        for (var i = 0; i < data.length; i += 4) {
            var luma = 0.299 * data[i] + 0.587 * data[i+1] + 0.114 * data[i+2];
            data[i] = Math.round(rIntensity * luma);
            data[i+1] = Math.round(gIntensity * luma);
            data[i+2] = Math.round(bIntensity * luma);
        }
 
        ctx.putImageData(imageData, 0, 0);
 
        return canvas;
    }
})(window.BlazorGame);