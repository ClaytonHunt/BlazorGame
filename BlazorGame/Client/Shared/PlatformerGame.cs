using BlazorGame.Library;
using BlazorGame.Library.Graphics;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System;
using System.Collections.Generic;

namespace BlazorGame.Client.Shared
{
    public class PlatformerGame : Game
    {
        // Resources for drawing
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Vector2 baseScreenSize = new Vector2(800, 480);
        private Matrix globalTransformation;
        int backbufferWidth, backbufferHeight;

        // Global content
        private SpriteFont hudFont;

        private Texture2D winOverlay;
        private Texture2D loseOverlay;
        private Texture2D diedOverlay;

        // Meta-level game state.
        private int levelIndex = -1;
        private Level level;
        private bool wasContinuePressed;
    }

    public class Level : IDisposable
    {
        private Tile[,] tiles;
        private Texture2D[] layers;

        // The layer which entities are drawn on top of.
        private const int EntityLayer = 2;

        // Entities in hte level
        Player player;
        public Player Player
        {
            get { return player; }
        }

        private List<Gem> gems = new List<Gem>();
        private List<Enemy> enemies = new List<Enemy>();

        // Key locations in the level
        private Vector2 start;
        private Point exit = InvalidPostion;
        private static readonly Point InvalidPostion = new Point(-1, -1);

        // Level game state
        private Random random = new Random(354668); // Arbitrary, but constant seed

        int score;
        public int Score
        {
            get { return score; }
        }

        bool reachedExit;
        public bool ReachedExit
        {
            get { return reachedExit; }
        }

        TimeSpan timeRemaining;
        public TimeSpan TimeRemaining
        {
            get { return timeRemaining; }
        }

        private const int PointsPerSecond = 5;

        ContentManager content;
        public ContentManager Content
        {
            get { return content; }
        }

        private SoundEffect exitReachedSound;

        #region Loading
        // TODO: https://github.com/MonoGame/MonoGame.Samples/blob/develop/Platformer2D/Platformer2D.Core/Game/Level.cs
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
