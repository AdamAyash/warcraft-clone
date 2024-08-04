namespace WarcraftClone.GameObjects
{
    using CoreKitEngine.Engine.ColliderSystem.Colliders;
    using CoreKitEngine.Engine.GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class SelectionBox : GameObject
    {

        private readonly Point DEFAULT_SELECTION_BOX_POSITION;

        private Point m_oSelectionBoxStartPosition;
        private Point m_oSelectionBoxEndPosition;

        private int m_nSelectionBoxCalculatedWidth;
        private int m_nSelectionBoxCalculatedHeight;

        public bool IsActivated { get; private set; }

        public SelectionBox()
        {
            AddBoxCollider(new BoxCollider(this.Position, m_nSelectionBoxCalculatedWidth, m_nSelectionBoxCalculatedHeight));
            Reset();
        }

        public void Reset()
        {
            this.IsActivated = false;

            m_oSelectionBoxStartPosition = DEFAULT_SELECTION_BOX_POSITION;
            m_oSelectionBoxEndPosition = DEFAULT_SELECTION_BOX_POSITION;
        }

        public void UpdateSelectionBoxEndPoint(Point oMouseCoordinates)
        {
            if (!IsActivated)
            {
                m_oSelectionBoxStartPosition = oMouseCoordinates;
                IsActivated = true;
            }

            m_oSelectionBoxEndPosition = oMouseCoordinates;
        }

        private void CalculateSelectionBoxDimensions()
        {
            Point oCalculatedDifference = m_oSelectionBoxEndPosition - m_oSelectionBoxStartPosition;

            m_nSelectionBoxCalculatedWidth = m_oSelectionBoxStartPosition.X + oCalculatedDifference.X;
            m_nSelectionBoxCalculatedHeight = m_oSelectionBoxStartPosition.Y + oCalculatedDifference.Y;
        }

        private void UpdatePosition()
        {
            if (m_oSelectionBoxStartPosition.X <= m_oSelectionBoxEndPosition.X)
                Position = new Vector2(m_oSelectionBoxStartPosition.X, Position.Y);
            else
                Position = new Vector2(m_oSelectionBoxEndPosition.X, Position.Y);

            if (m_oSelectionBoxStartPosition.Y <= m_oSelectionBoxEndPosition.Y)
                Position = new Vector2(Position.X, m_oSelectionBoxStartPosition.Y);
            else
                Position = new Vector2(Position.X, m_oSelectionBoxEndPosition.Y);
        }

        private void UpdateBoxColiderDimensions()
        {
            BoxColidersList.Value.ForEach(oColider =>
            {
                oColider.Width = Math.Abs(m_nSelectionBoxCalculatedWidth - m_oSelectionBoxStartPosition.X);
                oColider.Height = Math.Abs(m_nSelectionBoxCalculatedHeight - m_oSelectionBoxStartPosition.Y);
            });
        }

        public override void Update(GameTime oGameTime)
        {
            base.Update(oGameTime);

            this.CalculateSelectionBoxDimensions();
            this.UpdateBoxColiderDimensions();
            this.UpdatePosition();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActivated)
                return;

            for (int nIndex = (int)m_oSelectionBoxStartPosition.X; nIndex <= m_nSelectionBoxCalculatedWidth; nIndex++)
            {
                spriteBatch.Draw(Texture, new Vector2(nIndex, m_oSelectionBoxStartPosition.Y), Color.White);
                spriteBatch.Draw(Texture, new Vector2(nIndex, m_nSelectionBoxCalculatedHeight), Color.White);
            }

            for (int nIndex = (int)m_oSelectionBoxStartPosition.Y; nIndex <= m_nSelectionBoxCalculatedHeight; nIndex++)
            {
                spriteBatch.Draw(Texture, new Vector2(m_oSelectionBoxStartPosition.X, nIndex), Color.White);
                spriteBatch.Draw(Texture, new Vector2(m_nSelectionBoxCalculatedWidth, nIndex), Color.White);
            }

            for (int nIndex = (int)m_oSelectionBoxStartPosition.X; nIndex >= m_nSelectionBoxCalculatedWidth; nIndex--)
            {
                spriteBatch.Draw(Texture, new Vector2(nIndex, m_oSelectionBoxStartPosition.Y), Color.White);
                spriteBatch.Draw(Texture, new Vector2(nIndex, m_nSelectionBoxCalculatedHeight), Color.White);
            }

            for (int nIndex = (int)m_oSelectionBoxStartPosition.Y; nIndex >= m_nSelectionBoxCalculatedHeight; nIndex--)
            {
                spriteBatch.Draw(Texture, new Vector2(m_oSelectionBoxStartPosition.X, nIndex), Color.White);
                spriteBatch.Draw(Texture, new Vector2(m_nSelectionBoxCalculatedWidth, nIndex), Color.White);
            }
        }
    }
}
