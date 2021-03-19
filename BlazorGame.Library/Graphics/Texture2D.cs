using System;
using System.IO;

namespace BlazorGame.Framework.Graphics
{
    public class Texture2D : Texture, IContent, IDisposable
    {
        private readonly IGraphicsDevice _graphicsDevice;

        public int Width { get; set; }
        public int Height { get; set; }
        public string Path { get;set; }
        public Rectangle Bounds { get; }
        
        protected bool Mipmap { get; }
        protected bool Shared { get; }
        protected SampleDescription SampleDescription { get; }

        public Texture2D() { }

        public Texture2D(IGraphicsDevice graphicsDevice, int width, int height)
        {
            Width = width;
            Height = height;
            _graphicsDevice = graphicsDevice;
        }

        public Texture2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipmap, SurfaceFormat format)
        {
            throw new NotImplementedException("Constructor 2");
        }

        protected Texture2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipmap, SurfaceFormat format, Texture2D.SurfaceType type, bool shared, int arraySize)
        {
            throw new NotImplementedException("Constructor 3");
        }

        public Texture2D(IGraphicsDevice graphicsDevice, int width, int height, bool mipmap, SurfaceFormat format, int arraySize)
        {
            throw new NotImplementedException("Constructor 4");
        }

        public static Texture2D FromFile(IGraphicsDevice graphicsDevice, string path)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromStream(IGraphicsDevice graphicsDevice, Stream stream)
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(int level, int arraySlice, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void Reload(Stream textureStream)
        {
            throw new NotImplementedException();
        }

        public void SaveAsJpeg(Stream stream, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void SaveAsPng(Stream stream, int width, int height)
        {
            throw new NotImplementedException();
        }

        protected virtual Texture2DDescription GetTexture2DDescription()
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {

        }

        protected enum SurfaceType
        {
            RenderTarget,
            SwapChainRenderTarget,
            Texture
        }
    }
}