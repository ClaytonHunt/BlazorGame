using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorGame.Library.Graphics
{
    public class SpriteFont
    {
        public IReadOnlyCollection<char> Characters { get; }
        public char? DefaultCharacter { get; set; }
        public Glyph[] Glyphs { get; }
        public int LineSpacing { get; set; }
        public float Spacing { get; set; }
        public Texture2D Texture { get; }

        public SpriteFont(
            Texture2D texture, 
            List<Rectangle> glyphBounds, 
            List<Rectangle> cropping, 
            List<char> characters, 
            int lineSpacing, 
            float spacing, 
            List<Vector3> kerning, 
            char? defaultCharacter)
        {
            Characters = characters;
            DefaultCharacter = defaultCharacter;
            Texture = texture;
        }

        public Dictionary<char, Glyph> GetGlyphs()
        {
            // TODO: Build and return Glyphs
            return new Dictionary<char, Glyph>();
        }

        public Vector2 MeasureString(string text)
        {
            // TODO: Determine proper calculation
            return Vector2.Zero;
        }

        public Vector2 MeasureString(StringBuilder text)
        {
            // TODO: Determine proper calculation
            return Vector2.Zero;
        }

        public struct Glyph
        {
            public Rectangle BoundsInTexture;
            public char Character;
            public Rectangle Cropping;
            public static readonly Glyph Empty;
            public float LeftSideBearing;
            public float rightSideBearing;
            public float Width;
            public float widthIncludingBearings;

            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
}
