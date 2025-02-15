using System.Collections.Generic;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using UnityEngine;
using static  Radical;
using static FabricatorLocker.CookedFishlocker;
using RecipeData = Nautilus.Crafting.RecipeData;

namespace FabricatorLocker;

public class CookedFishlocker
{
        public static TechType techType = BuildableDRRRC.Info.TechType;
        public static void Patch()
        {
            BuildableDRRRC.Register();
        }
    

    public static class BuildableDRRRC
    {
        public static Texture2D HorizontalWallLockersTexture = RamuneLib.Utils.ImageUtils.GetTexture("cookeddoor");
        public static Texture2D HorizontalWallLockersspec = RamuneLib.Utils.ImageUtils.GetTexture("cookeddoor");
       // public static Texture2D HorizontalWallLockersnorm = RamuneLib.Utils.ImageUtils.GetTexture("submarine_locker_01_normal");
        public static Texture2D HorizontalLockersTexture = RamuneLib.Utils.ImageUtils.GetTexture("nukeexport");
        public static Texture2D HorizontalLockersspec = RamuneLib.Utils.ImageUtils.GetTexture("nukeexport");
        public static Texture2D HorizontalLockersnorm = RamuneLib.Utils.ImageUtils.GetTexture("nukenormal");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("COFLocker", "Cooked Locker", "a Locker that can Craft Cooked Fish Recipes .", "English")
            .WithIcon(RamuneLib.Utils.ImageUtils.GetSprite("Cookedlocker"));

        public static void Register()
        {
            CustomPrefab prefab = new CustomPrefab(Info);
            CloneTemplate curtainsClone = new CloneTemplate(Info, TechType.SmallLocker);

            curtainsClone.ModifyPrefab += obj =>
            {   
                var triggerCull = obj.GetComponentInChildren<TriggerCull>();
                GameObject.DestroyImmediate(triggerCull);
                var label = obj.FindChild("Label");
                    GameObject.DestroyImmediate(label);
                var renderer1 = obj.FindChild("model").FindChild("submarine_locker_02").GetComponent<MeshRenderer>();
                foreach (var m in renderer1.materials)
                {
                    m.mainTexture = BuildableDRRRC.HorizontalLockersTexture;
                    m.SetTexture("_SpecTex", HorizontalLockersTexture);
                    m.SetTexture("_Illum", HorizontalLockersTexture);
                   // m.SetTexture("_BumpMap", HorizontalWallLockersnorm);

                }
                var renderer = obj.FindChild("model").FindChild("submarine_locker_02").FindChild("submarine_locker_02_door").GetComponent<MeshRenderer>();
                foreach (var m in renderer.materials)
                {
                    m.mainTexture = BuildableDRRRC.HorizontalWallLockersTexture;
                    m.SetTexture("_SpecTex", HorizontalWallLockersTexture);
                    m.SetTexture("_Illum", HorizontalWallLockersTexture);
                    m.SetTexture("_BumpMap", HorizontalLockersnorm);

                }
                var dynamicLocker = obj.AddComponent<CookedLockerLogic>();

                // Assign the StorageContainer reference to the DynamicLocker
                var storageContainer = obj.GetComponent<StorageContainer>();
                if (dynamicLocker != null && storageContainer != null)
                {
                    dynamicLocker.lockerStorage = storageContainer;
                }

            };


            prefab.SetUnlock(TechType.CookedLavaEyeye);
            prefab.SetGameObject(curtainsClone);
            prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule).SetBuildable();
            prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new CraftData.Ingredient(TechType.TitaniumIngot, 1),
                    new CraftData.Ingredient(TechType.CookedLavaEyeye, 1),
                    new CraftData.Ingredient(TechType.Welder, 1)
                },
            });
                
            prefab.Register();

            
        }
    }
}


