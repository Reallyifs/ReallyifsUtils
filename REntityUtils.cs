using Microsoft.Xna.Framework;
using Terraria;

namespace ReallyifsUtils
{
    public static class REntityUtils
    {
        /// <summary>
        /// 将生成一个 <see cref="Item"/>，返回其在 <see cref="Main.item"/> 里的 index，将直接替换此 index 所属的 <see cref="Item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <returns>index</returns>
        public static int NewItem(this Item item)
        {
            int index = Item.NewItem(new Vector2(), item.type);
            Main.item[index] = item;
            return index;
        }

        /// <summary>
        /// 将生成一个 <see cref="NPC"/>，返回其在 <see cref="Main.npc"/> 里的 index，将直接替换此 index 所属的 <see cref="NPC"/>
        /// </summary>
        /// <param name="npc"></param>
        /// <returns>index</returns>
        public static int NewNPC(this NPC npc)
        {
            int index = NPC.NewNPC(0, 0, npc.type);
            Main.npc[index] = npc;
            return index;
        }

        /// <summary>
        /// 将生成一个 <see cref="Projectile"/>，返回其在 <see cref="Main.projectile"/> 里的 index，将直接替换此 index 所属的 <see cref="Projectile"/>
        /// </summary>
        /// <param name="projectile"></param>
        /// <returns>index</returns>
        public static int NewProjectile(this Projectile projectile)
        {
            int index = Projectile.NewProjectile(new Vector2(), new Vector2(), projectile.type, 0, 0);
            Main.projectile[index] = projectile;
            return index;
        }

        /// <summary>
        /// 返回一个 <see cref="Item"/>，将直接调用 <see cref="Item.SetDefaults(int, bool)"/>，其 Type 为 <paramref name="type"/>，noMatCheck 为 <paramref name="noMatCheck"/>
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

        /// <summary>
        /// 返回一个 <see cref="Projectile"/>，将直接调用 <see cref="Projectile.SetDefaults(int)"/>，其 Type 为 <paramref name="type"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Projectile ProjectileSetDefaults(this int type)
        {
            Projectile projectile = new Projectile();
            projectile.SetDefaults(type);
            return projectile;
        }

        /// <summary>
        /// 返回一个 <see cref="NPC"/>，将直接调用 <see cref="NPC.SetDefaults(int, float)"/>，其 Type 为 <paramref name="type"/>，scaleOverride 为 <paramref name="scaleOverride"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="scaleOverride"></param>
        /// <returns></returns>
        public static NPC NPCSetDefaults(this int type, float scaleOverride = -1)
        {
            NPC npc = new NPC();
            npc.SetDefaults(type, scaleOverride);
            return npc;
        }
    }
}