using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectLessSuccess : Conditional
    {
        public SharedString Mytag;
        public SharedFloat colliderRange;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;

        private float x;
        private float y;

        public SharedString returnTag;
        public SharedGameObject returnTargetObject;

        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange.Value, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                Vector3 targetPos = enemy.transform.position;
                Vector3 currentPos = transform.position;
                Vector3 Space = targetPos - currentPos;
                float curDistance = Space.sqrMagnitude;
                
                string a = Mytag.Value;
                //x = float.Parse(a);
                x = Convert.ToInt32(a);

                string b = enemy.tag;
                            //Debug.Log("b = " + b);
               // y = float.Parse(b);
                y = Convert.ToInt32(b);

                if (x < y)
                {
                    //returnTag.Value = enemy.tag;
                    returnTargetObject.Value = enemy.gameObject;
                    return TaskStatus.Success;
                }
                else if (x > y)
                {
                    //returnTag.Value = enemy.tag;
                    //returnTargetObject.Value = null;
                    return TaskStatus.Failure;
                }              
            }
            returnTargetObject.Value = null;
            return TaskStatus.Failure;
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = colliderRange.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            //UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, colliderRange.Value, enemyLayers);
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, colliderRange.Value);


            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}