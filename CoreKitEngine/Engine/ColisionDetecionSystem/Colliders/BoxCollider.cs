using Microsoft.Xna.Framework;

namespace CoreKitEngine.Engine.ColliderSystem.Colliders
{
    public class BoxCollider
    {
        public Rectangle Collider
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }
        public Vector2 Position { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public BoxCollider(Vector2 oPosition, int nWidht, int nHeight)
        {
            this.Position = oPosition;
            this.Width = nWidht;
            this.Height = nHeight;
        }

        public bool IsCollidingWith(BoxCollider oOtherBoxColider)
        {
            if (Position.X < oOtherBoxColider.Position.X + oOtherBoxColider.Width &&
                Position.X + Width > oOtherBoxColider.Position.X &&
                Position.Y < oOtherBoxColider.Position.Y + oOtherBoxColider.Height &&
                Position.Y + Height > oOtherBoxColider.Position.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
