using System;

namespace BlazorGame.Framework.Media
{
    public class Song : IContent, IEquatable<Song>, IDisposable
    {
        public Album Album { get; }
        public Artist Artist { get; }
        public TimeSpan Duration { get; }
        public Genre Genre { get; }
        public bool IsDisposed { get; }
        public bool IsProtected { get; }
        public bool IsRated { get; }
        public string Name { get; set; }
        public int PlayCount { get; }
        public int Rating { get; }
        public int TrackNumber { get; }        
        public string Path { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Song song)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        protected void Finalize()
        {
            throw new NotImplementedException();
        }

        public static Song FromUri(string name, Uri uri)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Song song1, Song song2)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Song song1, Song song2)
        {
            throw new NotImplementedException();
        }
    }
}
