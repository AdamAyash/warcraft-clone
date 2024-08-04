namespace CoreKitEngine.Engine.GameObjects
{
    using CoreKitEngine.Engine.ColliderSystem.Colliders;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameObject
    {
        private Vector2 m_oPosition;

        public Vector2 Position
        {
            get
            {
                return m_oPosition;
            }

            set
            {
                var deltaX = value.X - m_oPosition.X;
                var deltaY = value.Y - m_oPosition.Y;
                m_oPosition = value;

                BoxColidersList.Value.ForEach(colider =>
                {
                    colider.Position = new Vector2(colider.Position.X + deltaX, colider.Position.Y + deltaY);
                });
            }
        }

        public Texture2D Texture { protected get; set; }
        public Lazy<List<BoxCollider>> BoxColidersList { get; protected set; }

        public GameObject()
        {
            BoxColidersList = new Lazy<List<BoxCollider>>(() => new List<BoxCollider>());
        }

        public void AddBoxCollider(BoxCollider oBoxColider)
        {
            BoxColidersList.Value.Add(oBoxColider);
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
