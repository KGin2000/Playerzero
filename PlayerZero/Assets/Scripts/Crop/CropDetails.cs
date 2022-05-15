using UnityEngine;

[System.Serializable]
public class CropDetails 
{
    [ItemCodeDescription]
    public int seedItemCode;
    public int[] growthDays;
    // public int totalGrowthDays;
    public GameObject[] growthPrefab;
    public Sprite[] growthSprite;
    public Season[] seasons;
    public Sprite harvestedSprite;

    [ItemCodeDescription]
    public int harvestedTransformItemCode;
    public bool hideCropBeforeHarvestedAnimation;
    public bool disableCropCollidersBeforeHarvestedAnimation;
    public bool isHarvestedAnimation;
    public bool UseWater;
    public bool isHarvestActionEffect = false;
    public bool spawnCropProduceAtPlayerPosition;
    //public HarvestActionEffect harvestActionEffect;
    public SoundName harvestSound;

    [ItemCodeDescription]
    public int[] harvestToolItemCode;
    public int[] requiredHarvestActions;

    [ItemCodeDescription]
    public int[] cropProducedItemCode;
    public int[] cropProducedMinQuantity;
    public int[] cropProducedMaxQuantity;
    public int daysToRegrow;

    public bool CanUseToolToHarvestCrop(int toolItemCode)
    {
        if (RequairedHarvestActionsForTool(toolItemCode) == -1)
        {
            Debug.Log("IF");
            return false;
        }
        else
        {
            Debug.Log("ELSE");
            return true;
        }
    }

    public int RequairedHarvestActionsForTool(int toolItemCode)
    {
        for(int i = 0; i < harvestToolItemCode.Length; i++)
        {
            if(harvestToolItemCode[i] == toolItemCode)
            {
                return requiredHarvestActions[i];
            }
        }
        return -1;
    } 
}
