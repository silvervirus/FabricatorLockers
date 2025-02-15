using System.Collections.Generic;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using UnityEngine;
using static  Radical;
using RecipeData = Nautilus.Crafting.RecipeData;

namespace FabricatorLocker;

public class CuredFishlocker
{
        public static TechType techType = BuildableCUFL.Info.TechType;
        public static void Patch()
        {
            BuildableCUFL.Register();
        }
    

    public static class BuildableCUFL
    {
        public static Texture2D HorizontalWallLockersTexture = RamuneLib.Utils.ImageUtils.GetTexture("cureddoor");
        public static Texture2D HorizontalWallLockersspec = RamuneLib.Utils.ImageUtils.GetTexture("cureddoor");
       // public static Texture2D HorizontalWallLockersnorm = RamuneLib.Utils.ImageUtils.GetTexture("submarine_locker_01_normal");
        public static Texture2D HorizontalLockersTexture = RamuneLib.Utils.ImageUtils.GetTexture("nukeexport");
        public static Texture2D HorizontalLockersspec = RamuneLib.Utils.ImageUtils.GetTexture("nukeexport");
        public static Texture2D HorizontalLockersnorm = RamuneLib.Utils.ImageUtils.GetTexture("nukenormal");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("CUFLLocker", "Cured Locker", "Locker To craft Cured Fish Recipes.", "English")
            .WithIcon(RamuneLib.Utils.ImageUtils.GetSprite("Curedlocker"));

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
                    m.mainTexture = BuildableCUFL.HorizontalLockersTexture;
                    m.SetTexture("_SpecTex", HorizontalLockersTexture);
                    m.SetTexture("_Illum", HorizontalLockersTexture);
                   // m.SetTexture("_BumpMap", HorizontalWallLockersnorm);

                }
                var renderer = obj.FindChild("model").FindChild("submarine_locker_02").FindChild("submarine_locker_02_door").GetComponent<MeshRenderer>();
                foreach (var m in renderer.materials)
                {
                    m.mainTexture = BuildableCUFL.HorizontalWallLockersTexture;
                    m.SetTexture("_SpecTex", HorizontalWallLockersTexture);
                    m.SetTexture("_Illum", HorizontalWallLockersTexture);
                    m.SetTexture("_BumpMap", HorizontalLockersnorm);

                }
                var dynamicLocker = obj.AddComponent<CuredLockerLogic>();

                // Assign the StorageContainer reference to the DynamicLocker
                var storageContainer = obj.GetComponent<StorageContainer>();
                if (dynamicLocker != null && storageContainer != null)
                {
                    dynamicLocker.lockerStorage = storageContainer;
                }

            };


            prefab.SetUnlock(TechType.CuredLavaEyeye);
            prefab.SetGameObject(curtainsClone);
            prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule).SetBuildable();
            prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new CraftData.Ingredient(TechType.TitaniumIngot, 1),
                    new CraftData.Ingredient(TechType.CuredLavaEyeye, 1),
                    new CraftData.Ingredient(TechType.Salt, 2),
                },
            });
                
            prefab.Register();

            
        }
    }
}


