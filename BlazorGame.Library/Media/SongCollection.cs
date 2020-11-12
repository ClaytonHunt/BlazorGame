using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Media
{
    public class SongCollection : ICollection<Song>, IEnumerable<Song>, IEnumerable, IDisposable
    {
        public int Count { get; }
        public bool IsReadOnly { get; }
        public Song this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Song item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public SongCollection Clone()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Song item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Song[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Song> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(Song item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Song item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
