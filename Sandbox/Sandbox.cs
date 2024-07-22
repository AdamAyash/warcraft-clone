
namespace Sandbox
{
    using CoreKitEngine.Engine.StateSystem;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using GameStates;
    using CoreKitEngine.Engine.EventSystem;

    public class Sandbox : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private BaseGameState m_currentGameState;
        private EventManager m_oEventManager;

        public Sandbox()
        {
            _graphics = new GraphicsDeviceManager(this);
            m_currentGameState = new MockupGameState();
            m_oEventManager = new EventManager();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            m_currentGameState.Initialize(Content, m_oEventManager, GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            m_currentGameState.LoadContent();
        }

        protected override void Update(GameTime oGameTime)
        {
            m_oEventManager.DispatchEvents();
            m_currentGameState.Update(oGameTime);

            base.Update(oGameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            m_currentGameState.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
