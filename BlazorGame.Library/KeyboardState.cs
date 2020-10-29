using System.Linq;

namespace BlazorGame.Framework
{
    public class KeyboardState
    {
        public int[] Keys { get; set; }

        public bool IsKeyDown(Keys key)
        {
            return Keys.Contains((int)key);
        }
    }
}