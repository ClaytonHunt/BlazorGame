using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorGame.Framework
{
    public static class MathHelper
    {
        public const float E = 2.71828175F;
        public const float Log10E = 0.4342945F;
        public const float Log2E = 1.442695F;
        public const float Pi = 3.14159274F;
        public const float PiOver2 = 1.57079637F;
        public const float PiOver4 = 0.7853982F;
        public const float Tau = 6.28318548F;
        public const float TwoPi = 6.28318548F;

        public static float Barycentric(float value1, float value2, float value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }

        public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            throw new NotImplementedException();
        }

        public static int Clamp(int value, int min, int max)
        {
            return min > value ? min : value > max ? max : value;
        }

        public static float Clamp(float value, float min, float max)
        {
            return min > value ? min : value > max ? max : value;
        }

        public static float Distance(float value1, float value2)
        {
            throw new NotImplementedException();
        }

        public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
        {
            throw new NotImplementedException();
        }

        public static bool IsPowerOfTwo(int value)
        {
            throw new NotImplementedException();
        }

        public static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        public static float LerpPrecise(float value1, float value2, float amount)
        {
            return ((1 - amount) * value1) + (value2 * amount);
        }

        public static int Max(int value1, int value2)
        {
            throw new NotImplementedException();
        }

        public static float Max(float value1, float value2)
        {
            throw new NotImplementedException();
        }

        public static int Min(int value1, int value2)
        {
            throw new NotImplementedException();
        }

        public static float Min(float value1, float value2)
        {
            throw new NotImplementedException();
        }

        public static float SmoothStep(float value1, float value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static float ToDegrees(float radians)
        {
            throw new NotImplementedException();
        }

        public static float ToRadians(float degrees)
        {
            throw new NotImplementedException();
        }

        public static float WrapAngle(float angle)
        {
            throw new NotImplementedException();
        }
    }
}
