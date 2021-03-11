using System;
using BlazorGame.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using BlazorGame.Framework.Content;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Breakout
{
    public class Level : IDisposable
    {
        private readonly Paddle _paddle;
        private readonly BreakerBall _ball;
        private Brick[,] _bricks;
        private readonly List<IPhysics2D> _physicsObjects = new();
        private int _brickCount = -1;

        public bool LevelCleared => _brickCount == 0;

        public Level(Stream contents, Paddle paddle, BreakerBall ball)
        {
            _paddle = paddle;
            _ball = ball;

            _ = LoadLevel(contents);

            _physicsObjects.Add(_paddle);

            _physicsObjects.Add(_ball);
        }

        private async Task LoadLevel(Stream contents)
        {
            int width = 0;
            int height = 0;

            var lines = new List<string>();
            using (var reader = new StreamReader(contents))
            {
                var line = await reader.ReadLineAsync();
                if (line != null)
                {
                    width = line.Length;
                    while (line != null)
                    {
                        lines.Add(line);
                        if (line.Length != width)
                        {
                            throw new Exception($"The length of line {lines.Count} is different from all preceeding lines.");
                        }

                        line = await reader.ReadLineAsync();
                    }
                }

                height = lines.Count;
            }

            _bricks = new Brick[height, width];
            _brickCount = 0;

            for (var y = 0; y < height; ++y)
            {
                for (var x = 0; x < width; ++x)
                {
                    // to load each tile.
                    var brickType = lines[y][x];

                    if (brickType != '.')
                    {
                        _brickCount++;
                        _bricks[y, x] = await LoadBrick(brickType);
                    }
                }
            }
        }

        private async Task<Brick> LoadBrick(char brickType)
        {
            var brick = new Brick();

            _physicsObjects.Add(brick);

            return await Task.FromResult(brick);
        }

        public async Task LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            var tileSafeArea = graphics.GraphicsDevice.Viewport.TitleSafeArea;
            var brick10Texture = await content.Load<Texture2D>("Sprites/10PointBrick");

            var screenXCenter = tileSafeArea.X + (tileSafeArea.Width / 2.0);
            var screenYCenter = tileSafeArea.Y + (tileSafeArea.Height / 2.0);

            var brickXCenter = (_bricks.GetLength(1) - 1) * brick10Texture.Width / 2.0;
            var brickYCenter = (_bricks.GetLength(0) + 1) * brick10Texture.Height / 2.0;

            var xStart = screenXCenter - brickXCenter;
            var yStart = screenYCenter - brickYCenter;

            for (var y = 0; y < _bricks.GetLength(0); y++)
            {
                for (var x = 0; x < _bricks.GetLength(1); x++)
                {
                    if (_bricks[y, x] == null) continue;

                    var brickPosition = new Vector2(
                        (float)(xStart + (brick10Texture.Width * x)),
                        (float)(yStart + (brick10Texture.Height * y))
                    );

                    _bricks[y, x].Initialize(brick10Texture, brickPosition, graphics);
                }
            }
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            _paddle.Update(gameTime, keyState, _physicsObjects);

            _ball.Update(gameTime, keyState, _physicsObjects);

            foreach (var brick in _bricks)
            {
                brick.Update(gameTime, keyState, _physicsObjects);

                if (!brick.IsActive)
                {
                    _brickCount--;
                }
            }
        }

        public async Task Draw(SpriteBatch spriteBatch)
        {
            await _paddle.Draw(spriteBatch);

            await _ball.Draw(spriteBatch);

            foreach (var brick in _bricks)
            { 
                await brick.Draw(spriteBatch);
            }
        }

        public void Dispose()
        {
        }
    }
}
