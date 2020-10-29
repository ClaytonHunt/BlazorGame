namespace BlazorGame.Framework
{
    public struct InputKeyEventArgs
    {
        public readonly Keys Key;

        public InputKeyEventArgs(Keys key = Keys.None)
        {
            Key = key;
        }
    }
}
