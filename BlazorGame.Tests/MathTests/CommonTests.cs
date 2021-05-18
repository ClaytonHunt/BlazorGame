using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorGame.Framework.Math;

namespace BlazorGame.Tests.MathTests
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        public void Degree_ToRadian_ReturnsRadian()
        {
            // Act
            var result = 180.ToRadian();

            // Assert
            Assert.AreEqual(Math.PI, result, 0.0000001d);
        }

        [TestMethod]
        public void TwoEqualDoubles_Equals_ReturnsTrue()
        {
            var result = 1.0d.IsCloseEnough(1.0d);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TwoUnequalDoubles_Equals_ReturnsFalse()
        {
            var result = 1.0d.IsCloseEnough(0.0d);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TwoAlmostEqualDoubles_Equals_ReturnsTrue()
        {
            var result = 1.0d.IsCloseEnough(1.0d+CommonExtensions.Epsilon/2);

            Assert.IsTrue(result);
        }
    }
}
