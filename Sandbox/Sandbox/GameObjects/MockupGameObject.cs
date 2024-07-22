

using CoreKitEngine.Engine.GameObjects;
using Microsoft.Xna.Framework;

namespace Sandbox.GameObjects
{
    internal class MockupGameObject : GameObject
    {
        public MockupGameObject() 
        {
        }

        public void UpdatePos()
        {
            this.Position = new Vector2(Position.X + 10, Position.Y);
        }

        public virtual void Update(GameTime oGameTime)
        {
        }
    }
}
