using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Graphics
{
    public class EffectAnnotationCollection : IEnumerable<EffectAnnotation>, IEnumerable
    {
        public int Count { get; }
        public EffectAnnotation this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public EffectAnnotation this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<EffectAnnotation> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
