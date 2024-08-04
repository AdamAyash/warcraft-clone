using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace CoreKitEngine.Engine.Utilities
{
    public static class Utilities
    {
        public static DateTime GetCurrentDateTime() => DateTime.Now;

        public static IEnumerable<EnumType> GetEnumValues<EnumType>()
            => Enum.GetValues(typeof(EnumType)).Cast<EnumType>();

        public static Texture2D GenerateTexture(GraphicsDevice oGraphicsDevice, short sWidth, short sHeight, Color eColor)
        {
            Texture2D oTexture2D = new Texture2D(oGraphicsDevice, sWidth, sHeight);

            int nColorDataArraySize = sWidth * sHeight;

            Color[] oColorDataArray = new Color[nColorDataArraySize];
            for(int nIndex = 0; nIndex < nColorDataArraySize; nIndex++)
            {
                oColorDataArray[nIndex] = eColor;
            }

            oTexture2D.SetData<Color>(oColorDataArray);

            return oTexture2D;
        }

        public static Vector2 ConvertToVector2(this Point oPoint)
        {
            return new Vector2(oPoint.X, oPoint.Y);
        }
    }
}
