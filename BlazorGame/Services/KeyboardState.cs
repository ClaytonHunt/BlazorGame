using System.Linq;

namespace BlazorGame.Services
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