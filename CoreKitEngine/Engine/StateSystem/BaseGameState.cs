namespace CoreKitEngine.Engine.StateSystem
{
    using CoreKitEngine.Engine.EventSystem;
    using CoreKitEngine.Engine.EventSystem.EventHandler;
    using CoreKitEngine.Engine.GameObjects;
    using CoreKitEngine.Engine.LogSystem;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using CoreKitEngine.Engine.InputManager;
    using Microsoft.Xna.Framework.Input;

    public abstract class BaseGameState
    {
        private ContentManager m_oContentManager;
        private EventManager m_oEventManager;
        private InputManager m_oInputManager;
        protected GraphicsDevice GraphicsDevice { get; private set; }
        protected ILoggerService m_oLoggerService;

        private List<GameObject> m_oGameObjectsList;

        public BaseGameState()
        {
            m_oLoggerService = Logger.GetLoggerInstance();
            m_oGameObjectsList = new List<GameObject>();
        }

        ~BaseGameState()
        {
            CleanStateResources();
        }

        public virtual void Initialize(ContentManager oContentManager, EventManager oEventManager, GraphicsDevice oGraphicsDevice)
        {
            this.m_oContentManager = oContentManager;
            this.m_oEventManager = oEventManager;
            this.m_oInputManager = InitializeInputManager();
            this.GraphicsDevice = oGraphicsDevice;
        }

        protected virtual void HandleInput()
        {
           RegisterEvent(m_oInputManager.GetKeyboardInputEvent(Keyboard.GetState()));
           RegisterEvent(m_oInputManager.GetMouseInputEvent(Mouse.GetState()));
        }

        protected Texture2D LoadTexture2D(string strTextureName)
        {
            return m_oContentManager.Load<Texture2D>(strTextureName);
        }

        protected void RegisterGameObject(GameObject oGameObject)
        {
            this.m_oGameObjectsList.Add(oGameObject);
        }

        protected void RegisterEvent(Event oEvent)
        {
            m_oEventManager.RegisterEvent(oEvent);
        }

        protected bool RegisterEventHandler(EventTypeRegister eEventType, ISmartEventHandler oEventHandler)
        {
            return m_oEventManager.RegisterEventHandler(eEventType, oEventHandler);
        }

        protected bool RemoveGameObject(GameObject oGameObject)
        {
            return this.m_oGameObjectsList.Remove(oGameObject);
        }

        protected virtual  void CleanStateResources()
        {
            m_oContentManager.Unload();
        }

        public abstract void LoadContent();

        protected abstract InputManager InitializeInputManager();
      
        public virtual void Update(GameTime oGameTime)
        {
            HandleInput();
            m_oGameObjectsList.ForEach(gameobject => gameobject.Update(oGameTime));
        }

        public virtual void Draw(SpriteBatch oSpiteBatch)
        {
            m_oGameObjectsList.ForEach(gameobject => gameobject.Draw(oSpiteBatch));
        }
    }
}