using Terraria;
using Terraria.ModLoader;

namespace ReallyifsUtils
{
    /// <summary>
    /// <para>本工具开源，网址：</para>
    /// <para>Github: https://github.com/Reallyifs/ReallyifsUtils </para>
    /// Coding: https://reallyifs.coding.net/public/ReallyifsUtils/master/git/files
    /// </summary>
    [Nothing("请注意，我是写有 summary 的" +
        "里面甚至有个开源地址，可以直接克隆下来" +
        "为啥还要反编译这个dll呢？")]
    public class ReallyifsUtils : Mod
    {
        /// <summary>
        /// 在你的 build.txt 随便 enter 出空的一行，敲上 dllReferences = ReallyifsUtils<para></para>
        /// 在 Mod主空间 新建名为 lib 的文件夹，把从群里下的 ReallyifsUtils.dll 扔进去<para></para>
        /// 打开你的 Visual Studio，右键依赖项 -> 添加引用 -> 选中 lib 里的 ReallyifsUtils.dll -> 确定<para></para>
        /// 等待加载之后就能用了
        /// </summary>
        public const string 我应该怎么使用这个Mod = "|Creator - Reallyifs|Version - 0.1.0.0|Writing time - 2020.10.25 ~ 2021.1.10";

        public ReallyifsUtils()
        {
        }

        public override void PostUpdateEverything()
        {
            Main.versionNumber = "兄啊，Load这Mod没用啊，康康 \"我应该怎么使用这个Mod\" 不香吗（";
        }
    }
}