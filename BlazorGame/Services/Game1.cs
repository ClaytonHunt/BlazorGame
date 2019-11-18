using System.Drawing;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorGame.Services
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;
        private int ballX, ballY = 0;
        private GameContent Content;
        private int ballXSpeed = 5;
        private int ballYSpeed = 5;

        public Game1(IJSRuntime jsRuntime) : base()
        {
            GraphicsDevice = new CanvasGraphicsDevice(jsRuntime);
            graphics = new GraphicsDeviceManager(this);
            Content = new GameContent(jsRuntime) {
                RootDirectory = "/"
            };

            Initialize();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override async Task LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = await Content.Load<Texture2D>("img/ball.png");
        }

        protected override async Task Update(GameTime gameTime)
        {
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//                Exit();

            // TODO: Add your update logic here
            ballX += ballXSpeed;
            if (ballX < 0 || ballX > (800 - ballTexture.Content.Width))
            {
                ballXSpeed = -ballXSpeed;
                ballX += ballXSpeed;
            }

            ballY += ballYSpeed;
            if (ballY < 0 || ballY > (640 - ballTexture.Content.Height))
            {
                ballYSpeed = -ballYSpeed;
                ballY += ballYSpeed;
            }

            await base.Update(gameTime);
        }

        protected override async Task Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, new Vector2(ballX, ballY), Color.White);
            spriteBatch.End();

            await base.Draw(gameTime);
        }
    }

    internal class GameContent
    {
        private readonly IJSRuntime _jsRuntime;

        public GameContent(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> Load<T>(string filename) where T: IContent, new()
        {
            var content = new T {
                Path = $"{RootDirectory}{filename}"
            };

            content = await _jsRuntime.InvokeAsync<T>("BlazorGame.loadContent", content);

            return content;
        }

        public string RootDirectory { get; set; }
    }

    public class Texture2D: IContent<ImageContent>
    {
        public string Path { get; set; }
        public int Position { get; set; }
        public ImageContent Content { get; set; }
    }

    public class ImageContent
    {
        [JsonPropertyName("imageWidth")]
        public int Width { get; set; }

        [JsonPropertyName("imageHeight")]
        public int Height { get; set; }
    }

    public interface IContent<T>: IContent
    {
        T  Content { get; set; }
    }

    public interface IContent
    {
        string Path { get; set; }
        int Position { get; set; }
    }
}
