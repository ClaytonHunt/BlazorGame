using System;

namespace BlazorGame.Framework.Media
{
    public sealed class Artist : IDisposable
    {
        public AlbumCollection Albums { get; }
        public bool IsDisposed { get; }
        public string Name { get; }
        public SongCollection Songs { get; }

        public Artist(string artist)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
