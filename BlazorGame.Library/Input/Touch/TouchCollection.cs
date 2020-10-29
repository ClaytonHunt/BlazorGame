using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Input.Touch
{
    public struct TouchCollection : IList<TouchLocation>, ICollection<TouchLocation>, IEnumerable<TouchLocation>, IEnumerable
    {
        public bool IsConnected { get; }        
        public int Count { get; }
        public bool IsReadOnly { get; }
        public TouchLocation this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TouchCollection(TouchLocation[] touches)
        {
            throw new NotImplementedException();
        }

        public void Add(TouchLocation item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TouchLocation item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TouchLocation[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool FindById(int id, out TouchLocation touchLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TouchLocation> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(TouchLocation item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, TouchLocation item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TouchLocation item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator<TouchLocation> IEnumerable<TouchLocation>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
