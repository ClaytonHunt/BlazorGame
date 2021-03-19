using System.Threading.Tasks;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.RPG
{
    public class SplashScreen : GameScreen
    {
        public Image Image { get; set; }

        public override async Task LoadContent()
        {
            await Image.LoadContent();
        }

        public override async Task UnloadContent()
        {
            await Image.UnloadContent();
        }

        public override async Task Update(GameTime gameTime)
        {
            await Image.Update(gameTime);
        }

        public override async Task Draw(SpriteBatch spriteBatch)
        {
            await Image.Draw(spriteBatch);
        }
    }
}