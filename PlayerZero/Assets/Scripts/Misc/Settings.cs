
using UnityEngine;

public static class Settings 
{
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;

    //Player Movement
    public const float runningSpeed = 5.333f;
    public const float walkingSpeed = 2.666f;

    //Player Animation Parameters
    public static int vInput;
    public static int hInput;
    public static int isWalking;

    // Shared Animation Parameters
    public static int idleUp;
    public static int idleDown;
    public static int idleRight;
    public static int idleLeft;

    // Static Constructor
    static Settings()
    {
        //Player Animation Parameters
        vInput = Animator.StringToHash("vInput");
        hInput = Animator.StringToHash("hInput");
        isWalking = Animator.StringToHash("isWalking");

        // Shared Animation Parameters
    }
}
