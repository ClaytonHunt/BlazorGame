using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorGame.Library
{
    public class Game : ComponentBase
    {
        public IGraphicsDevice GraphicsDevice { get; set; }

        protected virtual async Task InitializeAsync()
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
