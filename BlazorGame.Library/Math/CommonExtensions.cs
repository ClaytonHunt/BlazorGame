using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Maths = System.Math;

namespace BlazorGame.Framework.Math
{
    public static class CommonExtensions
    {
        public const double Epsilon = 0.000001;

        public static double ToRadian(this int degrees)
        {
            return ToRadian((double) degrees);
        }

        public static double ToRadian(this double degrees)
        {
            return degrees * (Maths.PI / 180);
        }

        public static bool IsCloseEnough(this double a, double b)
        {
            return Maths.Abs(a - b) <= Epsilon * Maths.Max(Maths.Max(Maths.Abs(a), Maths.Abs(b)), 1.0);
        }
    }
}
