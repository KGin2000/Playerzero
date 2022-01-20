
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

    private void SetAnimationParameters(float vInput, float hInput, bool isWalking, bool isIdle, bool isCarring,
                                        ToolEffect toolEffect,
                                        bool idleUp, bool idleDown, bool idleRight, bool idleLeft)
    {
        animator.SetFloat(Settings.vInput, vInput);
        animator.SetFloat(Settings.hInput, hInput);
        animator.SetBool(Settings.isWalking, isWalking);
    }

    private void AnimationEventPlayFootstepSound()
    {

    }
}
