using Terraria.ModLoader;

namespace ReallyifsUtils
{
    public class ReallyifsUtils : Mod
    {
        public const string 我应该怎么使用这个Mod = "在你的build.txt随便enter出空的一行，敲上dllReferences = ReallyifsUtils" +
            "在Mod主空间新建名为lib的文件夹，把从群里下的ReallyifsUtils.dll扔进去" +
            "打开你的Visual Studio，依赖项->程序集->添加引用->选中lib里的ReallyifsUtils.dll" +
            "然后就能用了";
    }
}