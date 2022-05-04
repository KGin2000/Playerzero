
using UnityEngine;

public static class Settings 
{
    // Scenes
    public const string PersistentScene = "PersistentScene";

    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;
    public const float targetAlphaZero = 0.0f;

    //TileMap
    public const float gridCellSize = 1f;       //Grid Cell Size in Unity Units
    public static Vector2 cursorSize = Vector2.one;

    //Player
    public static float playerCentreYOffset = 0.875f;

    //Player Movement
    public const float runningSpeed = 7.777f;
    public const float walkingSpeed = 4.444f;
    public static float useToolAnimationPause = 0.25f;
    public static float liftToolAnimationPause = 0.4f;
    public static float pickAnimationPause = 1f;
    public static float afterUseToolAnimationPause = 0.2f;
    public static float afterLiftToolAnimationPause = 0.4f;
    public static float afterPickAnimationPause = 0.2f;

    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;

    //Player Animation Parameters
    public static int vInput;
    public static int hInput;
    public static int isWalking;
    public static int toolEffect;
    public static int isUsingMiningToolUp;
    public static int isUsingMiningToolDown;
    public static int isUsingMiningToolLeft;
    public static int isUsingMiningToolRight;
    public static int isUsingChoppingToolUp;
    public static int isUsingChoppingToolDown;
    public static int isUsingChoppingToolLeft;
    public static int isUsingChoppingToolRight;
    public static int isUsingDiggingToolUp;
    public static int isUsingDiggingToolDown;
    public static int isUsingDiggingToolLeft;
    public static int isUsingDiggingToolRight;
    public static int isUsingLiftingToolUp;
    public static int isUsingLiftingToolDown;
    public static int isUsingLiftingToolLeft;
    public static int isUsingLiftingToolRight;
    public static int isUsingSwingingToolUp;
    public static int isUsingSwingingToolDown;
    public static int isUsingSwingingToolLeft;
    public static int isUsingSwingingToolRight;

    // Shared Animation Parameters
    public static int idleUp;
    public static int idleDown;
    public static int idleRight;
    public static int idleLeft;

        //Tool//
    public const string HoeingTool = "Hoe";
    public const string ChoppingTool = "Axe";
    public const string BreakingTool = "Pickaxe";
    public const string ReapingTool = "Scythe";
    public const string WateringTool = "Watering Can";
    public const string CollectingTool = "Basket";

    //Reaping
    public const int maxCollidersToTestPerReapSwing = 15;
    public const int maxTargetComponentsToDestroyPerReapSwing = 2;

        //Time System
    public const float secondsPerGameSecond = 0.012f;


    // Static Constructor
    static Settings()
    {
        //Player Animation Parameters
        vInput = Animator.StringToHash("vInput");
        hInput = Animator.StringToHash("hInput");
        isWalking = Animator.StringToHash("isWalking");
        toolEffect = Animator.StringToHash("toolEffect");
        isUsingMiningToolUp = Animator.StringToHash("isUsingMiningToolUp");
        isUsingMiningToolDown = Animator.StringToHash("isUsingMiningToolDown");
        isUsingMiningToolLeft = Animator.StringToHash("isUsingMiningToolLeft");
        isUsingMiningToolRight = Animator.StringToHash("isUsingMiningToolRight");
        isUsingChoppingToolUp = Animator.StringToHash("isUsingChoppingToolUp");
        isUsingChoppingToolDown = Animator.StringToHash("isUsingChoppingToolDown");
        isUsingChoppingToolLeft = Animator.StringToHash("isUsingChoppingToolLeft");
        isUsingChoppingToolRight = Animator.StringToHash("isUsingChoppingToolRight");
        isUsingDiggingToolUp = Animator.StringToHash("isUsingDiggingToolUp");
        isUsingDiggingToolDown = Animator.StringToHash("isUsingDiggingToolDown");
        isUsingDiggingToolLeft = Animator.StringToHash("isUsingDiggingToolLeft");
        isUsingDiggingToolRight = Animator.StringToHash("isUsingDiggingToolRight");
        isUsingLiftingToolUp = Animator.StringToHash("isUsingLiftingToolUp");
        isUsingLiftingToolDown = Animator.StringToHash("isUsingLiftingToolDown");
        isUsingLiftingToolLeft = Animator.StringToHash("isUsingLiftingToolLeft");
        isUsingLiftingToolRight = Animator.StringToHash("isUsingLiftingToolRight");
        isUsingSwingingToolUp = Animator.StringToHash("isUsingSwingingToolUp");
        isUsingSwingingToolDown = Animator.StringToHash("isUsingSwingingToolDown");
        isUsingSwingingToolLeft = Animator.StringToHash("isUsingSwingingToolLeft");
        isUsingSwingingToolRight = Animator.StringToHash("isUsingSwingingToolRight");

        // Shared Animation Parameters
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleRight = Animator.StringToHash("idleRight");
        idleLeft = Animator.StringToHash("idleLeft");
    }
}
