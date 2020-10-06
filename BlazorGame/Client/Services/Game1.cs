using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using BlazorGame.Client.Drivers;
using BlazorGame.Shared.Services;
using Microsoft.JSInterop;

namespace BlazorGame.Client.Services
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly IKeyboardDriver _keyboard;
        private readonly GameContent _content;
        private SpriteBatch _spriteBatch;
        private Player player;
        private float _ballSpeed = 100;

        public Game1(IJSRuntime jsRuntime, GameContent content, int width, int height) : base()
        {
            GraphicsDevice = new CanvasGraphicsDevice(jsRuntime, width, height);
            _graphics = new GraphicsDeviceManager(this);
            _keyboard = new JsKeyboardDriver(jsRuntime);
            (_content = content).RootDirectory = "/";
        }

        public override async Task Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();

            await base.Initialize();
        }

        protected override async Task LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Vector2 playerPostion = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, (float)(GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2.0));

            player.Initialize(await _content.Load<Texture2D>("Graphics/player"), playerPostion);
        }

        protected override async Task Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            // Exit();

            // TODO: Add your update logic here
            var keyState = await _keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Up))
                player.Position.Y -= _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Down))
                player.Position.Y += _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Left))
                player.Position.X -= _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Right))
                player.Position.X += _ballSpeed * (float)gameTime.ElapsedTime.TotalSeconds;

            player.Position.X = Math.Min(Math.Max(player.PlayerTexture.Width / 2.0f, player.Position.X), _graphics.GraphicsDevice.PreferredBackBufferWidth - player.PlayerTexture.Width / 2);
            player.Position.Y = Math.Min(Math.Max(player.PlayerTexture.Height / 2.0f, player.Position.Y), _graphics.GraphicsDevice.PreferredBackBufferHeight - player.PlayerTexture.Height / 2);

            await base.Update(gameTime);
        }

        protected override async Task Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                player.PlayerTexture,
                player.Position,
                null,
                Color.White,
                0f,
                new Vector2(player.PlayerTexture.Width / 2, player.PlayerTexture.Height / 2),
                1f,
                SpriteEffects.None,
                0f);
            _spriteBatch.End();

            await base.Draw(gameTime);
        }
    }
}
