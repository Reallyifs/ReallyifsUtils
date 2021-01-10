using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;

namespace ReallyifsUtils
{
    public static class RDrawUtils
    {
        private static Point MousePoint => new Point(Main.mouseX, Main.mouseY);

        /// <summary>
        /// 配合 <see cref="DrawFiveString(SpriteBatch, DynamicSpriteFont, string, Vector2, Color, Color, Vector2, float, DrawFiveStringMouseInDelegate)"/> 使用
        /// </summary>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="position">位置</param>
        /// <param name="textColor">文本颜色</param>
        /// <param name="hideColor">背景颜色</param>
        /// <param name="origin">偏移</param>
        /// <param name="scale">放大倍数</param>
        /// <returns>如果不返回东西，则返回 <see langword="null"/></returns>
        public delegate object DrawFiveStringMouseInDelegate(ref DynamicSpriteFont font, ref string text, ref Vector2 position,
            ref Color textColor, ref Color hideColor, ref Vector2 origin, ref float scale);

        /// <summary>
        /// 配合 <see cref="Draw(Rectangle, SpriteBatch, Color)"/> 使用
        /// </summary>
        /// <param name="rectangle">矩形</param>
        /// <param name="color">颜色</param>
        /// <returns>如果不返回东西，则返回 <see langword="null"/></returns>
        public delegate object DrawRectangleMouseInDelegate(ref Rectangle rectangle, ref Color color);

        /// <summary>
        /// 配合 <see cref="Draw(Vector2, SpriteBatch, Color, DrawVector2MouseInDelegate)"/> 使用
        /// </summary>
        /// <param name="position">点</param>
        /// <param name="color">颜色</param>
        /// <returns>如果不返回东西，则返回 <see langword="null"/></returns>
        public delegate object DrawVector2MouseInDelegate(ref Vector2 position, ref Color color);

        /// <summary>
        /// 调用 <see cref="SpriteBatch.Draw(Texture2D, Vector2, Rectangle?, Color, float, Vector2, float, SpriteEffects, float)"/>，其 texture 为 <see cref="Main.magicPixel"/>，scale 为 1f，其余皆为默认值
        /// </summary>
        /// <param name="position">点</param>
        /// <param name="spriteBatch">sb，可用 <see cref="Main.spriteBatch"/></param>
        /// <param name="color">颜色</param>
        /// <param name="ifMouseIn">如不为 <see langword="null"/>，则在鼠标移入此点判定面积时 Invoke</param>
        /// <returns>如果 <paramref name="ifMouseIn"/> 被调用，则返回其返回的值，否则为 <see langword="null"/></returns>
        public static object Draw(this Vector2 position, SpriteBatch spriteBatch, Color color, DrawVector2MouseInDelegate ifMouseIn = null)
        {
            object result = null;
            if (RShapeUtils.GetRectangle(position, new Vector2(1, 1)).Contains(MousePoint) && ifMouseIn != null)
                result = ifMouseIn(ref position, ref color);
            spriteBatch.Draw(Main.magicPixel, position - Main.screenPosition, null, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            return result;
        }

        /// <summary>
        /// 调用 <see cref="Utils.DrawRect(SpriteBatch, Vector2, Vector2, Vector2, Vector2, Color)"/>
        /// </summary>
        /// <param name="rectangle">矩形</param>
        /// <param name="spriteBatch">sb，可用 <see cref="Main.spriteBatch"/></param>
        /// <param name="color">颜色</param>
        /// <param name="ifMouseIn">如不为 <see langword="null"/>，则在鼠标移入此矩形判定面积时 Invoke</param>
        /// <returns>如果 <paramref name="ifMouseIn"/> 被调用，则返回其返回的值，否则为 <see langword="null"/></returns>
        public static object Draw(this Rectangle rectangle, SpriteBatch spriteBatch, Color color, DrawRectangleMouseInDelegate ifMouseIn = null)
        {
            object result = null;
            if (rectangle.Contains(MousePoint) && ifMouseIn != null)
                result = ifMouseIn(ref rectangle, ref color);
            Utils.DrawRect(spriteBatch, rectangle.TopLeft(), rectangle.TopRight(), rectangle.BottomRight(), rectangle.BottomLeft(), color);
            return result;
        }

        /// <summary>
        /// 调用 <see cref="Utils.DrawBorderStringFourWay(SpriteBatch, DynamicSpriteFont, string, float, float, Color, Color, Vector2, float)"/>
        /// </summary>
        /// <param name="spriteBatch">sb，可用 <see cref="Main.spriteBatch"/></param>
        /// <param name="font">字体</param>
        /// <param name="text">文本</param>
        /// <param name="position">位置</param>
        /// <param name="textColor">文本颜色</param>
        /// <param name="hideColor">背景颜色</param>
        /// <param name="origin">偏移</param>
        /// <param name="scale">放大倍数</param>
        /// <param name="ifMouseIn">如不为 <see langword="null"/>，则在鼠标移入此字段判定面积时 Invoke</param>
        /// <returns>如果 <paramref name="ifMouseIn"/> 被调用，则返回其返回的值，否则为 <see langword="null"/></returns>
        public static object DrawFiveString(this SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position,
            Color textColor, Color hideColor, Vector2 origin, float scale = 1f, DrawFiveStringMouseInDelegate ifMouseIn = null)
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
            action?.Invoke(spriteBatch);
            spriteBatch.End();
            if (sureEnd)
                spriteBatch.Begin();
        }

        /// <summary>
        /// 调用 <see cref="SafeSpriteBatch(SpriteBatch, Action{SpriteBatch}, SpriteSortMode, BlendState)"/>，其 spriteBatch 为 <see cref="Main.spriteBatch"/>
        /// </summary>
        /// <param name="action"></param>
        /// <param name="sortMode"></param>
        /// <param name="blendState"></param>
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
            action?.Invoke(Main.spriteBatch);
            Main.spriteBatch.End();
            if (sureEnd)
                Main.spriteBatch.Begin();
        }
    }
}