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

        /// <summary>
        /// 配合 <see cref="DrawFiveString(SpriteBatch, DynamicSpriteFont, string, Vector2, Color, Color, Vector2, float, MouseInDelegate)"/> 使用
        /// </summary>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="position">位置</param>
        /// <param name="textColor">文本颜色</param>
        /// <param name="hideColor">背景颜色</param>
        /// <param name="origin">偏移</param>
        /// <param name="scale">放大倍数</param>
        /// <returns>如不返回东西，则返回 <see langword="null"/></returns>
        public delegate object MouseInDelegate(ref DynamicSpriteFont font, ref string text, ref Vector2 position, ref Color textColor,
            ref Color hideColor, ref Vector2 origin, ref float scale);

        /// <summary>
        /// 调用 <see cref="Utils.DrawBorderStringFourWay(SpriteBatch, DynamicSpriteFont, string, float, float, Color, Color, Vector2, float)"/>
        /// </summary>
        /// <param name="spriteBatch">sb</param>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="position">位置</param>
        /// <param name="textColor">文本颜色</param>
        /// <param name="hideColor">背景颜色</param>
        /// <param name="origin">偏移</param>
        /// <param name="scale">放大倍数</param>
        /// <param name="ifMouseIn">如不为 <see langword="null"/>，则在鼠标移入此字段判定面积时 Invoke</param>
        /// <returns>如 <paramref name="ifMouseIn"/> 被调用，则返回其返回的值，否则为 <see langword="null"/></returns>
        public static object DrawFiveString(this SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position,
            Color textColor, Color hideColor, Vector2 origin, float scale = 1f, MouseInDelegate ifMouseIn = null)
        {
            object result = null;
            if (RShapeUtils.GetRectangle(position, font.MeasureString(text)).Contains(MousePoint) && ifMouseIn != null)
                result = ifMouseIn(ref font, ref text, ref position, ref textColor, ref hideColor, ref origin, ref scale);
            Utils.DrawBorderStringFourWay(spriteBatch, font, text, position.X, position.Y, textColor, hideColor, origin, scale);
            return result;
        }

        public static void SafeSpriteBatch(SpriteBatch spriteBatch, Action<SpriteBatch> action,
            SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null)
        {
            bool sureEnd;
            try
            {
                spriteBatch.End();
                sureEnd = true;
            }
            catch { sureEnd = false; }
            spriteBatch.Begin(sortMode, blendState);
            action(spriteBatch);
            spriteBatch.End();
            if (sureEnd)
                spriteBatch.Begin();
        }

        public static void SafeSpriteBatch(Action<SpriteBatch> action, SpriteSortMode sortMode = SpriteSortMode.Deferred,
            BlendState blendState = null)
        {
            bool sureEnd;
            try
            {
                Main.spriteBatch.End();
                sureEnd = true;
            }
            catch { sureEnd = false; }
            Main.spriteBatch.Begin(sortMode, blendState);
            action(Main.spriteBatch);
            Main.spriteBatch.End();
            if (sureEnd)
                Main.spriteBatch.Begin();
        }
    }
}