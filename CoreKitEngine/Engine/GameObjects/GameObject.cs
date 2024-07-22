namespace CoreKitEngine.Engine.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameObject
    {
        private Vector2 m_oDirection;
        public Vector2 Position { get; set; } = Vector2.Zero;
        protected float Velocity { get; set; }
        public Texture2D Texture { protected get; set; }

        public GameObject()
        {
        }

        public virtual void Update(GameTime oGameTime)
        {

        }

        public virtual void Draw(SpriteBatch oSpriteBatch)
        {
            oSpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
