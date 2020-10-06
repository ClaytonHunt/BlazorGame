namespace BlazorGame.Library
{
    public class Texture2D : IContent<ImageContent>
    {
        public string Path { get; set; }
        public int Position { get; set; }
        public int Width => Content.Width;
        public int Height => Content.Height;
        public ImageContent Content { get; set; }
    }
}