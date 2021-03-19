using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlazorGame.Framework.Content;

namespace BlazorGame.Client.Shared.RPG
{
    public abstract class GameScreen: GameComponent
    {
        [JsonIgnore] public Type Type => GetType();

        protected ContentManager Content { get; set; }

        public override Task LoadContent()
        {
            Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "RPG/Content");

            return Task.CompletedTask;
        }

        public override async Task UnloadContent()
        {
            await Content.Unload();
        }
    }
}