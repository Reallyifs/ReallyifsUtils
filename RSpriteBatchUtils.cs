using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;

namespace ReallyifsUtils
{
    public static class RSpriteBatchUtils
    {
        private static Point MousePoint => new Point(Main.mouseX, Main.mouseY);

        public delegate object FiveStringDelegate(ref DynamicSpriteFont font, ref string text, ref Vector2 position, ref Color[] textColors,
            ref Vector2 origin, ref float scale);

        /// <summary>
        /// 调用 <see cref="Utils.DrawBorderStringFourWay(SpriteBatch, DynamicSpriteFont, string, float, float, Color, Color, Vector2, float)"/>
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="textColor"></param>
        /// <param name="hideColor"></param>
        /// <param name="origin"></param>
        /// <param name="scale"></param>
        /// <param name="ifMouseIn">如不为 <see langword="null"/>，则在鼠标移入此字段判定面积时 Invoke</param>
        public static object DrawFiveString(this SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position,
            Color textColor, Color hideColor, Vector2 origin, float scale = 1f, FiveStringDelegate ifMouseIn = null)
        {
            Color[] textColors = new Color[]
            {
                textColor,
                hideColor
            };
            object result = null;
            if (RShapeUtils.GetRectangle(position, font.MeasureString(text)).Contains(MousePoint))
                result = ifMouseIn(ref font, ref text, ref position, ref textColors, ref origin, ref scale);
            Utils.DrawBorderStringFourWay(spriteBatch, font, text, position.X, position.Y, textColors[0], textColors[1], origin, scale);
            return result;
        }

        public static void SafeSpriteBatch(ref SpriteBatch spriteBatch, Action<SpriteBatch> action)
        {
            SpriteBatch defaultSpriteBatch = spriteBatch;
            try
            {
                spriteBatch.End();
            }
            finally
            {
                spriteBatch.Begin();
            }
            action(spriteBatch);
            spriteBatch = defaultSpriteBatch;
        }

        public static void SafeSpriteBatch(Action<SpriteBatch> action)
        {
            SpriteBatch defaultSB = Main.spriteBatch;
            try
            {
                Main.spriteBatch.End();
            }
            finally
            {
                Main.spriteBatch.Begin();
            }
            action(Main.spriteBatch);
            Main.spriteBatch = defaultSB;
        }
    }
}