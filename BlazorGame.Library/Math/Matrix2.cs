using System;

namespace BlazorGame.Framework.Math
{
    public class Matrix2
    {
        private readonly double[] _matrix = { 0, 0, 0, 0 };

        public double this[int i]
        {
            get => _matrix[i];
            set => _matrix[i] = value;
        }

        public Matrix2(double a, double b, double c, double d)
        {
            _matrix[0] = a;
            _matrix[1] = b;
            _matrix[2] = c;
            _matrix[3] = d;
        }

        public static Matrix2 Create()
        {
            Matrix2 identity = new(1, 0, 0, 1);

            return identity;
        }

        public static Matrix2 Clone(Matrix2 value)
        {
            return new(value[0], value[1], value[2], value[3]);
        }

        public static Matrix2 Copy(Matrix2 target, Matrix2 value)
        {
            target[0] = value[0];
            target[1] = value[1];
            target[2] = value[2];
            target[3] = value[3];

            return target;
        }

        public static Matrix2 Identity(Matrix2 target)
        {
            target[0] = 1;
            target[1] = 0;
            target[2] = 0;
            target[3] = 1;

            return target;
        }

        public static Matrix2 Transpose(Matrix2 target, Matrix2 value)
        {
            var a = value[1];
            target[1] = value[2];
            target[2] = a;

            if (target != value)
            {
                target[0] = value[0];
                target[3] = value[3];
            }

            return target;
        }

        public static Matrix2 Invert(Matrix2 target, Matrix2 value)
        {
            double a0 = value[0],
                a1 = value[1],
                a2 = value[2],
                a3 = value[3];

            var determinant = Determinant(value);

            if (determinant == 0)
            {
                return null;
            }

            determinant = 1.0 / determinant;

            target[0] = a3 * determinant;
            target[1] = -a1 * determinant;
            target[2] = -a2 * determinant;
            target[3] = a0 * determinant;

            return target;
        }

        public static Matrix2 Adjoint(Matrix2 target, Matrix2 value)
        {
            var a0 = value[0];
            target[0] = value[3];
            target[1] = -value[1];
            target[2] = -value[2];
            target[3] = a0;

            return target;
        }

        public static double Determinant(Matrix2 value)
        {
            return value[0] * value[3] - value[2] * value[1];
        }

        public static Matrix2 Multiply(Matrix2 result, Matrix2 a, Matrix2 b)
        {
            double a0 = a[0],
                a1 = a[1],
                a2 = a[2],
                a3 = a[3];

            double b0 = b[0],
                b1 = b[1],
                b2 = b[2],
                b3 = b[3];

            result[0] = a0 * b0 + a2 * b1;
            result[1] = a1 * b0 + a3 * b1;
            result[2] = a0 * b2 + a2 * b3;
            result[3] = a1 * b2 + a3 * b3;

            return result;
        }

        public static Func<Matrix2, Matrix2, Matrix2, Matrix2> Mul = Multiply;

        public static Matrix2 Rotate(Matrix2 result, Matrix2 a, double radians)
        {
            double a0 = a[0],
                a1 = a[1],
                a2 = a[2],
                a3 = a[3];

            var sin = System.Math.Sin(radians);
            var cos = System.Math.Cos(radians);

            result[0] = a0 * cos + a2 * sin;
            result[1] = a1 * cos + a3 * sin;
            result[2] = a0 * -sin + a2 * cos;
            result[3] = a1 * -sin + a3 * cos;

            return result;
        }

        public static Matrix2 Scale(Matrix2 result, Matrix2 a, Vector2 v)
        {
            double a0 = a[0],
                a1 = a[1],
                a2 = a[2],
                a3 = a[3];

            double v0 = v[0],
                v1 = v[1];

            result[0] = a0 * v0;
            result[1] = a1 * v0;
            result[2] = a2 * v1;
            result[3] = a3 * v1;

            return result;
        }

        public static double Frob(Matrix2 a)
        {
            return System.Math.Sqrt(System.Math.Pow(a[0], 2) + System.Math.Pow(a[1], 2) + System.Math.Pow(a[2], 2) + System.Math.Pow(a[3], 2));
        }

        public static Matrix2[] LDU(Matrix2 l, Matrix2 d, Matrix2 u, double[] a)
        {
            l[2] = a[2] / a[0];
            u[0] = a[0];
            u[1] = a[1];
            u[3] = a[3] - l[2] * u[1];

            return new[] { l, d, u };
        }

        public static Matrix2 Add(Matrix2 result, Matrix2 a, Matrix2 b)
        {
            result[0] = a[0] + b[0];
            result[1] = a[1] + b[1];
            result[2] = a[2] + b[2];
            result[3] = a[3] + b[3];

            return result;
        }

        public static Matrix2 Subtract(Matrix2 result, Matrix2 a, Matrix2 b)
        {
            result[0] = a[0] - b[0];
            result[1] = a[1] - b[1];
            result[2] = a[2] - b[2];
            result[3] = a[3] - b[3];

            return result;
        }

        public static Matrix2 FromValues(double a, double b, double c, double d)
        {
            return new(a, b, c, d);
        }

        public static Matrix2 Set(Matrix2 result, double a, double b, double c, double d)
        {
            result[0] = a;
            result[1] = b;
            result[2] = c;
            result[3] = d;

            return result;
        }

        public static Matrix2 MultiplyScalar(Matrix2 result, Matrix2 a, double scalar)
        {
            result[0] = a[0] * scalar;
            result[1] = a[1] * scalar;
            result[2] = a[2] * scalar;
            result[3] = a[3] * scalar;

            return result;
        }

        public static Matrix2 MultiplyScalarAndAdd(Matrix2 result, Matrix2 a, Matrix2 b, double scalar)
        {
            result[0] = a[0] + b[0] * scalar;
            result[1] = a[1] + b[1] * scalar;
            result[2] = a[2] + b[2] * scalar;
            result[3] = a[3] + b[3] * scalar;

            return result;
        }

        public static implicit operator Matrix2(int[] value)
        {
            if (value.Length != 4) throw new ArgumentException("Value must be a 4 position Array", nameof(value));

            return new Matrix2(value[0], value[1], value[2], value[3]);
        }

        public static implicit operator Matrix2(double[] value)
        {
            if (value.Length != 4) throw new ArgumentException("Value must be a 4 position Array", nameof(value));

            return new Matrix2(value[0], value[1], value[2], value[3]);
        }

        public static bool operator ==(Matrix2 matrix, Matrix2 expected)
        {
            return matrix[0].IsCloseEnough(expected[0]) &&
                   matrix[1].IsCloseEnough(expected[1]) &&
                   matrix[2].IsCloseEnough(expected[2]) &&
                   matrix[3].IsCloseEnough(expected[3]);
        }

        public static bool operator !=(Matrix2 matrix, Matrix2 expected)
        {
            return !(matrix == expected);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Matrix2 matrix2)
            {
                return this == matrix2;
            }

            return false;
        }

        public static string ToString(Matrix2 a)
        {
            return $"mat2({a[0]}, {a[1]}, {a[2]}, {a[3]})";
        }

        protected bool Equals(Matrix2 other)
        {
            return Equals(_matrix, other._matrix);
        }

        public override int GetHashCode()
        {
            return (_matrix != null ? _matrix.GetHashCode() : 0);
        }
    }
}