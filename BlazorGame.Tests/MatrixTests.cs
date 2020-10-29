using BlazorGame.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlazorGame.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void DeterminantIsCorrectFor2x2()
        {
            // Arrange
            var matrix = new Matrix2(3, 5, -2, 3);

            // Act
            var result = matrix.Determinant();

            // Assert
            Assert.AreEqual(19, result);
        }

        [TestMethod]
        public void DeterminantIsCorrectFor3x3_1()
        {
            // Arrange
            var matrix = new Matrix3(5, 0, 3, 2, 3, 5, 1, -2, 3);

            // Act
            var result = matrix.Determinant();

            // Assert
            Assert.AreEqual(74, result);
        }

        [TestMethod]
        public void DeterminantIsCorrectFor3x3_2()
        {
            // Arrange
            var matrix = new Matrix3(2, 5, 3, -1, 2, 5, 2, 1, 3);

            // Act
            var result = matrix.Determinant();

            // Assert
            Assert.AreEqual(52, result);
        }

        [TestMethod]
        public void DeterminantIsCorrectFor4x4()
        {
            // Arrange
            var matrix = new Matrix(1, 0, 4, -6, 2, 5, 0, 3, -1, 2, 3, 5, 2, 1, -2, 3);

            // Act
            var result = matrix.Determinant();

            // Assert
            Assert.AreEqual(318, result);
        }

        [TestMethod]
        public void CofactorIsCorrectFor4x4()
        {
            // Arrange
            var matrix = new Matrix(1, 0, 0, 1, 0, 2, 1, 2, 2, 1, 0, 1, 2, 0, 1, 4);

            // Act
            var result = Matrix.Cofactor(matrix);

            // Assert
            Assert.AreEqual(-4, result.M11);
            Assert.AreEqual(2, result.M12);
            Assert.AreEqual(-16, result.M13);
            Assert.AreEqual(6, result.M14);
            Assert.AreEqual(-1, result.M21);
            Assert.AreEqual(1, result.M22);
            Assert.AreEqual(-2, result.M23);
            Assert.AreEqual(1, result.M24);
            Assert.AreEqual(2, result.M31);
            Assert.AreEqual(0, result.M32);
            Assert.AreEqual(4, result.M33);
            Assert.AreEqual(-2, result.M34);
            Assert.AreEqual(1, result.M41);
            Assert.AreEqual(-1, result.M42);
            Assert.AreEqual(4, result.M43);
            Assert.AreEqual(-1, result.M44);
        }

        [TestMethod]
        public void TransposeIsCorrectFor4x4()
        {
            // Arrange
            var matrix = new Matrix(-4, 2, -16, 6, -1, 1, -2, 1, 2, 0, 4, -2, 1, -1, 4, -1);

            // Act
            var result = Matrix.Transpose(matrix);

            // Assert
            Assert.AreEqual(-4, result.M11);
            Assert.AreEqual(-1, result.M12);
            Assert.AreEqual(2, result.M13);
            Assert.AreEqual(1, result.M14);
            Assert.AreEqual(2, result.M21);
            Assert.AreEqual(1, result.M22);
            Assert.AreEqual(0, result.M23);
            Assert.AreEqual(-1, result.M24);
            Assert.AreEqual(-16, result.M31);
            Assert.AreEqual(-2, result.M32);
            Assert.AreEqual(4, result.M33);
            Assert.AreEqual(4, result.M34);
            Assert.AreEqual(6, result.M41);
            Assert.AreEqual(1, result.M42);
            Assert.AreEqual(-2, result.M43);
            Assert.AreEqual(-1, result.M44);
        }

        [TestMethod]
        public void InvertIsCorrectFor4x4()
        {
            // Arrange
            var matrix = new Matrix(1, 0, 0, 1, 0, 2, 1, 2, 2, 1, 0, 1, 2, 0, 1, 4);

            // Act
            var result = Matrix.Invert(matrix);

            // Assert
            Assert.AreEqual(-2, result.M11);
            Assert.AreEqual(-.5, result.M12);
            Assert.AreEqual(1, result.M13);
            Assert.AreEqual(.5, result.M14);
            Assert.AreEqual(1, result.M21);
            Assert.AreEqual(.5, result.M22);
            Assert.AreEqual(0, result.M23);
            Assert.AreEqual(-.5, result.M24);
            Assert.AreEqual(-8, result.M31);
            Assert.AreEqual(-1, result.M32);
            Assert.AreEqual(2, result.M33);
            Assert.AreEqual(2, result.M34);
            Assert.AreEqual(3, result.M41);
            Assert.AreEqual(.5, result.M42);
            Assert.AreEqual(-1, result.M43);
            Assert.AreEqual(-.5, result.M44);
        }
    }
}
