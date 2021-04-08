using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGame.Framework.Graphics
{
    public struct Rectangle
    {
        public float Top {get;set;}
        public float Left {get;set;}
        public float Bottom {get;set;}
        public float Right {get;set;}

        public Rectangle(float top, float left, float bottom, float right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}
