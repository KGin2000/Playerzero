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