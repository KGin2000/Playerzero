using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class RunAway : Action
    {
        public SharedString Mytag;
        public SharedFloat colliderRange;
        public LayerMask enemyLayers;
        public SharedFloat speed;
        public SharedBool IsRunning;

        private Vector3 prevDir;
        private int x;
        private int y;
        private string a;
        private string b;

        public SharedBool IsEscape;

        public override void OnStart()
        {
            base.OnStart();
            
        }

        public override TaskStatus OnUpdate()
        {
            IsRunning.Value = true;
            Vector3 thisObjPos = transform.position;
            Collider[] gos = Physics.OverlapSphere(thisObjPos, colliderRange.Value, enemyLayers);

            GameObject closest = null;
            float distance = Mathf.Infinity;

            foreach (Collider go in gos)
            {
                a = Mytag.Value;
                x = Convert.ToInt32(a);

                b = go.tag;
                y = Convert.ToInt32(b);

                if (x < y)
                {
                    Vector3 diff = go.transform.position - thisObjPos;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {
                        closest = go.gameObject;
                        distance = curDistance;
                    }
                }                  
            }


            Vector3 dir = Vector3.zero;
            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;

                Vector3 toward = targetPos - currentPos;

                if (toward.magnitude >= colliderRange.Value)
                {
                    IsRunning.Value = false;
                    //Debug.Log(isRunning.Value);
                    IsEscape.Value = false;
                    return TaskStatus.Success;
                }
                else
                {
                    dir -= toward;
                    IsEscape.Value = true;
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
            IsRunning.Value = false;

        }

    }
}