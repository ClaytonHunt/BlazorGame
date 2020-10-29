using System;

namespace BlazorGame.Framework.Graphics
{
    public class EffectPass
    {
        public EffectAnnotationCollection Annotations { get; }
        public string Name { get; }

        public void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
