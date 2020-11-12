using System;

namespace BlazorGame.Framework.Audio
{
    public class SoundEffect : IContent, IDisposable
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public bool Play()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool value) { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
