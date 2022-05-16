
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    private Animator animator;

    //Use this for initialisation

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameters;
    }
    
    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(float vInput, float hInput, bool isWalking, bool isIdle, bool isCarrying,
                                        ToolEffect toolEffect,
                                        bool isUsingMiningToolUp, bool isUsingMiningToolDown, bool isUsingMiningToolLeft, bool isUsingMiningToolRight,
                                        bool isUsingChoppingToolUp, bool isUsingChoppingToolDown, bool isUsingChoppingToolLeft, bool isUsingChoppingToolRight,
                                        bool isUsingDiggingToolUp, bool isUsingDiggingToolDown, bool isUsingDiggingToolLeft, bool isUsingDiggingToolRight,
                                        bool isUsingLiftingToolUp, bool isUsingLiftingToolDown, bool isUsingLiftingToolLeft, bool isUsingLiftingToolRight,
                                        bool isUsingSwingingToolUp, bool isUsingSwingingToolDown, bool isUsingSwingingToolLeft, bool isUsingSwingingToolRight,
                                        bool idleUp, bool idleDown, bool idleRight, bool idleLeft)
    {
        animator.SetFloat(Settings.vInput, vInput);
        animator.SetFloat(Settings.hInput, hInput);
        animator.SetBool(Settings.isWalking, isWalking);

        //animator.SetInteger(Settings.toolEffect, (int)toolEffect);

        if (isUsingMiningToolUp)
            animator.SetTrigger(Settings.isUsingMiningToolUp);
        if (isUsingMiningToolDown)
            animator.SetTrigger(Settings.isUsingMiningToolDown);
        if (isUsingMiningToolLeft)
            animator.SetTrigger(Settings.isUsingMiningToolLeft);
        if (isUsingMiningToolRight)
            animator.SetTrigger(Settings.isUsingMiningToolRight);

        if (isUsingChoppingToolUp)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingChoppingToolDown)
            animator.SetTrigger(Settings.isUsingChoppingToolDown);
        if (isUsingChoppingToolLeft)
            animator.SetTrigger(Settings.isUsingChoppingToolLeft);
        if (isUsingChoppingToolRight)
            animator.SetTrigger(Settings.isUsingChoppingToolRight);

        if (isUsingDiggingToolUp)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingDiggingToolDown)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingLiftingToolLeft)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingLiftingToolRight)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        
        if (isUsingSwingingToolUp)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingLiftingToolDown)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingChoppingToolUp)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingChoppingToolUp)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);

        if (isUsingSwingingToolUp)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingSwingingToolDown)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingSwingingToolLeft)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);
        if (isUsingSwingingToolRight)
            animator.SetTrigger(Settings.isUsingChoppingToolUp);

        if (idleUp)
            animator.SetTrigger(Settings.idleUp);
        if (idleDown)
            animator.SetTrigger(Settings.idleDown);
        if (idleRight)
            animator.SetTrigger(Settings.idleRight);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);

    }

    private void AnimationEventPlayFootstepSound()
    {
        AudioManager.Instance.PlaySound(SoundName.effectFootstepHardGround);
    }
}
