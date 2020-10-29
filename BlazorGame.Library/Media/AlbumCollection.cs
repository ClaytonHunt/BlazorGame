using System;
using System.Collections.Generic;

namespace BlazorGame.Framework.Media
{
    public sealed class AlbumCollection : IDisposable
    {
        public int Count { get; }
        public bool IsDisposed { get; }
        public Album this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AlbumCollection(List<Album> albums)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
