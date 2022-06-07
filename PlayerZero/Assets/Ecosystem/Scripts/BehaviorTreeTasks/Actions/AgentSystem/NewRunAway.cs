using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class NewRunAway : Action
    {
        public SharedGameObject returnEnemy;
        
        public SharedFloat colliderRange;
        public SharedFloat speed;
        public SharedBool animationIsRunning;

        private Vector3 prevDir;
        private int x;
        private int y;
        private string a;
        private string b;

        protected UnityEngine.AI.NavMeshAgent navMeshAgent;
        public override void OnAwake()
        {
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            navMeshAgent.updateRotation = false;
        }

        public override void OnStart()
        {
            base.OnStart();         
        }

        public override TaskStatus OnUpdate()
        {
            animationIsRunning.Value = true;

            Vector3 thisObjPos = transform.position;
            GameObject closest = null;
            float distance = Mathf.Infinity;
            if(returnEnemy.Value == null)
            {
                return TaskStatus.Failure;
            }
            Vector3 diff = returnEnemy.Value.transform.position - thisObjPos;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
                {
                    closest = returnEnemy.Value.gameObject;
                    distance = curDistance;
                }        
            


            Vector3 dir = Vector3.zero;
            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;

                Vector3 toward = targetPos - currentPos;

                if (toward.magnitude >= colliderRange.Value)
                {
                    animationIsRunning.Value = false;
                    //Debug.Log(isRunning.Value);
                    returnEnemy.Value = null;
                    return TaskStatus.Success;
                }
                else
                {
                    dir -= toward;
                }
            }

            dir.Normalize();
            dir = dir * speed.Value * Time.deltaTime;
            dir = Vector3.Lerp(prevDir, dir, 0.2f);
            transform.position += dir;
            prevDir = dir;

            //Debug.Log(isRunning.Value);
            return TaskStatus.Running;

        }

        public override void OnReset()
        {
            base.OnReset();
            animationIsRunning.Value = false;

        }

        public override void OnEnd()
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }

    }
}