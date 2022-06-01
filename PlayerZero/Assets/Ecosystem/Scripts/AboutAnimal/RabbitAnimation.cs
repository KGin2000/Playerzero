using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class RabbitAnimation : MonoBehaviour
{
    Enemy enemy;
    BehaviorTree behaviorTree;
    private Animator animator;
    private float lastXVal;
    private bool ifRun;
    
    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        GameObject a = this.gameObject.transform.GetChild(0).gameObject;
        animator = a.GetComponent<Animator>();

        behaviorTree = gameObject.GetComponent<BehaviorTree>();
    }
    void Start()
    {
        lastXVal = transform.position.x;
    }

    void Update()
    {       
        Animation();
    }
    private void Animation()
    {
        
        var runCondition = (SharedBool)behaviorTree.GetVariable("RabbitRunAnimation");
        //Debug.Log(runCondition);
        // animator.SetBool("Die", true);

        ifRun = runCondition.Value;
        //Debug.Log(ifRun);
        
        if (transform.position.x == lastXVal) //Idle
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false); 
            lastXVal = transform.position.x;
        }

        else if (transform.position.x < lastXVal) //เดินซ้าย
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);

            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);


            //Debug.Log(ifRun);
            if (ifRun == true) // วิ่งขวา
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
                animator.SetBool("Walk", false);
            }

            lastXVal = transform.position.x;
        }

        else if (transform.position.x > lastXVal) //เดินขวา
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);

            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Walk", true);

            //Debug.Log(ifRun);
            if (ifRun == true) // วิ่งซ้าย
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
                animator.SetBool("Walk", false);
            }

            lastXVal = transform.position.x;
        }          
    }
}
