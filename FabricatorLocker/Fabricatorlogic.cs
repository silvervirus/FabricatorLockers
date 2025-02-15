namespace FabricatorLocker;

using System;
using System.Collections.Generic;
using UnityEngine; // If using Unity

public class FabricatorLogic : ItemConverterLocker // Ensure your class name matches your file name if required
{
   public override Dictionary<TechType, List<object[]>> ConversionTable { get; } =
    new Dictionary<TechType, List<object[]>>
    {
        {
            TechType.Titanium, new List<object[]>
            {
                // Output: 1 FireExtinguisher, Input: 1 Titanium
                new object[] { TechType.FireExtinguisher, 1, TechType.Titanium, 1 ,TechType.CreepvineSeedCluster,1},

                // Output: 1 SmallStorage, Input: 4 Titanium
                new object[] { TechType.SmallStorage, 1, TechType.ScrapMetal, 1,TechType.Titanium,1},

                // Output: 6 Pipes and 1 PipeSurfaceFloater, Input: 5 Titanium
                new object[] { TechType.Pipe, 7, TechType.PipeSurfaceFloater, 1, TechType.Titanium, 4 ,TechType.Battery },
                
                // Output: 1 HighCapacityTank, Input: 4 Glass and 2 Silver
                new object[] { TechType.HighCapacityTank, 1, TechType.Glass, 2, TechType.WiringKit, 1 ,TechType.Titanium,4},

                // Output: 1 DiveReel, Input: 1 CreepvineSeedCluster and 2 CopperWire
                new object[] { TechType.DiveReel, 1, TechType.Lubricant, 1, TechType.CopperWire, 1,TechType.Titanium,1 },

                // Output: 1 LaserCutter, Input: 1 Battery and 1 Diamond
                new object[] { TechType.LaserCutter, 1, TechType.Battery, 1, TechType.Diamond, 2,TechType.Titanium,1 },

                // Output: 1 StasisRifle, Input: 1 Magnetite, 2 Battery, and 1 ComputerChip
                new object[] { TechType.StasisRifle, 1, TechType.Magnetite, 2, TechType.Battery, 1, TechType.ComputerChip, 1 ,TechType.Titanium,1 },

                // Output: 1 Scanner, Input: 1 Battery
                new object[] { TechType.Scanner, 1, TechType.Flashlight, 1 ,TechType.Titanium,1},

                // Output: 1 PropulsionCannon, Input: 1 Battery and 1 WiringKit
                new object[] { TechType.PropulsionCannon, 1, TechType.Battery, 1, TechType.WiringKit, 1,TechType.Titanium,2 },

                // Output: 1 LEDLight, Input: 1 Battery and 1 Glass
                new object[] { TechType.LEDLight, 1, TechType.Battery, 1, TechType.Glass, 1 ,TechType.Titanium,1 },

                // Output: 1 welder, Input: 1 Silicone and 1 CrashPowder
                new object[] { TechType.Welder, 1, TechType.Silicone, 1, TechType.CrashPowder, 1,TechType.Titanium,1 },

                // Output: 1 Builder, Input: 1 ComputerChip and 1 WiringKit
                new object[] { TechType.Builder, 1, TechType.ComputerChip, 1, TechType.WiringKit, 1 ,TechType.Titanium,1},

                // Output: 1 Tank, Input: 3 Titanium
                new object[] { TechType.Tank, 1, TechType.Titanium, 2 ,TechType.Bladderfish,1 },

                // Output: 1 Knife, Input: 1 Silicone
                new object[] { TechType.Knife, 1, TechType.Silicone, 1 ,TechType.Titanium,1}
            }
        },
        {
            TechType.CreepvineSeedCluster, new List<object[]>
            {
                // Output: 2 Silicone, Input: 1 CreepvineSeedCluster
                new object[] { TechType.Silicone, 2, TechType.CreepvineSeedCluster, 1 , TechType.CreepvinePiece,1},

                // Output: 1 Lubricant, Input: 2 CreepvineSeedCluster
                new object[] { TechType.Lubricant, 2, TechType.CreepvineSeedCluster, 2 }
            }
        },
        {
            TechType.FiberMesh, new List<object[]>
            {
                // Output: 2 FirstAidKit, Input: 2 FiberMesh
                new object[] { TechType.FirstAidKit, 2, TechType.FiberMesh, 1,TechType.Silicone,1 },

                // Output: 1 RadiationSuit, 1 RadiationGloves, and 1 RadiationHelmet, Input: 2 Lead
                new object[] { TechType.RadiationSuit, 1, TechType.RadiationGloves, 1, TechType.RadiationHelmet, 1, TechType.Lead, 2,TechType.FiberMesh ,2 },

                // Output: 1 Rebreather, Input: 1 WiringKit
                new object[] { TechType.Rebreather, 1, TechType.WiringKit, 1 ,TechType.FiberMesh,1},

                // Output: 1 AramidFibers, Input: 1 Benzene
                new object[] { TechType.AramidFibers, 1, TechType.Benzene, 1 ,TechType.FiberMesh,1}
            }
        },
        {
            TechType.AramidFibers, new List<object[]>
            {
                // Output: 1 ReinforcedDiveSuit and 1 ReinforcedGloves, Input: 1 Diamond, 2 Titanium
                new object[] { TechType.ReinforcedDiveSuit, 1, TechType.ReinforcedGloves, 1, TechType.Diamond, 3, TechType.Titanium, 1,TechType.AramidFibers,1 },

                // Output: 1 WaterFiltrationSuit, Input: 1 Aerogel and 1 CopperWire
                new object[] { TechType.WaterFiltrationSuit, 1, TechType.Aerogel, 1, TechType.CopperWire, 1 ,TechType.AramidFibers,1 }
            }
        },
        {
            TechType.Glass, new List<object[]>
            {
                // Output: 1 EnameledGlass, Input: 1 StalkerTooth
                new object[] { TechType.EnameledGlass, 1, TechType.StalkerTooth, 1 ,TechType.Glass ,1},

                // Output: 1 Flashlight, Input: 1 Battery
                new object[] { TechType.Flashlight, 1, TechType.Battery, 1 ,TechType.Glass ,1},

                // Output: 1 ReactorRod, Input: 1 UraniniteCrystal, 3 Titanium, and 1 Lead
                new object[] { TechType.ReactorRod, 1, TechType.UraniniteCrystal, 3, TechType.Titanium, 1, TechType.Lead, 1 , TechType.Glass ,1 }
            }
        },
        {
            TechType.Copper, new List<object[]>
            {
                // Output: 1 CopperWire, Input: 2 Copper
                new object[] { TechType.CopperWire, 1, TechType.Copper, 2 },

                // Output: 1 Battery, Input: 1 AcidMushroom
                new object[] { TechType.Battery, 1, TechType.AcidMushroom, 3 ,TechType.Copper,1}
            }
        },
        {
            TechType.Bladderfish, new List<object[]>
            {
                // Output: 1 AirBladder, Input: 1 Silicone
                new object[] { TechType.AirBladder, 1, TechType.Silicone, 1 ,TechType.Bladderfish}
            }
        },
        {
       
        
            TechType.ScrapMetal, new List<object[]>
            {
                // Output: 4 Titanium, Input: 1 ScrapMetal
                new object[] { TechType.Titanium, 4, TechType.ScrapMetal, 1 }
            }
        },
        {
            TechType.CrashPowder, new List<object[]>
            {
                // Output: 5 Flares, Input: 1 CrashPowder
                new object[] { TechType.Flare, 5, TechType.CrashPowder, 1,TechType.Silicone }
            }
        },
        {
            TechType.Silicone, new List<object[]>
            {
                // Output: 1 Fins, Input: 2 Silicone
                new object[] { TechType.Fins, 1, TechType.Silicone, 2 }
            }
        },
        {
            TechType.CreepvinePiece, new List<object[]>
            {
                // Output: 1 FiberMesh, Input: 2 CreepvinePiece
                new object[] { TechType.FiberMesh, 1, TechType.CreepvinePiece, 2 }
            }
        },
       
        {
            TechType.Quartz, new List<object[]>
            {
                // Output: 1 Glass, Input: 2 Quartz
                new object[] { TechType.Glass, 1, TechType.Quartz, 2 }
            }
        },
        {
            TechType.Salt, new List<object[]>
            {
                // Output: 1 Bleach, Input: 1 CoralChunk
                new object[] { TechType.Bleach, 1, TechType.CoralChunk, 1, TechType.Salt,1 }
            }
        },
        {
            TechType.Silver, new List<object[]>
            {
                // Output: 1 WiringKit, Input: 2 Silver
                new object[] { TechType.WiringKit, 1, TechType.Silver, 2 }
            }
        },
        {
            TechType.Gold, new List<object[]>
            {
                // Output: 1 AdvancedWiringKit, Input: 2 Gold, 1 WiringKit, and 1 ComputerChip
                new object[] { TechType.AdvancedWiringKit, 1, TechType.Gold, 2, TechType.WiringKit, 1, TechType.ComputerChip, 1 }
            }
        },
        {
            TechType.WhiteMushroom, new List<object[]>
            {
                // Output: 1 HydrochloricAcid, Input: 3 WhiteMushroom and 1 Salt
                new object[] { TechType.HydrochloricAcid, 1, TechType.WhiteMushroom, 3, TechType.Salt, 1 }
            }
        },
        {
            TechType.BloodOil, new List<object[]>
            {
                // Output: 1 Benzene, Input: 3 BloodOil
                new object[] { TechType.Benzene, 1, TechType.BloodOil, 3 }
            }
        },
        {
            TechType.Lithium, new List<object[]>
            {
                // Output: 1 PlasteelIngot, Input: 2 Lithium and 1 TitaniumIngot
                new object[] { TechType.PlasteelIngot, 1, TechType.Lithium, 2, TechType.TitaniumIngot, 1 }
            }
        },
        {
            TechType.CopperWire, new List<object[]>
            {
                // Output: 1 Compass, Input: 2 CopperWire and 1 WiringKit
                new object[] { TechType.Compass, 1, TechType.CopperWire, 2, TechType.WiringKit, 1 }
            }
        },
        {
            TechType.Battery, new List<object[]>
            {
                // Output: 1 PowerCell, Input: 2 Battery and 1 Silicone
                new object[] { TechType.PowerCell, 1, TechType.Battery, 2, TechType.Silicone, 1 }
            }
        },
        {
            TechType.JeweledDiskPiece, new List<object[]>
            {
                // Output: 1 ComputerChip, Input: 2 JeweledDiskPiece, 1 Gold, and 1 CopperWire
                new object[] { TechType.ComputerChip, 1, TechType.JeweledDiskPiece, 2, TechType.Gold, 1, TechType.CopperWire, 1 }
            }
        },
        {
            TechType.HatchingEnzymes, new List<object[]>
            {
                // Output: 1 ComputerChip, Input: 2 JeweledDiskPiece, 1 Gold, and 1 CopperWire
                new object[] { TechType.HatchingEnzymes, 1, TechType.EyesPlantSeed, 1, TechType.TreeMushroomPiece, 1, TechType.RedGreenTentacleSeed, 1 , TechType.SeaCrownSeed, 1 , TechType.KooshChunk, 1  }
            }
        }
    };



