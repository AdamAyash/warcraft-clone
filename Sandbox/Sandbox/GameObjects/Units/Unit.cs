namespace Sandbox.GameObjects
{
    using CoreKitEngine.Engine.GameObjects;
    using Microsoft.Xna.Framework;

    public class Unit : GameObject
    {
        private const float STOP_MOVING_TOLERANCE = 0.5f;

        public bool isMoving { get; set; } = false;
        public Vector2 NewPosition { get; set; } = Vector2.Zero;
        protected bool IsSelected { get; set; } = true;
        protected float Velocity { get; set; } = 50f;

        public Unit()
        {
        }

        public override void Update(GameTime oGameTime)
        {

            if (isMoving)
                UpdatePosition(oGameTime);

        }

        private void UpdatePosition(GameTime oGameTime)
        {
            Vector2 oDirection = NewPosition - Position;

            if (oDirection.Length() <= STOP_MOVING_TOLERANCE)
                isMoving = false;
           
            oDirection.Normalize();
            Position += oDirection * Velocity *  (float)oGameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
