namespace BlazorGame.Services
{
    public class GraphicsDeviceManager
    {
        private readonly Game _game;

        public IGraphicsDevice GraphicsDevice { get; set; }

        public GraphicsDeviceManager(Game game)
        {
            _game = game;
            GraphicsDevice = _game.GraphicsDevice;
        }
    }
}
