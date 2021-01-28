using System.Collections.Generic;
using BlazorGame.Framework;
using BlazorGame.Framework.Graphics;

namespace BlazorGame.Client.Shared.Breakout
{
    public interface IPhysics2D
    {
        Texture2D Sprite { get; }
        Rectangle Bounds { get; set; }
        Vector2 Position { get; }
        Vector2 Offset {get;}
        List<IPhysics2D> Colliders { get; }

        void HasCollided(IPhysics2D collider);

        void CalculateBounds()
        {
            var boundPos = Position - Offset;

            Bounds = new Rectangle((int)boundPos.X, (int)boundPos.Y, Sprite.Width, Sprite.Height);
        }
    }
}