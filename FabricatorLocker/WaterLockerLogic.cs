namespace FabricatorLocker
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UWE;

    public class WaterLockerLogic : MonoBehaviour
    {

        public int InputMultiplier { get; } // e.g., 10 for Stacked locker
        public int OutputMultiplier { get; } // e.g., 10 for Unstacked locker

        public StorageContainer lockerStorage;
        public Transform spawnPoint;

        public bool isConverting = false;

        public float cooldownTime = 1.0f;

        // ConversionTable with all water-related recipes
        public Dictionary<TechType, List<object[]>> ConversionTable { get; } = new Dictionary<TechType, List<object[]>>
        {
            // Converts 1 Bladderfish into 1 Filtered Water
            {
                TechType.Bladderfish, new List<object[]>
                {
                    new object[] { TechType.FilteredWater, 1, TechType.Bladderfish, 1 }
                }
            },

            // Converts 1 Bleach into 2 Disinfected Water
            {
                TechType.Bleach, new List<object[]>
                {
                    new object[] { TechType.DisinfectedWater, 2, TechType.Bleach, 1 }
                }
            },

            // Converts 3 Disinfected Water into 1 Big Filtered Water
            {
                TechType.DisinfectedWater, new List<object[]>
                {
                    new object[] { TechType.BigFilteredWater, 1, TechType.DisinfectedWater, 3 }
                }
            }
        };



        void Update()
        {
            if (!isConverting && lockerStorage != null &&
                CheckRequiredItems(out TechType inputType, out object[] conversionData))
            {
                StartCoroutine(ConvertWithCooldown(inputType, conversionData));
            }
        }

        private IEnumerator ConvertWithCooldown(TechType inputType, object[] conversionData)
        {
            isConverting = true;
            ConvertItem(inputType, conversionData);
            yield return new WaitForSeconds(cooldownTime);
            isConverting = false;
        }

        public bool CheckRequiredItems(out TechType inputType, out object[] conversionData)
        {
            foreach (var conversion in ConversionTable)
            {
                inputType = conversion.Key;
                foreach (var recipe in conversion.Value)
                {
                    bool hasAllMaterials = true;
                    Dictionary<TechType, int> requiredMaterials = new Dictionary<TechType, int>();

                    // Parse the recipe properly
                    for (int i = 2; i < recipe.Length; i += 2)
                    {
                        if (recipe[i] is TechType itemType && recipe[i + 1] is int requiredQuantity)
                        {
                            requiredMaterials[itemType] = requiredQuantity;

                            if (lockerStorage.container.GetCount(itemType) < requiredQuantity)
                            {
                                hasAllMaterials = false;
                                break;
                            }
                        }
                    }

                    if (hasAllMaterials)
                    {
                        conversionData = recipe;
                        return true;
                    }
                }
            }

            inputType = TechType.None;
            conversionData = null;
            return false; // No valid recipe found
        }




        private void ConvertItem(TechType inputType, object[] recipe)
        {
            Debug.Log($"Attempting to convert {inputType} using recipe: {string.Join(", ", recipe)}");

            // Prepare the output and required materials
            List<(TechType outputType, int quantity)> outputs = new List<(TechType, int)>();
            Dictionary<TechType, int> requiredMaterials = new Dictionary<TechType, int>();

            // Parse the output (first element of the recipe)
            if (recipe[0] is TechType outputType && recipe[1] is int outputQuantity)
            {
                outputs.Add((outputType, outputQuantity));
            }

            // Parse the input (second part of the recipe)
            if (recipe[2] is TechType recipeInputType && recipe[3] is int inputQuantity)
            {
                requiredMaterials[recipeInputType] = inputQuantity;
            }

            // Debug check for required materials
            foreach (var material in requiredMaterials)
            {
                Debug.Log(
                    $"Checking input: {material.Key}, Required: {material.Value}, Available: {lockerStorage.container.GetCount(material.Key)}");

                if (lockerStorage.container.GetCount(material.Key) < material.Value)
                {
                    Debug.LogError($"Not enough {material.Key} in locker for conversion.");
                    return;
                }
            }

            // Remove required materials
            foreach (var material in requiredMaterials)
            {
                for (int i = 0; i < material.Value; i++)
                {
                    if (!lockerStorage.container.DestroyItem(material.Key))
                    {
                        Debug.LogError($"Failed to remove {material.Key} from locker. Not enough items.");
                        return;
                    }
                }

                Debug.Log($"Removed {material.Value}x {material.Key} from locker.");
            }

            // Spawn output items
            foreach (var output in outputs)
            {
                for (int i = 0; i < output.quantity; i++)
                {
                    CraftData.AddToInventory(output.outputType, 1);
                }

                Debug.Log(
                    $"Converted materials into {output.quantity}x {output.outputType} and added to player inventory.");
            }
        }
    }
}

