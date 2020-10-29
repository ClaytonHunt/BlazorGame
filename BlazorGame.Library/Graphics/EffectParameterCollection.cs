using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Graphics
{
    public class EffectParameterCollection : IEnumerable<EffectParameter>, IEnumerable
    {
        public int Count { get; }

        public EffectParameter this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EffectParameter this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<EffectParameter> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
