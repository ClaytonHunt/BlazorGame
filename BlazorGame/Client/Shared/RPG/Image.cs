using System;
using System.Threading.Tasks;
using BlazorGame.Framework;
using BlazorGame.Framework.Content;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.RPG
{
    public class Image : GameComponent
    {
        public float Alpha { get; set; }
        // public string Text { get; set; }
        // public string FontName { get; set; }
        public string Path { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Rectangle SourceRect { get; set; }

        public ContentManager Content { get; private set; }
        public Texture2D Texture { get; private set; }
        public Vector2 Origin => new(SourceRect.Width / 2f, SourceRect.Height / 2f);
        public RenderTarget2D RenderTarget { get; private set; }
        // public SpriteFont Font { get; private set; }

        public Image()
        {
            Path = string.Empty;
            // FontName = "Fonts/Orbitron";
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Alpha = 1.0f;
            SourceRect = Rectangle.Empty;
        }

        public override async Task LoadContent()
        {
            Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "RPG/Content");

            if (Path != string.Empty)
            {
                Texture = await Content.Load<Texture2D>(Path);
            }

            // Font = await Content.Load<SpriteFont>(FontName);

            Console.WriteLine("Made It!");

            var x = 0.0f;
            var y = 0.0f;

            if (Texture != null)
            {
                x = Texture.Width;
                y = Texture.Height; // Extra
                // x += Font.MeasureString(Text).X;
            }

            //var y = Texture != null ? 
            //    Math.Max(Texture.Height, Font.MeasureString(Text).Y) : 
            //    Font.MeasureString(Text).Y;
            

            if (SourceRect == Rectangle.Empty)
            {
                SourceRect = new Rectangle(0, 0, (int) x, (int) y);
            }

            RenderTarget = new RenderTarget2D(ScreenManager.Instance.GraphicsDevice, (int) x, (int) y);

            await ScreenManager.Instance.GraphicsDevice.SetRenderTarget(RenderTarget);
            await ScreenManager.Instance.GraphicsDevice.Clear(Color.Transparent);
            await ScreenManager.Instance.SpriteBatch.Begin();

            if (Texture != null)
            {
                await ScreenManager.Instance.SpriteBatch.Draw(Texture, Vector2.Zero, Color.White);
            }

            // await ScreenManager.Instance.SpriteBatch.DrawString(Font, Text, Vector2.Zero, Color.White);

            await ScreenManager.Instance.SpriteBatch.End();

            Texture = RenderTarget;

            await ScreenManager.Instance.GraphicsDevice.SetRenderTarget(null);
        }

        public override async Task UnloadContent()
        {
            await Content.Unload();
        }

        public override async Task Draw(SpriteBatch spriteBatch)
        {
            await spriteBatch.Draw(Texture, Position, SourceRect, Color.White * Alpha, 0.0f, Origin, Scale, SpriteEffects.None, 0.0f);
        }
    }
}