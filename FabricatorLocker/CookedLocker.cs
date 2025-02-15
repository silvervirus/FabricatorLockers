namespace FabricatorLocker
{
    using System;
    using System.Collections.Generic;
    using UnityEngine; // If using Unity

   public class CookedLockerLogic : ItemConverterLocker
    {
        // Implement InputMultiplier and OutputMultiplier
        public override int InputMultiplier => 1; // Each conversion requires 1 input item
        public override int OutputMultiplier => 1; // Each conversion produces 1 output item

       public override Dictionary<TechType, List<object[]>> ConversionTable { get; } =
    new Dictionary<TechType, List<object[]>>
    {
        {
            TechType.Bladderfish, new List<object[]>
            {
                new object[] { TechType.CookedBladderfish, 1, TechType.Bladderfish, 1 }
            }
        },
        {
            TechType.Boomerang, new List<object[]>
            {
                new object[] { TechType.CookedBoomerang, 1, TechType.Boomerang, 1 }
            }
        },
        {
            TechType.Hoopfish, new List<object[]>
            {
                new object[] { TechType.CookedHoopfish, 1, TechType.Hoopfish, 1 }
            }
        },
        {
            TechType.Spinefish, new List<object[]>
            {
                new object[] { TechType.CookedSpinefish, 1, TechType.Spinefish, 1 }
            }
        },
        {
            TechType.Eyeye, new List<object[]>
            {
                new object[] { TechType.CookedEyeye, 1, TechType.Eyeye, 1 }
            }
        },
        {
            TechType.Hoverfish, new List<object[]>
            {
                new object[] { TechType.CookedHoverfish, 1, TechType.Hoverfish, 1 }
            }
        },
        {
            TechType.Oculus, new List<object[]>
            {
                new object[] { TechType.CookedOculus, 1, TechType.Oculus, 1 }
            }
        },
        {
            TechType.Peeper, new List<object[]>
            {
                new object[] { TechType.CookedPeeper, 1, TechType.Peeper, 1 }
            }
        },
        {
            TechType.Reginald, new List<object[]>
            {
                new object[] { TechType.CookedReginald, 1, TechType.Reginald, 1 }
            }
        },
        {
            TechType.Spadefish, new List<object[]>
            {
                new object[] { TechType.CookedSpadefish, 1, TechType.Spadefish, 1 }
            }
        },
        {
            TechType.GarryFish, new List<object[]>
            {
                new object[] { TechType.CookedGarryFish, 1, TechType.GarryFish, 1 }
            }
        },
        {
            TechType.HoleFish, new List<object[]>
            {
                new object[] { TechType.CookedHoleFish, 1, TechType.HoleFish, 1 }
            }
        },
        {
            TechType.LavaBoomerang, new List<object[]>
            {
                new object[] { TechType.CookedLavaBoomerang, 1, TechType.LavaBoomerang, 1 }
            }
        },
        {
            TechType.LavaEyeye, new List<object[]>
            {
                new object[] { TechType.CookedLavaEyeye, 1, TechType.LavaEyeye, 1 }
            }
        }
    };

    }

    public class CuredLockerLogic : ItemConverterLocker
    {
        // Implement InputMultiplier and OutputMultiplier
        public override int InputMultiplier => 1; // Each conversion requires 1 input item
        public override int OutputMultiplier => 1; // Each conversion produces 1 output item

       public override Dictionary<TechType, List<object[]>> ConversionTable { get; } =
    new Dictionary<TechType, List<object[]>>
    {
        {
            TechType.Bladderfish, new List<object[]>
            {
                new object[] { TechType.CuredBladderfish, 1, TechType.Salt, 1, TechType.Bladderfish, 1 }
            }
        },
        {
            TechType.Boomerang, new List<object[]>
            {
                new object[] { TechType.CuredBoomerang, 1, TechType.Salt, 1, TechType.Boomerang, 1 }
            }
        },
        {
            TechType.Hoopfish, new List<object[]>
            {
                new object[] { TechType.CuredHoopfish, 1, TechType.Salt, 1, TechType.Hoopfish, 1 }
            }
        },
        {
            TechType.Spinefish, new List<object[]>
            {
                new object[] { TechType.CuredSpinefish, 1, TechType.Salt, 1, TechType.Spinefish, 1 }
            }
        },
        {
            TechType.Eyeye, new List<object[]>
            {
                new object[] { TechType.CuredEyeye, 1, TechType.Salt, 1, TechType.Eyeye, 1 }
            }
        },
        {
            TechType.Hoverfish, new List<object[]>
            {
                new object[] { TechType.CuredHoverfish, 1, TechType.Salt, 1, TechType.Hoverfish, 1 }
            }
        },
        {
            TechType.Oculus, new List<object[]>
            {
                new object[] { TechType.CuredOculus, 1, TechType.Salt, 1, TechType.Oculus, 1 }
            }
        },
        {
            TechType.Peeper, new List<object[]>
            {
                new object[] { TechType.CuredPeeper, 1, TechType.Salt, 1, TechType.Peeper, 1 }
            }
        },
        {
            TechType.Reginald, new List<object[]>
            {
                new object[] { TechType.CuredReginald, 1, TechType.Salt, 1, TechType.Reginald, 1 }
            }
        },
        {
            TechType.Spadefish, new List<object[]>
            {
                new object[] { TechType.CuredSpadefish, 1, TechType.Salt, 1, TechType.Spadefish, 1 }
            }
        },
        {
            TechType.GarryFish, new List<object[]>
            {
                new object[] { TechType.CuredGarryFish, 1, TechType.Salt, 1, TechType.GarryFish, 1 }
            }
        },
        {
            TechType.HoleFish, new List<object[]>
            {
                new object[] { TechType.CuredHoleFish, 1, TechType.Salt, 1, TechType.HoleFish, 1 }
            }
        },
        {
            TechType.LavaBoomerang, new List<object[]>
            {
                new object[] { TechType.CuredLavaBoomerang, 1, TechType.Salt, 1, TechType.LavaBoomerang, 1 }
            }
        },
        {
            TechType.LavaEyeye, new List<object[]>
            {
                new object[] { TechType.CuredLavaEyeye, 1, TechType.Salt, 1, TechType.LavaEyeye, 1 }
            }
        }
    };
    }
}
