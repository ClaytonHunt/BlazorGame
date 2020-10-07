using System;

namespace BlazorGame.Library
{
    public struct Matrix : IEquatable<Matrix>
    {
        private float M11;
        private float M12;
        private float M13;
        private float M14;
        private float M21;
        private float M22;
        private float M23;
        private float M24;
        private float M31;
        private float M32;
        private float M33;
        private float M34;
        private float M41;
        private float M42;
        private float M43;
        private float M44;

        public Matrix(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
        {
            M11 = row1.X;
            M12 = row1.Y;
            M13 = row1.Z;
            M14 = row1.W;
            M21 = row2.X;
            M22 = row2.Y;
            M23 = row2.Z;
            M24 = row2.W;
            M31 = row3.X;
            M32 = row3.Y;
            M33 = row3.Z;
            M34 = row3.W;
            M41 = row4.X;
            M42 = row4.Y;
            M43 = row4.Z;
            M44 = row4.W;
        }

        public Matrix(float m11, float m12, float m13, float m14, 
                      float m21, float m22, float m23, float m24, 
                      float m31, float m32, float m33, float m34, 
                      float m41, float m42, float m43, float m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;
            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;
            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public bool Equals(Matrix other)
        {
            throw new NotImplementedException();
        }
    }
}
