using System;
using System.Numerics;

namespace BlazorGame.Framework
{
    public struct Matrix2 : IEquatable<Matrix2>
    {
        public float M11;
        public float M12;
        public float M21;
        public float M22;

        public Matrix2(float m11, float m12, float m21, float m22)
        {
            M11 = m11;
            M12 = m12;
            M21 = m21;
            M22 = m22;
        }

        public float Determinant()
        {
            return (M11 * M22) - (M12 * M21);
        }

        public bool Equals(Matrix2 other)
        {
            throw new NotImplementedException();
        }
    }

    public struct Matrix3 : IEquatable<Matrix3>
    {
        public float M11;
        public float M12;
        public float M13;
        public float M21;
        public float M22;
        public float M23;
        public float M31;
        public float M32;
        public float M33;

        public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        public float Determinant()
        {
            return +(M11 * new Matrix2(M22, M23, M32, M33).Determinant())
            - (M12 * new Matrix2(M21, M23, M31, M33).Determinant())
            + (M13 * new Matrix2(M21, M22, M31, M32).Determinant());
        }

        public bool Equals(Matrix3 other)
        {
            throw new NotImplementedException();
        }
    }

    public struct Matrix : IEquatable<Matrix>
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        public Vector3 Backward { get; set; }
        public Vector3 Down { get; set; }
        public Vector3 Forward { get; set; }
        public Vector3 Left { get; set; }
        public Vector3 Right { get; set; }
        public Vector3 Translation { get; set; }
        public static Matrix Identity { get; }
        public Vector3 Up { get; set; }
        public float this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public float this[int row, int column]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

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

            Backward = new Vector3();
            Forward = new Vector3();
            Left = new Vector3();
            Right = new Vector3();
            Up = new Vector3();
            Down = new Vector3();
            Translation = new Vector3();
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

