using Microsoft.Xna.Framework;
using Terraria;

namespace ReallyifsUtils
{
    public static class RItemUtils
    {
        /// <summary>
        /// 将生成一个 <see cref="Item"/>，返回其在 <see cref="Main.item"/> 里的 index，将直接替换此 index 所属的 <see cref="Item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="rectangle">生成物品限制在此矩形内</param>
        /// <param name="stack">生成多少个</param>
        /// <param name="noBroadcast"></param>
        /// <param name="prefixGiven">给予前缀</param>
        /// <param name="noGrabDelay">没有拾起冷却</param>
        /// <param name="reverseLookup"></param>
        /// <returns>index</returns>
        public static int NewItem(this Item item, Rectangle rectangle, int stack = 1, bool noBroadcast = false, int prefixGiven = 0,
            bool noGrabDelay = false, bool reverseLookup = false)
        {
            int index = Item.NewItem(rectangle, item.type, stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
            Main.item[index] = item;
            return index;
        }

        /// <summary>
        /// 将生成一个 <see cref="Item"/>，返回其在 <see cref="Main.item"/> 里的 index，将直接替换此 index 所属的 <see cref="Item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position">在此 position 生成物品</param>
        /// <param name="stack">生成多少个</param>
        /// <param name="noBroadcast"></param>
        /// <param name="prefixGiven">给予前缀</param>
        /// <param name="noGrabDelay">没有拾起冷却</param>
        /// <param name="reverseLookup"></param>
        /// <returns>index</returns>
        public static int NewItem(this Item item, Vector2 position, int stack = 1, bool noBroadcast = false, int prefixGiven = 0,
            bool noGrabDelay = false, bool reverseLookup = false)
        {
            int index = Item.NewItem(position, item.type, stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
            Main.item[index] = item;
            return index;
        }

        /// <summary>
        /// 将生成一个 <see cref="Item"/>，返回其在 <see cref="Main.item"/> 里的 index，将直接替换此 index 所属的 <see cref="Item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position">在此 position 生成物品</param>
        /// <param name="size">在此 size 内生成物品</param>
        /// <param name="stack">生成多少个</param>
        /// <param name="noBroadcast"></param>
        /// <param name="prefixGiven">给予前缀</param>
        /// <param name="noGrabDelay">没有拾起冷却</param>
        /// <param name="reverseLookup"></param>
        /// <returns>index</returns>
        public static int NewItem(this Item item, Vector2 position, Vector2 size, int stack = 1, bool noBroadcast = false, int prefixGiven = 0,
            bool noGrabDelay = false, bool reverseLookup = false)
        {
            int index = Item.NewItem(position, size, item.type, stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
            Main.item[index] = item;
            return index;
        }

        /// <summary>
        /// 将生成一个 <see cref="Item"/>，返回其在 <see cref="Main.item"/> 里的 index，将直接替换此 index 所属的 <see cref="Item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position">在此 position 生成物品</param>
        /// <param name="width">生成物品时限制的长宽中的宽</param>
        /// <param name="height">生成物品时限制的长宽中的长</param>
        /// <param name="stack">生成多少个</param>
        /// <param name="noBroadcast"></param>
        /// <param name="prefixGiven">给予前缀</param>
        /// <param name="noGrabDelay">没有拾起冷却</param>
        /// <param name="reverseLookup"></param>
        /// <returns>index</returns>
        public static int NewItem(this Item item, Vector2 position, int width, int height, int stack = 1, bool noBroadcast = false,
            int prefixGiven = 0, bool noGrabDelay = false, bool reverseLookup = false)
        {
            int index = Item.NewItem(position, width, height, item.type, stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
            Main.item[index] = item;
            return index;
        }

        /// <summary>
        /// 将生成一个 <see cref="Item"/>，返回其在 <see cref="Main.item"/> 里的 index，将直接替换此 index 所属的 <see cref="Item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="positionX">生成物品时限制的位置中的X</param>
        /// <param name="positionY">生成物品时限制的位置中的Y</param>
        /// <param name="width">生成物品时限制的长宽中的宽</param>
        /// <param name="height">生成物品时限制的长宽中的长</param>
        /// <param name="stack">生成多少个</param>
        /// <param name="noBroadcast"></param>
        /// <param name="prefixGiven">给予前缀</param>
        /// <param name="noGrabDelay">没有拾起冷却</param>
        /// <param name="reverseLookup"></param>
        /// <returns>index</returns>
        public static int NewItem(this Item item, int positionX, int positionY, int width, int height, int stack = 1, bool noBroadcast = false,
            int prefixGiven = 0, bool noGrabDelay = false, bool reverseLookup = false)
        {
            int type = item.type;
            int index = Item.NewItem(positionX, positionY, width, height, type, stack, noBroadcast, prefixGiven, noGrabDelay, reverseLookup);
            Main.item[index] = item;
            return index;
        }

        /// <summary>
        /// 返回一个 <see cref="Item"/>，将直接调用 <see cref="Item.SetDefaults(int, bool)"/>，其 type 为 <paramref name="type"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="noMatCheck"></param>
        /// <returns></returns>
        public static Item ItemSetDefaults(this int type, bool noMatCheck = false)
        {
            Item item = new Item();
            item.SetDefaults(type, noMatCheck);
            return item;
        }
    }
}