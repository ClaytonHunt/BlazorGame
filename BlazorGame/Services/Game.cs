using System.Threading.Tasks;

namespace BlazorGame.Services
{
    public class Game
    {
        public IGraphicsDevice GraphicsDevice { get; set; }

        protected virtual void Initialize()
        {
            LoadContent();

            GraphicsDevice.OnReady += () =>
            {
                Update(null);
                Draw(null);
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
