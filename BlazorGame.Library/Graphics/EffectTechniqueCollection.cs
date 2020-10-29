using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Graphics
{
    public class EffectTechniqueCollection : IEnumerable<EffectTechnique>, IEnumerable
    {
        public int Count { get; }
        public EffectTechnique this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public EffectTechnique this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<EffectTechnique> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
