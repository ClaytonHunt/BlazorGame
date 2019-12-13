using System.Threading.Tasks;

namespace BlazorGame.Services
{
    public class Game
    {
        public IGraphicsDevice GraphicsDevice { get; set; }

        public virtual async Task Initialize()
        {
            await LoadContent();

            GraphicsDevice.OnReady += (gameTime) =>
            {

                Update(gameTime);
                Draw(gameTime);
            };
        }

        protected virtual Task LoadContent()
        {
            return Task.CompletedTask;
        }

        protected virtual Task Update(GameTime gameTime)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Draw(GameTime gameTime)
        {
            return Task.CompletedTask;
        }
    }
}
