using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Graphics
{
    public class EffectPassCollection : IEnumerable<EffectPass>, IEnumerable
    {
        public int Count { get; }
        public EffectPass this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EffectPass this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EffectPassCollection.Enumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<EffectPass> IEnumerable<EffectPass>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public struct Enumerator : IEnumerator<EffectPass>, IDisposable, IEnumerator
        {
            public EffectPass Current { get; }
            object IEnumerator.Current { get; }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }   
            
            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }            
        }
    }
}
