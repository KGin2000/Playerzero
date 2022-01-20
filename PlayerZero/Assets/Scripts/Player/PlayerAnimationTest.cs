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
    public bool idleUp;
    public bool idleDown;
    public bool idleRight;
    public bool idleLeft;

    private void Update()
    {
        EventHandler.CallMovementEvent(inputV, inputH, isWalking, isIdle, isCarrying,
                        toolEffect,
                        idleUp, idleDown, idleRight, idleLeft);
    }

}
