using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float inputV;
    public float inputH;
    public bool isWalking;
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;

    public bool isUsingMiningToolUp;
    public bool isUsingMiningToolDown;
    public bool isUsingMiningToolLeft;
    public bool isUsingMiningToolRight;
    public bool isUsingChoppingToolUp;
    public bool isUsingChoppingToolDown;
    public bool isUsingChoppingToolLeft;
    public bool isUsingChoppingToolRight;
    public bool isUsingDiggingToolUp;
    public bool isUsingDiggingToolDown;
    public bool isUsingDiggingToolLeft;
    public bool isUsingDiggingToolRight;
    public bool isUsingLiftingToolUp;
    public bool isUsingLiftingToolDown;
    public bool isUsingLiftingToolLeft;
    public bool isUsingLiftingToolRight;
    public bool isUsingSwingingToolUp;
    public bool isUsingSwingingToolDown;
    public bool isUsingSwingingToolLeft;
    public bool isUsingSwingingToolRight;
    public bool idleUp;
    public bool idleDown;
    public bool idleRight;
    public bool idleLeft;

    private void Update()
    {
        EventHandler.CallMovementEvent(inputV, inputH, isWalking, isIdle, isCarrying,
                                        toolEffect,
                                        isUsingMiningToolUp, isUsingMiningToolDown, isUsingMiningToolLeft, isUsingMiningToolRight,
                                        isUsingChoppingToolUp, isUsingChoppingToolDown, isUsingChoppingToolLeft, isUsingChoppingToolRight,
                                        isUsingDiggingToolUp, isUsingDiggingToolDown, isUsingDiggingToolLeft, isUsingDiggingToolRight,
                                        isUsingLiftingToolUp, isUsingLiftingToolDown, isUsingLiftingToolLeft, isUsingLiftingToolRight,
                                        isUsingSwingingToolUp, isUsingSwingingToolDown, isUsingSwingingToolLeft, isUsingSwingingToolRight,
                                        idleUp, idleDown, idleRight, idleLeft);
    }

}
