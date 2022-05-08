using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;

public class Controller_Rabbit: MonoBehaviour
{

    [SerializeField] Enemy enemy;


    void Start()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();
        behaviorTree[0].enabled = false;
        behaviorTree[1].enabled = false;

    }

    void Update()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();

        if (gameObject.layer == 31)
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = true;

        }
        else if(gameObject.layer != 31)
        {
            behaviorTree[2].enabled = false;
            if (enemy.currentHungryPoint >= 0.8f * enemy.maxHungryPoint)
            {
                // idle , wander , follow sameTag
                behaviorTree[0].enabled = true;
                behaviorTree[1].enabled = false;
            }

            if (enemy.currentHungryPoint < 0.8f * enemy.maxHungryPoint)
            {
                //หิว
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = true;
            }
        }       
    }
}
