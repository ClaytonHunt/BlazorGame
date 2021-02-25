using BlazorGame.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorGame.Framework.Content;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Breakout
{
    public class Level
    {
        private Paddle _paddle;
        private BreakerBall _ball;
        private Brick[,] Bricks = new Brick[4, 6];
        private List<IPhysics2D> physicsObjects = new();

        public Level(Paddle paddle, BreakerBall ball)
        {
            _paddle = paddle;
            _ball = ball;

            Bricks[0, 0] = new Brick();
            Bricks[0, 1] = new Brick();
            Bricks[3, 5] = new Brick();

            physicsObjects.Add(_paddle);

            physicsObjects.Add(_ball);

            physicsObjects.Add(Bricks[0, 0]);
            physicsObjects.Add(Bricks[0, 1]);
            physicsObjects.Add(Bricks[3, 5]);
        }

        public async Task LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            var tileSafeArea = graphics.GraphicsDevice.Viewport.TitleSafeArea;
            var brick10Texture = await content.Load<Texture2D>("Sprites/10PointBrick");

            var screenXCenter = tileSafeArea.X + (tileSafeArea.Width / 2.0);
            var screenYCenter = tileSafeArea.Y + (tileSafeArea.Height / 2.0);

            var brickXCenter = Bricks.GetLength(1) * brick10Texture.Width / 2.0;
            var brickYCenter = Bricks.GetLength(0) * brick10Texture.Height / 2.0;

            var xStart = screenXCenter - brickXCenter;
            var yStart = screenYCenter - brickYCenter;

            for (var y = 0; y < Bricks.GetLength(0); y++)
            {
                for (var x = 0; x < Bricks.GetLength(1); x++)
                {
                    if (Bricks[y, x] != null)
                    {
                        var brickPosition = new Vector2(
                                (float)(xStart + (brick10Texture.Width * x)),
                                (float)(yStart + (brick10Texture.Height * y))
                            );

                        Bricks[y, x].Initialize(brick10Texture, brickPosition, graphics);
                    }
                }
            }
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            _paddle.Update(gameTime, keyState, physicsObjects);

            _ball.Update(gameTime, keyState, physicsObjects);

            foreach (var brick in Bricks)
            {
                if (brick != null)
                {
                    brick.Update(gameTime, keyState, physicsObjects);
                }
            }
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {
            await _paddle.Draw(spriteBatch);

            await _ball.Draw(spriteBatch);

            foreach (var brick in Bricks)
            {
                if (brick != null)
                {
                    await brick.Draw(spriteBatch);
                }
            }
        }
    }
}
