namespace Sandbox.GameObjects
{
    using CoreKitEngine.Engine.GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SelectionBox : GameObject
    {
        private readonly int DEFAULT_SELECTION_BOX_WIDTH = 0;
        private readonly int DEFAULT_SELECTION_BOX_HEIGHT = 0;

        private readonly Point DEFAULT_SELECTION_BOX_POSITION = new Point(-1, -1);

        private Point m_oSelectionBoxStartPosition;
        private Point m_oSelectionBoxEndPosition;

        private int m_nSelectionBoxCalculatedWidth;
        private int m_nSelectionBoxCalculatedHeight;

        public bool IsActivated { get; private set; }

        public SelectionBox()
        {
            Reset();
        }

        public void Reset()
        {
            this.IsActivated = false;

            m_oSelectionBoxStartPosition = DEFAULT_SELECTION_BOX_POSITION;
            m_oSelectionBoxEndPosition = DEFAULT_SELECTION_BOX_POSITION;
        }

        public void UpdateSelectionBoxEndPoint(Point mouseCoordinates)
        {
            if (!IsActivated)
            {
                m_oSelectionBoxStartPosition = mouseCoordinates;
                IsActivated = true;
            }

            m_oSelectionBoxEndPosition = mouseCoordinates;
        }

        private void CalculateSelectionBoxDimensions()
        {
            Point oCalculatedDifference = m_oSelectionBoxEndPosition - m_oSelectionBoxStartPosition;

            m_nSelectionBoxCalculatedWidth = m_oSelectionBoxStartPosition.X + oCalculatedDifference.X;
            m_nSelectionBoxCalculatedHeight = m_oSelectionBoxStartPosition.Y + oCalculatedDifference.Y;
        }

        public override void Update(GameTime oGameTime)
        {
            this.CalculateSelectionBoxDimensions();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActivated)
                return;

            for (int index = (int)m_oSelectionBoxStartPosition.X; index <= m_nSelectionBoxCalculatedWidth; index++)
            {
                spriteBatch.Draw(Texture, new Vector2(index, m_oSelectionBoxStartPosition.Y), Color.White);
                spriteBatch.Draw(Texture, new Vector2(index, m_nSelectionBoxCalculatedHeight), Color.White);
            }

            for (int index = (int)m_oSelectionBoxStartPosition.Y; index <= m_nSelectionBoxCalculatedHeight; index++)
            {
                spriteBatch.Draw(Texture, new Vector2(m_oSelectionBoxStartPosition.X, index), Color.White);
                spriteBatch.Draw(Texture, new Vector2(m_nSelectionBoxCalculatedWidth, index), Color.White);
            }

            for (int index = (int)m_oSelectionBoxStartPosition.X; index >= m_nSelectionBoxCalculatedWidth; index--)
            {
                spriteBatch.Draw(Texture, new Vector2(index, m_oSelectionBoxStartPosition.Y), Color.White);
                spriteBatch.Draw(Texture, new Vector2(index, m_nSelectionBoxCalculatedHeight), Color.White);
            }

            for (int index = (int)m_oSelectionBoxStartPosition.Y; index >= m_nSelectionBoxCalculatedHeight; index--)
            {
                spriteBatch.Draw(Texture, new Vector2(m_oSelectionBoxStartPosition.X, index), Color.White);
                spriteBatch.Draw(Texture, new Vector2(m_nSelectionBoxCalculatedWidth, index), Color.White);
            }
        }
    }
}
