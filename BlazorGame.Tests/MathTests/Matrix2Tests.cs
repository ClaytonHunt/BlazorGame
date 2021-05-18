using System;
using System.Transactions;
using BlazorGame.Framework.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using Confirm = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BlazorGame.Tests.MathTests
{
    [TestClass]
    public class Matrix2Tests
    {
        private readonly Matrix2 _matrixA;
        private readonly Matrix2 _matrixB;
        private readonly Matrix2 _out;
        private readonly Matrix2 _identity;

        public Matrix2Tests()
        {
            _matrixA = new[] { 1, 2, 3, 4 };
            _matrixB = new[] { 5, 6, 7, 8 };
            _out = new[] { 0, 0, 0, 0 };
            _identity = new[] { 1, 0, 0, 1 };
        }

        [TestMethod]
        public void Create()
        {
            var result = Matrix2.Create();

            Assert.AreEqual(result, _identity);
        }

        [TestMethod]
        public void Clone()
        {
            var result = Matrix2.Clone(_matrixA);

            Assert.AreEqual(_matrixA, result);
            Assert.AreNotSame(_matrixA, result);
        }

        [TestMethod]
        public void Copy()
        {
            var result = Matrix2.Copy(_out, _matrixA);

            Assert.AreEqual(_matrixA, _out);
            Assert.AreSame(_out, result);
        }

        [TestMethod]
        public void Identity()
        {
            var result = Matrix2.Identity(_out);

            Assert.AreEqual(_identity, result);
            Assert.AreSame(_out, result);
        }

        [TestMethod]
        public void Transpose_Different()
        {
            var result = Matrix2.Transpose(_out, _matrixA);

            Assert.AreSame(_out, result);
            Assert.AreEqual(new[] { 1, 3, 2, 4 }, result);
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Transpose_Same()
        {
            var result = Matrix2.Transpose(_matrixA, _matrixA);

            Assert.AreSame(_matrixA, result);
            Assert.AreEqual(new[] { 1, 3, 2, 4 }, _matrixA);
        }

        [TestMethod]
        public void Invert_Different()
        {
            var result = Matrix2.Invert(_out, _matrixA);

            Assert.AreSame(_out, result);
            Assert.AreEqual(new[] { -2, 1, 1.5, -0.5 }, _out);
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Invert_Same()
        {
            var result = Matrix2.Invert(_matrixA, _matrixA);

            Assert.AreSame(_matrixA, result);
            Assert.AreEqual(new[] { -2, 1, 1.5, -0.5 }, _matrixA);
        }

        [TestMethod]
        public void Invert_Zero_Determinant_Matrix()
        {
            var result = Matrix2.Invert(_out, new Matrix2(6, 4, 3, 2));

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Adjoint_Different()
        {
            var result = Matrix2.Adjoint(_out, _matrixA);

            Assert.AreSame(_out, result);
            Assert.AreEqual(new[] { 4, -2, -3, 1 }, _out);
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Adjoint_Same()
        {
            var result = Matrix2.Adjoint(_matrixA, _matrixA);

            Assert.AreSame(_matrixA, result);
            Assert.AreEqual(new[] { 4, -2, -3, 1 }, _matrixA);
        }

        [TestMethod]
        public void Determinant()
        {
            var result = Matrix2.Determinant(_matrixA);

            Assert.AreEqual(-2, result);
        }

        [TestMethod]
        public void Zero_Determinant()
        {
            var result = Matrix2.Determinant(new Matrix2(6, 4, 3, 2));

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Multiply_HasAlias_Mul()
        {
            Assert.AreEqual(Matrix2.Multiply, Matrix2.Mul);
        }

        [TestMethod]
        public void Multiply_CanHaveSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.Multiply(_out, _matrixA, _matrixB);

            // Assert
            Assert.AreEqual(new[] { 23, 34, 31, 46 }, _out);
            Assert.AreSame(_out, result);
            Assert.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
            Assert.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Multiply_WhenMatrixAIsTheOutputMatrix()
        {
            // Act
            var result = Matrix2.Multiply(_matrixA, _matrixA, _matrixB);

            // Assert
            Assert.AreEqual(new[] { 23, 34, 31, 46 }, _matrixA);
            Assert.AreSame(_matrixA, result);
            Assert.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Multiply_WhenMatrixBIsTheOutputMatrix()
        {
            // Act
            var result = Matrix2.Multiply(_matrixB, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { 23, 34, 31, 46 }, _matrixB);
            Confirm.AreSame(_matrixB, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Rotate_WithSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.Rotate(_out, _matrixA, Math.PI * 0.5);

            // Assert
            Confirm.AreEqual(new[] { 3, 4, -1, -2 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Rotate_WithOutputMatrixA()
        {
            // Act
            var result = Matrix2.Rotate(_matrixA, _matrixA, Math.PI * 0.5);

            // Assert
            Confirm.AreEqual(new[] { 3, 4, -1, -2 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
        }

        [TestMethod]
        public void Scale_WithSeparateOutputMatrix()
        {
            // Arrange
            Vector2 vector = new Vector2(2, 3);

            // Act
            var result = Matrix2.Scale(_out, _matrixA, vector);

            // Assert
            Confirm.AreEqual(new[] { 2, 4, 9, 12 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Scale_WithOutputMatrixA() {
            // Arrange
            Vector2 vector = new Vector2(2, 3);

            // Act
            var result = Matrix2.Scale(_matrixA, _matrixA, vector);

            // Assert
            Confirm.AreEqual(new[] { 2, 4, 9, 12 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
        }

        [TestMethod]
        public void ConvertToString()
        {
            // Act
            var result = Matrix2.ToString(_matrixA);

            // Assert
            Confirm.AreEqual("mat2(1, 2, 3, 4)", result);
        }

        [TestMethod]
        public void Frob()
        {
            // Act
            var result = Matrix2.Frob(_matrixA);

            // Assert
            Confirm.AreEqual(result, 5.477225575051661);
        }

        [TestMethod]
        public void LowerTriangular_Diagonal_UpperTriangular()
        {
            // Arrange
            Matrix2 L = Matrix2.Create(),
                D = Matrix2.Create(),
                U = Matrix2.Create(),
                L_Result = Matrix2.Create(),
                D_Result = Matrix2.Create(),
                U_Result = Matrix2.Create();

            L_Result[2] = 1.5;
            U_Result[0] = 4;
            U_Result[1] = 3;
            U_Result[3] = -1.5;


            Matrix2[] result = Matrix2.LDU(L, D, U, new double[] { 4, 3, 6, 3 });

            Confirm.AreEqual(L_Result, result[0]);
            Confirm.AreEqual(D_Result, result[1]);
            Confirm.AreEqual(U_Result, result[2]);
        }
    }

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

            var sin = Math.Sin(radians);
            var cos = Math.Cos(radians);

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
            return Math.Sqrt(Math.Pow(a[0],2) + Math.Pow(a[1],2) + Math.Pow(a[2],2) + Math.Pow(a[3],2));
        }

        public static Matrix2[] LDU(Matrix2 l, Matrix2 d, Matrix2 u, double[] a)
        {
            l[2] = a[2] / a[0];
            u[0] = a[0];
            u[1] = a[1];
            u[3] = a[3] - l[2] * u[1];

            return new [] {l, d, u};
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
    }

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