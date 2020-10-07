using System;

namespace BlazorGame.Library
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(Vector2 value, float z)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
        }

        public Vector3(float value)
        {
            X = Y = Z = value;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Vector3 other)
        {
            throw new NotImplementedException();
        }
    }

    public struct Color : IEquatable<Color>
    {
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }


        public Color(Color color, int alpha)
        {
            R = color.R;
            B = color.B;
            G = color.G;
            A = (byte)alpha;
        }

        public Color(Color color, float alpha)
        {
            R = color.R;
            B = color.B;
            G = color.G;
            A = (byte)(255 * alpha);
        }

        public Color(Vector3 color)
        {
            R = (byte)color.X;
            B = (byte)color.Y;
            G = (byte)color.Z;
            A = 255;
        }

        public Color(Vector4 color)
        {
            R = (byte)color.X;
            B = (byte)color.Y;
            G = (byte)color.Z;
            A = (byte)color.W;
        }

        public Color(byte r, byte g, byte b, byte alpha)
        {
            R = r;
            B = b;
            G = g;
            A = alpha;
        }

        public Color(int r, int g, int b)
        {
            R = (byte)r;
            B = (byte)b;
            G = (byte)g;
            A = 255;
        }

        public Color(int r, int g, int b, int alpha)
        {
            R = (byte)r;
            B = (byte)b;
            G = (byte)g;
            A = (byte)alpha;
        }

        public Color(float r, float g, float b)
        {
            R = (byte)(255 * r);
            B = (byte)(255 * b);
            G = (byte)(255 * g);
            A = 255;
        }

        public Color(float r, float g, float b, float alpha)
        {
            R = (byte)(255 * r);
            G = (byte)(255 * g);
            B = (byte)(255 * b);
            A = (byte)(255 * alpha);
        }

        public Color(uint packedValue)
        {
            R = (byte)(packedValue & 255);
            G = (byte)(packedValue & (255 << 8));
            B = (byte)(packedValue & (255 << 16));
            A = (byte)(packedValue & (255 << 24));
        }

        public bool Equals(Color other)
        {
            throw new NotImplementedException();
        }
    }
}