   public void PrintAllEntries()
   {
       foreach (var techTypeMapping in ConversionTable)
       {
           TechType techType = techTypeMapping.Key;
           var entries = techTypeMapping.Value;

           Debug.Log($"Entries for {techType}:");

           if (entries != null && entries.Count > 0) // Ensure entries are not empty
           {
               foreach (var entry in entries)
               {
                   if (entry is object[] ingredients)
                   {
                       string formattedEntry = string.Join(", ", ingredients);
                       Debug.Log($"  - Recipe: [{formattedEntry}]");
                   }
                   else
                   {
                       Debug.LogWarning($"  - Invalid entry format for {techType}");
                   }
               }
           }
           else
           {
               Debug.Log($"  - No recipes found for {techType}");
           }
       }
   }



    

   public override int InputMultiplier
   {
       get
       {
           int totalMultiplier = 0;

           foreach (var entry in ConversionTable.Values)
           {
               foreach (var recipe in entry)
               {
                   if (recipe is object[] ingredients)
                   {
                       for (int i = 2; i < ingredients.Length - 1; i += 2)
                       {
                           if (ingredients[i] is TechType && ingredients[i + 1] is int multiplier)
                           {
                               totalMultiplier += multiplier;
                           }
                       }
                   }
               }
           }

           return totalMultiplier > 0 ? totalMultiplier : 1;
       }
   }

   public override int OutputMultiplier
   {
       get
       {
           int totalOutput = 0;

           foreach (var entry in ConversionTable.Values)
           {
               foreach (var recipe in entry)
               {
                   if (recipe is object[] ingredients)
                   {
                       for (int i = 0; i < ingredients.Length - 1; i += 2)
                       {
                           if (ingredients[i] is TechType && ingredients[i + 1] is int quantity)
                           {
                               totalOutput += quantity;
                           }
                       }
                   }
               }
           }

           return totalOutput > 0 ? totalOutput : 1;
       }
   }




}
