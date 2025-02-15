namespace FabricatorLocker;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UWE;

public abstract class ItemConverterLocker : MonoBehaviour
{
    public abstract Dictionary<TechType, List<object[]>> ConversionTable { get; }
    public abstract int InputMultiplier { get; } // e.g., 10 for Stacked locker
    public abstract int OutputMultiplier { get; } // e.g., 10 for Unstacked locker

    public StorageContainer lockerStorage;
    public Transform spawnPoint;

    public bool isConverting = false;
    public float cooldownTime = 1.0f;

    void Start()
    {
        lockerStorage = GetComponent<StorageContainer>();
        if (lockerStorage == null)
        {
            Debug.LogError($"No StorageContainer component found on {gameObject.name}.");
        }
    }

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
                for (int i = 2; i < recipe.Length; i += 2) // Start from index 2 for inputs
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
        return false;
    }

    private void ConvertItem(TechType inputType, object[] recipe)
    {
        Debug.Log($"Attempting to convert {inputType} using recipe: {string.Join(", ", recipe)}");

        List<(TechType outputType, int quantity)> outputs = new List<(TechType, int)>();
        Dictionary<TechType, int> requiredMaterials = new Dictionary<TechType, int>();

        // Parse outputs (first half of the recipe)
        for (int i = 0; i < 2; i += 2)
        {
            if (recipe[i] is TechType itemType && recipe[i + 1] is int quantity)
            {
                outputs.Add((itemType, quantity));
            }
        }

        // Parse inputs (second half of the recipe)
        for (int i = 2; i < recipe.Length; i += 2)
        {
            if (recipe[i] is TechType itemType && recipe[i + 1] is int quantity)
            {
                requiredMaterials[itemType] = quantity;
            }
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