using System;
using BlazorGame.Framework.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            _out = new[] { 0, 0, 0, 0 };
            _matrixA = new[] { 1, 2, 3, 4 };
            _matrixB = new[] { 5, 6, 7, 8 };
            _identity = new[] { 1, 0, 0, 1 };
        }

        [TestMethod]
        public void Create()
        {
            var result = Matrix2.Create();

            Confirm.AreEqual(result, _identity);
        }

        [TestMethod]
        public void Clone()
        {
            var result = Matrix2.Clone(_matrixA);

            Confirm.AreEqual(_matrixA, result);
            Confirm.AreNotSame(_matrixA, result);
        }

        [TestMethod]
        public void Copy()
        {
            var result = Matrix2.Copy(_out, _matrixA);

            Confirm.AreEqual(_matrixA, _out);
            Confirm.AreSame(_out, result);
        }

        [TestMethod]
        public void Identity()
        {
            var result = Matrix2.Identity(_out);

            Confirm.AreEqual(_identity, result);
            Confirm.AreSame(_out, result);
        }

        [TestMethod]
        public void Transpose_Different()
        {
            var result = Matrix2.Transpose(_out, _matrixA);

            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 3, 2, 4 }, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Transpose_Same()
        {
            var result = Matrix2.Transpose(_matrixA, _matrixA);

            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { 1, 3, 2, 4 }, _matrixA);
        }

        [TestMethod]
        public void Invert_Different()
        {
            var result = Matrix2.Invert(_out, _matrixA);

            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { -2, 1, 1.5, -0.5 }, _out);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Invert_Same()
        {
            var result = Matrix2.Invert(_matrixA, _matrixA);

            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { -2, 1, 1.5, -0.5 }, _matrixA);
        }

        [TestMethod]
        public void Invert_Zero_Determinant_Matrix()
        {
            var result = Matrix2.Invert(_out, new Matrix2(6, 4, 3, 2));

            Confirm.IsNull(result);
        }

        [TestMethod]
        public void Adjoint_Different()
        {
            var result = Matrix2.Adjoint(_out, _matrixA);

            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 4, -2, -3, 1 }, _out);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Adjoint_Same()
        {
            var result = Matrix2.Adjoint(_matrixA, _matrixA);

            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { 4, -2, -3, 1 }, _matrixA);
        }

        [TestMethod]
        public void Determinant()
        {
            var result = Matrix2.Determinant(_matrixA);

            Confirm.AreEqual(-2, result);
        }

        [TestMethod]
        public void Zero_Determinant()
        {
            var result = Matrix2.Determinant(new Matrix2(6, 4, 3, 2));

            Confirm.AreEqual(0, result);
        }

        [TestMethod]
        public void Multiply_HasAlias_Mul()
        {
            Confirm.AreEqual(Matrix2.Multiply, Matrix2.Mul);
        }

        [TestMethod]
        public void Multiply_CanHaveSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.Multiply(_out, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { 23, 34, 31, 46 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Multiply_WhenMatrixAIsTheOutputMatrix()
        {
            // Act
            var result = Matrix2.Multiply(_matrixA, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { 23, 34, 31, 46 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
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
        public void Scale_WithOutputMatrixA()
        {
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
            Matrix2 l = Matrix2.Create(),
                d = Matrix2.Create(),
                u = Matrix2.Create(),
                lResult = Matrix2.Create(),
                dResult = Matrix2.Create(),
                uResult = Matrix2.Create();

            lResult[2] = 1.5;
            uResult[0] = 4;
            uResult[1] = 3;
            uResult[3] = -1.5;


            Matrix2[] result = Matrix2.LDU(l, d, u, new double[] { 4, 3, 6, 3 });

            Confirm.AreEqual(lResult, result[0]);
            Confirm.AreEqual(dResult, result[1]);
            Confirm.AreEqual(uResult, result[2]);
        }

        [TestMethod]
        public void Add_WithSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.Add(_out, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { 6, 8, 10, 12 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Add_WithOutputMatrixA()
        {
            // Act
            var result = Matrix2.Add(_matrixA, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { 6, 8, 10, 12 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Add_WithOutputMatrixB()
        {
            // Act
            var result = Matrix2.Add(_matrixB, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { 6, 8, 10, 12 }, _matrixB);
            Confirm.AreSame(_matrixB, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void Subtract_WithSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.Subtract(_out, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { -4, -4, -4, -4 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Subtract_WithOutputMatrixA()
        {
            // Act
            var result = Matrix2.Subtract(_matrixA, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { -4, -4, -4, -4 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void Subtract_WithOutputMatrixB()
        {
            // Act
            var result = Matrix2.Subtract(_matrixB, _matrixA, _matrixB);

            // Assert
            Confirm.AreEqual(new[] { -4, -4, -4, -4 }, _matrixB);
            Confirm.AreSame(_matrixB, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void FromValues_ReturnsMatrixWithValues()
        {
            // Act
            var result = Matrix2.FromValues(1, 2, 3, 4);

            // Assert
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, result);
        }

        [TestMethod]
        public void Set_SetsGivenValuesOnMatrix()
        {
            // Act
            var result = Matrix2.Set(_out, 1, 2, 3, 4);

            // Assert
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, result);
            Confirm.AreSame(_out, result);
        }

        [TestMethod]
        public void MultiplyScalar_WithSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.MultiplyScalar(_out, _matrixA, 2);

            // Assert
            Confirm.AreEqual(new[] { 2, 4, 6, 8 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }

        [TestMethod]
        public void MultiplyScalar_WithOutputMatrixA()
        {
            // Act
            var result = Matrix2.MultiplyScalar(_matrixA, _matrixA, 2);

            // Assert
            Confirm.AreEqual(new[] { 2, 4, 6, 8 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
        }

        [TestMethod]
        public void MultiplyScalarAndAdd_WithSeparateOutputMatrix()
        {
            // Act
            var result = Matrix2.MultiplyScalarAndAdd(_out, _matrixA, _matrixB, 0.5);

            // Assert
            Confirm.AreEqual(new[] { 3.5, 5, 6.5, 8 }, _out);
            Confirm.AreSame(_out, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void MultiplyScalarAndAdd_WithOutputMatrixA()
        {
            // Act
            var result = Matrix2.MultiplyScalarAndAdd(_matrixA, _matrixA, _matrixB, 0.5);

            // Assert
            Confirm.AreEqual(new[] { 3.5, 5, 6.5, 8 }, _matrixA);
            Confirm.AreSame(_matrixA, result);
            Confirm.AreEqual(new[] { 5, 6, 7, 8 }, _matrixB);
        }

        [TestMethod]
        public void MultiplyScalarAndAdd_WithOutputMatrixB()
        {
            // Act
            var result = Matrix2.MultiplyScalarAndAdd(_matrixB, _matrixA, _matrixB, 0.5);

            // Assert
            Confirm.AreEqual(new[] { 3.5, 5, 6.5, 8 }, _matrixB);
            Confirm.AreSame(_matrixB, result);
            Confirm.AreEqual(new[] { 1, 2, 3, 4 }, _matrixA);
        }
    }
}