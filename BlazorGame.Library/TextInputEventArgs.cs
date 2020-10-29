namespace BlazorGame.Framework
{
    public struct TextInputEventArgs
    {
        public readonly char Character;
        public readonly Keys Key;

        public TextInputEventArgs(char character, Keys key = Keys.None)
        {
            Character = character;
            Key = key;
        }
    }
}
