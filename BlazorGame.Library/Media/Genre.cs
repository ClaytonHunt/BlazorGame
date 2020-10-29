using System;

namespace BlazorGame.Framework.Media
{
    public sealed class Genre : IDisposable
    {
        public AlbumCollection Albums { get; }
        public bool IsDisposed { get; }
        public string Name { get; }
        public SongCollection Songs { get; }

        public Genre(string genre)
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
