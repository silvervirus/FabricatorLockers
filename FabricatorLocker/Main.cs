using BepInEx;

namespace FabricatorLocker;

[BepInPlugin("com.Cookay.FabricatorLocker", "Fabricator Locker", "1.0.0")]
[BepInDependency("com.snmodding.nautilus", BepInDependency.DependencyFlags.HardDependency)]
public class Main : BaseUnityPlugin
{
    public void Awake()
    {
        FabricatorLocker.Fablocker.Patch();
        Waterlocker.Patch();
        CookedFishlocker.Patch();
        CuredFishlocker.Patch();
    }
}