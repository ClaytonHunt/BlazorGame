using System;
using System.IO;

namespace BlazorGame.Framework.Media
{
    public sealed class Album : IDisposable
    {
        public Artist Artist { get; }
        public TimeSpan Duration { get; }
        public Genre Genre { get; }
        public bool HasArt { get; }
        public bool IsDisposed { get; }
        public string Name { get; }
        public SongCollection Songs { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Stream GetAlbumArt()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public Stream GetThumbnail()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
