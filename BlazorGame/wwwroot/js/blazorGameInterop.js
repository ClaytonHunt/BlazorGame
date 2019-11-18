window.BlazorGame = window.BlazorGame || {};
(function (ns) {
    var context = null;
    var dotnetGraphics = null;
    var contents = [];

    ns.initialize = (dotnetHelper) => {
        var canvas = document.getElementById("blazorGameGraphicsContext");
        context = canvas.getContext("2d");
        dotnetGraphics = dotnetHelper;

        window.requestAnimationFrame(ns.render);
    };

    ns.render = (timestamp) => {
        dotnetGraphics.invokeMethodAsync('Render', timestamp)
            .then(_ => window.requestAnimationFrame(ns.render));
    };

    ns.clear = (color) => {
        context.beginPath();
        context.rect(0, 0, context.canvas.width, context.canvas.height);
        context.fillStyle = `rgba(${color.r}, ${color.g}, ${color.b}, ${(color.a / 255)})`;
        context.fill();
        context.closePath();
    };

    ns.loadContent = (content) => {
        const result = new Promise((resolve) => {
            const image = new Image();
            image.src = content.path;
            image.onload = () => {
                content.isReady = true;
                content.content.imageWidth = content.content.width;
                content.content.imageHeight = content.content.height;

                resolve(content);
            };

            content.content = image;
            content.position = contents.length;

            contents.push(content);
        });
        

        return result;
    };

    ns.drawSprite = (position, x, y, color) => {
        context.drawImage(contents[position].content, x, y);
    };
})(window.BlazorGame);