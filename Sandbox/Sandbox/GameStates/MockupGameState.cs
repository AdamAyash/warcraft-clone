namespace Sandbox.GameStates
{
    using CoreKitEngine.Engine.EventSystem;
    using CoreKitEngine.Engine.EventSystem.CommonEventImplementations;
    using CoreKitEngine.Engine.EventSystem.EventHandler;
    using CoreKitEngine.Engine.InputManager;
    using CoreKitEngine.Engine.StateSystem;
    using CoreKitEngine.Engine.Utilities;
    using CoreKitEngine.EventSystem.CommonEventImplementations;
    using GameObjects;
    using InputManager.InputMappers;
    using Microsoft.Xna.Framework;

    public class MockupGameState : BaseGameState
    {
        SelectionBox selectionBox;
        Unit unit = new Unit();

        public void MockupCallback(KeyDownEvent mockupEvent)
        {
        }

        public void MockupCallback1(LeftMouseButtonPressedEvent mockupEvent)
        {
            selectionBox.UpdateSelectionBoxEndPoint(mockupEvent.MousePosition);

            unit.isMoving = true;
            unit.NewPosition = mockupEvent.MousePosition.ConvertToVector2();

        }

        public void MockupCallback2(LeftMouseButtonReleasedEvent mockupEvent)
        {
            selectionBox.Reset();
        }

        public override void LoadContent()
        {
            ISmartEventHandler smartEventHandler = new SmartEventHandler<KeyDownEvent>();
            smartEventHandler.AddMethod<KeyDownEvent>(MockupCallback);


           ISmartEventHandler smartEventHandler1 = new SmartEventHandler<LeftMouseButtonPressedEvent>();
            smartEventHandler1.AddMethod<LeftMouseButtonPressedEvent>(MockupCallback1);

            ISmartEventHandler smartEventHandler2 = new SmartEventHandler<LeftMouseButtonReleasedEvent>();
            smartEventHandler2.AddMethod<LeftMouseButtonReleasedEvent>(MockupCallback2);

            RegisterEventHandler(EventTypeRegister.KeyDownEvent, smartEventHandler);
            RegisterEventHandler(EventTypeRegister.LeftMouseButtonPressedEvent, smartEventHandler1);
            RegisterEventHandler(EventTypeRegister.LeftMouseButtonReleasedEvent, smartEventHandler2);

            selectionBox = new SelectionBox();
            selectionBox.Texture = Utilities.GenerateTexture(GraphicsDevice, 2, 2, Color.LightGreen);

            RegisterGameObject(selectionBox);

            unit.Texture = LoadTexture2D("test");
            RegisterGameObject(unit);
        }

        protected override InputManager InitializeInputManager()
        {
           return new InputManager(new SandboxInputMapper());
        }
    }
}
