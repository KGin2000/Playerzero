public enum AnimationName
{
    idle,
    walkUp,
    walkDown,
    walkLeft,
    walkRight,
    mineToolUp,
    mineToolDown,
    mineToolLeft,
    mineToolRight,
    chopToolUp,
    chopToolDown,
    chopToolLeft,
    chopToolRight,
    digToolUp,
    digToolDown,
    digToolLeft,
    digToolRight,
    liftToolUp,
    liftToolDown,
    liftToolLeft,
    liftToolRight,
    swingToolUp,
    swingToolDown,
    swingToolLeft,
    swingToolRight,
    count
}

public enum CharacterPartAnimator
{
    body,
    count
}

public enum PartVariantColour
{
    none,
    count
}

public enum PartVariantType
{
    none,
    hoe,
    pickaxe,
    axe,
    wateringCan,
    Reaping,
    count
}

public enum GridBoolProperty
{
    diggable,
    canDropItem,
    canPlaceFurniture,
    isPath,
    isNPCObstacle
}
public enum InventoryLocation
{
    player,
    chest,
    count
}

public enum SceneName
{
    Scene1_Farm,
    Scene2_Center,
    Scene3_House
}

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter,
    None,
    count
}

public enum ToolEffect
{
    none,
    watering
}

public enum Direction
{
    up,
    down,
    left,
    right,
    none
}

public enum SoundName
{
    none = 0,
    effectFootstepSoftGround = 10,
    effectFootstepHardGround = 20,
    effectAxe = 30,
    effectPickaxe = 40,
    effectScythe = 50,
    effectHoe = 60,
    effectWateringCan = 70,
    effectBasket = 80,
    effectPickupSound = 90,
    effectRustle = 100,
    effectTreeFalling = 110,
    effectPlantingSound = 120,
    effectPluck = 130,
    effectStoneShatter = 140,
    effectWoodSplinters = 150,
    effectArrowImpact = 160,    //
    effectCrossbowShot = 170,   //
    effectPlayerDead = 180, //
    ambientCountryside1 = 1000,
    ambientCountryside2 = 1010,
    ambientIndoor1 = 1020,
    musicCalm3 = 2000,
    musicCalm1 = 2010,
    RainCalm = 2020,    //
    clickBuy = 3000,    //
    menuButtonClick = 3010, //
    saleItem = 3020,    //
    wolfHurt = 4000,    //
    wolfHowl = 4010,    //
    wolfHunt = 4020,    //
}

public enum ItemType
{
    Seed,
    Commodity,
    Watering_tool,
    Hoeing_tool,
    Chopping_tool,
    Breaking_tool,
    Reaping_tool,
    Collecting_tool,
    Reapable_scenary,
    Weapon_tool,
    Furniture,
    none,
    count
}

public enum ItemPrefabType
{
    Item_Default,
    Item_Plant,
    Item_Meat,
    Item_Light,
    count
}
