using System;

namespace BlazorGame.Framework.Graphics
{
    public class TextureCube : Texture, IDisposable
    {
        public int Size { get; }

        public TextureCube(IGraphicsDevice graphicsDevice, int size, bool mipMap, SurfaceFormat format)
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(CubeMapFace cubeMapFace, T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(CubeMapFace cubeMapFace, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(CubeMapFace cubeMapFace, int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(CubeMapFace face, T[] data) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(CubeMapFace face, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(CubeMapFace face, int level, Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            throw new NotImplementedException();
        }
    }
}
