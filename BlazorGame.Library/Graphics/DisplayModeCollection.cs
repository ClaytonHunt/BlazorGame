using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorGame.Framework.Graphics
{
    public class DisplayModeCollection : IEnumerable<DisplayMode>, IEnumerable
    {
        public IEnumerable<DisplayMode> this[SurfaceFormat format]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<DisplayMode> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
