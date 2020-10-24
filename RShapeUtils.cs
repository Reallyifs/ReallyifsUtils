using Microsoft.Xna.Framework;

namespace ReallyifsUtils
{
    public static class RShapeUtils
    {
        public static Rectangle GetRectangle(Vector2 position, Vector2 size)
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
    }
}