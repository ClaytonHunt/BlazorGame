using System.Threading.Tasks;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.RPG
{
    public abstract class GameComponent
    {
        public virtual Task LoadContent()
        {
            return Task.CompletedTask;
        }

        public virtual Task UnloadContent()
        {
            return Task.CompletedTask;
        }

        public virtual Task Update(GameTime gameTime)
        {
            return Task.CompletedTask;
        }

        public virtual Task Draw(SpriteBatch spriteBatch)
        {
            return Task.CompletedTask;
        }
    }
}