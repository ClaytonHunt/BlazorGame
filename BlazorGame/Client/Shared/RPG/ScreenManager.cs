using System;
using System.Threading.Tasks;
using BlazorGame.Framework;
using BlazorGame.Framework.Content;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.RPG
{
    public class ScreenManager
    {
        private static ScreenManager _instance;
        public static ScreenManager Instance => _instance ??= new ScreenManager();

        private GameScreen _currentScreen;

        public Vector2 Dimensions { get; init; }
        public ContentManager Content { get; private set; }
        public IGraphicsDevice GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public FileManager<GameScreen> FileGameScreenManager { get; set; }

        private ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
        }

        public async Task LoadContent(ContentManager content)
        {
            Content = new ContentManager(content.ServiceProvider, "RPG/Content");

            _currentScreen = new SplashScreen();
            FileGameScreenManager = new FileManager<GameScreen>(Content);

            _currentScreen = await FileGameScreenManager.Load<SplashScreen>($"RPG/Load/{_currentScreen.GetType().Name}.json");

            await _currentScreen.LoadContent();
        }

        public async Task UnloadContent()
        {
            await _currentScreen.UnloadContent();
        }

        public async Task Update(GameTime gameTime)
        {
            await _currentScreen.Update(gameTime);
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {
            await _currentScreen.Draw(spriteBatch);
        }
    }
}