            Backward = new Vector3();
            Forward = new Vector3();
            Left = new Vector3();
            Right = new Vector3();
            Up = new Vector3();
            Down = new Vector3();
            Translation = new Vector3();
        }

        public static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static void Add(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3? cameraForwardVector)
        {
            throw new NotImplementedException();
        }

        public static void CreateBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, Vector3? cameraForwardVector, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector)
        {
            throw new NotImplementedException();
        }

        public static void CreateConstrainedBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 rotateAxis, Vector3? cameraForwardVector, Vector3? objectForwardVector, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateFromAxisAngle(Vector3 axis, float angle)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateFromQuaternion(Quaternion quaternion)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            throw new NotImplementedException();
        }

        public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            throw new NotImplementedException();
        }

        public static void CreateLookAt(ref Vector3 cameraPosition, ref Vector3 cameraTarget, ref Vector3 cameraUpVector, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane)
        {
            throw new NotImplementedException();
        }

        public static void CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateOrthographicOffCenter(Rectangle viewingVolume, float zNearPlane, float zFarPlane)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane)
        {
            throw new NotImplementedException();
        }

        public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance)
        {
            throw new NotImplementedException();
        }

        public static void CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            throw new NotImplementedException();
        }

        public static void CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreatePerspectiveOffCenter(Rectangle viewingVolume, float nearPlaneDistance, float farPlaneDistance)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float nearPlaneDistance, float farPlaneDistance)
        {
            throw new NotImplementedException();
        }

        public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float nearPlaneDistance, float farPlaneDistance, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateReflection(Plane value)
        {
            throw new NotImplementedException();
        }

        public static void CreateReflection(ref Plane value, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateRotationX(float radians)
        {
            throw new NotImplementedException();
        }

        public static void CreateRotationX(float radians, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateRotationY(float radians)
        {
            throw new NotImplementedException();
        }

        public static void CreateRotationY(float radians, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateRotationZ(float radians)
        {
            throw new NotImplementedException();
        }

        public static void CreateRotationZ(float radians, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateScale(Vector3 scales)
        {
            return new Matrix(scales.X, 0, 0, 0, 0, scales.Y, 0, 0, 0, 0, scales.Z, 0, 0, 0, 0, 0);
        }

        public static void CreateScale(ref Vector3 scales, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateScale(float scale)
        {
            throw new NotImplementedException();
        }

        public static void CreateScale(float scale, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateScale(float xScale, float yScale, float zScale)
        {
            throw new NotImplementedException();
        }

        public static void CreateScale(float xScale, float yScale, float zScale, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateShadow(Vector3 lightDirection, Plane plane)
        {
            throw new NotImplementedException();
        }

        public static void CreateShadow(ref Vector3 lightDirection, ref Plane plane, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateTranslation(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public static void CreateTranslation(ref Vector3 position, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateTranslation(float xPosition, float yPosition, float zPosition)
        {
            throw new NotImplementedException();
        }

        public static void CreateTranslation(float xPosition, float yPosition, float zPosition, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
        {
            throw new NotImplementedException();
        }

        public static void CreateWorld(ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        {
            throw new NotImplementedException();
        }

        public float Determinant()
        {
            return +(M11 * new Matrix3(M22, M23, M24, M32, M33, M34, M42, M43, M44).Determinant())
             - (M12 * new Matrix3(M21, M23, M24, M31, M33, M34, M41, M43, M44).Determinant())
             + (M13 * new Matrix3(M21, M22, M24, M31, M32, M34, M41, M42, M44).Determinant())
             - (M14 * new Matrix3(M21, M22, M23, M31, M32, M33, M41, M42, M43).Determinant());
        }

        public static Matrix Divide(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix Divide(Matrix matrix1, float divider)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Matrix matrix1, float divider, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Matrix other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static Matrix Invert(Matrix matrix)
        {
            return 1 / matrix.Determinant() * Adjugate(matrix);
        }

        public static Matrix Adjugate(Matrix matrix)
        {
            return Transpose(Cofactor(matrix));
        }

        public static Matrix Cofactor(Matrix matrix)
        {
            return new Matrix(
                new Matrix3(matrix.M22, matrix.M23, matrix.M24, matrix.M32, matrix.M33, matrix.M34, matrix.M42, matrix.M43, matrix.M44).Determinant(),
                -new Matrix3(matrix.M21, matrix.M23, matrix.M24, matrix.M31, matrix.M33, matrix.M34, matrix.M41, matrix.M43, matrix.M44).Determinant(),
                new Matrix3(matrix.M21, matrix.M22, matrix.M24, matrix.M31, matrix.M32, matrix.M34, matrix.M41, matrix.M42, matrix.M44).Determinant(),
                -new Matrix3(matrix.M21, matrix.M22, matrix.M23, matrix.M31, matrix.M32, matrix.M33, matrix.M41, matrix.M42, matrix.M43).Determinant(),

                -new Matrix3(matrix.M12, matrix.M13, matrix.M14, matrix.M32, matrix.M33, matrix.M34, matrix.M42, matrix.M43, matrix.M44).Determinant(),
                new Matrix3(matrix.M11, matrix.M13, matrix.M14, matrix.M31, matrix.M33, matrix.M34, matrix.M41, matrix.M43, matrix.M44).Determinant(),
                -new Matrix3(matrix.M11, matrix.M12, matrix.M14, matrix.M31, matrix.M32, matrix.M34, matrix.M41, matrix.M42, matrix.M44).Determinant(),
                new Matrix3(matrix.M11, matrix.M12, matrix.M13, matrix.M31, matrix.M32, matrix.M33, matrix.M41, matrix.M42, matrix.M43).Determinant(),

                new Matrix3(matrix.M12, matrix.M13, matrix.M14, matrix.M22, matrix.M23, matrix.M24, matrix.M42, matrix.M43, matrix.M44).Determinant(),
                -new Matrix3(matrix.M11, matrix.M13, matrix.M14, matrix.M21, matrix.M23, matrix.M24, matrix.M41, matrix.M43, matrix.M44).Determinant(),
                new Matrix3(matrix.M11, matrix.M12, matrix.M14, matrix.M21, matrix.M22, matrix.M24, matrix.M41, matrix.M42, matrix.M44).Determinant(),
                -new Matrix3(matrix.M11, matrix.M12, matrix.M13, matrix.M21, matrix.M22, matrix.M23, matrix.M41, matrix.M42, matrix.M43).Determinant(),

                -new Matrix3(matrix.M12, matrix.M13, matrix.M14, matrix.M22, matrix.M23, matrix.M24, matrix.M32, matrix.M33, matrix.M34).Determinant(),
                new Matrix3(matrix.M11, matrix.M13, matrix.M14, matrix.M21, matrix.M23, matrix.M24, matrix.M31, matrix.M33, matrix.M34).Determinant(),
                -new Matrix3(matrix.M11, matrix.M12, matrix.M14, matrix.M21, matrix.M22, matrix.M24, matrix.M31, matrix.M32, matrix.M34).Determinant(),
                new Matrix3(matrix.M11, matrix.M12, matrix.M13, matrix.M21, matrix.M22, matrix.M23, matrix.M31, matrix.M32, matrix.M33).Determinant()
            );
        }

        public static void Invert(ref Matrix matrix, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix Lerp(Matrix matrix1, Matrix matrix2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Lerp(ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix Multiply(Matrix matrix1, float scaleFactor)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Matrix matrix1, float scaleFactor, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix Negate(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static void Negate(ref Matrix matrix, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static void Subtract(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static float[] ToFloatArray(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public static Matrix Transpose(Matrix matrix)
        {
            return new Matrix(matrix.M11, matrix.M21, matrix.M31, matrix.M41,
                              matrix.M12, matrix.M22, matrix.M32, matrix.M42,
                              matrix.M13, matrix.M23, matrix.M33, matrix.M43,
                              matrix.M14, matrix.M24, matrix.M34, matrix.M44);
        }

        public static void Transpose(ref Matrix matrix, out Matrix result)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator *(float scaleFactor, Matrix matrix)
        {
            return matrix * scaleFactor;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator /(Matrix matrix, float divider)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator *(Matrix matrix, float scaleFactor)
        {
            return new Matrix(
                matrix.M11 * scaleFactor,
                matrix.M12 * scaleFactor,
                matrix.M13 * scaleFactor,
                matrix.M14 * scaleFactor,
                matrix.M21 * scaleFactor,
                matrix.M22 * scaleFactor,
                matrix.M23 * scaleFactor,
                matrix.M24 * scaleFactor,
                matrix.M31 * scaleFactor,
                matrix.M32 * scaleFactor,
                matrix.M33 * scaleFactor,
                matrix.M34 * scaleFactor,
                matrix.M41 * scaleFactor,
                matrix.M42 * scaleFactor,
                matrix.M43 * scaleFactor,
                matrix.M44 * scaleFactor                                
            );
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator -(Matrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
