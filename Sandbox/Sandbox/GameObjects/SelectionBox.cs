namespace Sandbox.GameObjects
{
    using CoreKitEngine.Engine.GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SelectionBox : GameObject
    {
        private Point startingPoint;
        private Point difference;

        public bool IsActivated { get; set; }
        public SelectionBox()
        {
            this.IsActivated = false;
        }

        public void SetCoordinates(Point mouseCoordinates)
        {
            if (!IsActivated)
            {
                startingPoint = mouseCoordinates;
                IsActivated = true;
            }

            difference = mouseCoordinates;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsActivated)
            {
                Point a = difference - startingPoint;

                for (int index = (int)startingPoint.X; index <= startingPoint.X + a.X; index++)
                {
                    spriteBatch.Draw(Texture, new Vector2(index, startingPoint.Y), Color.White);
                }

                for (int index = (int)startingPoint.Y; index <= startingPoint.Y + a.Y; index++)
                {
                    spriteBatch.Draw(Texture, new Vector2(startingPoint.X, index), Color.White);
                }

                for (int index = (int)startingPoint.X; index <= startingPoint.X + a.X; index++)
                {
                    spriteBatch.Draw(Texture, new Vector2(index, startingPoint.Y + a.Y), Color.White);
                }

                for (int index = (int)startingPoint.Y; index <= startingPoint.Y + a.Y; index++)
                {
                    spriteBatch.Draw(Texture, new Vector2(startingPoint.X + a.X, index), Color.White);
                }

                for (int index = (int)startingPoint.X; index >= startingPoint.X + a.X; index--)
                {
                    spriteBatch.Draw(Texture, new Vector2(index, startingPoint.Y), Color.White);
                }

                for (int index = (int)startingPoint.Y; index >= startingPoint.Y + a.Y; index--)
                {
                    spriteBatch.Draw(Texture, new Vector2(startingPoint.X, index), Color.White);
                }

                for (int index = (int)startingPoint.X; index >= startingPoint.X + a.X; index--)
                {
                    spriteBatch.Draw(Texture, new Vector2(index, startingPoint.Y + a.Y), Color.White);
                }

                for (int index = (int)startingPoint.Y; index >= startingPoint.Y + a.Y; index--)
                {
                    spriteBatch.Draw(Texture, new Vector2(startingPoint.X + a.X, index), Color.White);
                }
            }

        }
    }
}
