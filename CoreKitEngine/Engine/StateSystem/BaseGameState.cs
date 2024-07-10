namespace CoreKitEngine.Engine.StateSystem
{
    using CoreKitEngine.Engine.LogSystem;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class BaseGameState
    {
        private ILoggerService m_LoggerService;
        private ContentManager m_ContentManager;

        public BaseGameState()
        {
            m_LoggerService = Logger.GetLoggerInstance();
        }

        public virtual void Initialize(ContentManager contentManager)
        {
            m_ContentManager = contentManager;
        }

        protected Texture2D LoadTexture2D(string textureName)
        {
            return m_ContentManager.Load<Texture2D>(textureName);
        }
        public abstract void LoadContent();

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spiteBatch)
        {
        }
    }
}
