using BlazorGame.Framework.Graphics;

namespace BlazorGame.Framework
{
    public class GraphicsDeviceInformation
    {
        public GraphicsAdapter Adapter { get; set; }
        public GraphicsProfile GraphicsProfile { get; set; }
        public PresentationParameters PresentationParameters { get; set; }
    }
}