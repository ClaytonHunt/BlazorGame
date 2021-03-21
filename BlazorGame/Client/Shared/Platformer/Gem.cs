using BlazorGame.Framework.Audio;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;
using System;
using System.Threading.Tasks;
using BlazorGame.Client.Shared.Platformer;

namespace BlazorGame.Client.Shared
{
    public class Gem
    {
        private Texture2D texture;
        private Vector2 origin;
        private SoundEffect collectedSound;

        public readonly int PointValue = 30;
        public readonly Color Color = Color.Yellow;

        // the gem is animated from a base position along the Y axis.
        private Vector2 basePostion;
        private float bounce;

        public Level Level
        {
            get { return level; }
        }
        Level level;

        /// <summary>
        /// Gets the current position of this gem in world space
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return basePostion + new Vector2(0.0f, bounce);
            }
        }

        /// <summary>
        /// Gets a circle which bounds this gem in world space
        /// </summary>
        public Circle BoundingCircle
        {
            get
            {
                return new Circle(Position, Tile.Width / 3.0f);
            }
        }

        /// <summary>
        /// Constructs a new game
        /// </summary>
        /// <param name="level"></param>
        /// <param name="position"></param>
        public Gem(Level level, Vector2 position)
        {
            this.level = level;
            basePostion = position;

            _ = LoadContent();
        }

        public Task LoadContent()
        {
            texture = Level.Content.Load<Texture2D>("Sprites/Gem");
            origin = new Vector2(texture.Width / 2.0f, texture.Height / 2.0f);
            collectedSound = Level.Content.Load<SoundEffect>("Sounds/GemCollected");

            return Task.CompletedTask;
        }

        public void Update(GameTime gameTime)
        {                    
            // Bounce control constants
            const float BounceHeight = 0.18f;
            const float BounceRate = 3.0f;
            const float BounceSync = -0.75f;

            // Bounce along a sine curve over time.
            // Include the X coordinate so that neighboring gems bounce in a nice wave pattern.
            double t = gameTime.TotalGameTime.TotalSeconds * BounceRate + Position.X * BounceSync;
            bounce = (float)Math.Sin(t) * BounceHeight * texture.Height;
        }

        public void OnCollected(Player collectedBy)
        {
            collectedSound.Play();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {               
            spriteBatch.Draw(texture, Position, null, Color, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}