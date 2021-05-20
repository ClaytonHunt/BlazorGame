namespace BlazorGame.Framework.Math
{
    public class Vector2
    {
        private readonly double[] _vector = { 0, 0, 0, 0 };

        public double this[int i]
        {
            get => _vector[i];
            set => _vector[i] = value;
        }

        public Vector2(double x, double y)
        {
            _vector[0] = x;
            _vector[1] = y;
        }
    }
}