using System;

namespace BlazorGame.Framework.Graphics
{
    public class Effect : GraphicsResource, IDisposable
    {
        public EffectTechnique CurrentTechnique { get; set; }
        public EffectParameterCollection Parameters { get; }
        public EffectTechniqueCollection Techniques { get; }

        protected Effect(Effect cloneSource)
        {
            throw new NotImplementedException();
        }

        public Effect(IGraphicsDevice graphicsDevice, byte[] effectCode)
        {
            throw new NotImplementedException();
        }

        public Effect(IGraphicsDevice graphicsDevice, byte[] effectCode, int index, int count)
        {
            throw new NotImplementedException();
        }

        public virtual Effect Clone()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnApply()
        {
            throw new NotImplementedException();
        }

        protected override void GraphicsDeviceResetting()
        {
            base.GraphicsDeviceResetting();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
