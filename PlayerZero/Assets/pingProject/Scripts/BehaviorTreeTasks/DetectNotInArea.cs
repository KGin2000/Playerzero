using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectNotInArea: Conditional
    {
        public SharedString targetTag;
        public SharedFloat colliderRange;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;

        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange.Value, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                if (enemy.tag == targetTag.Value)
                {
                    return TaskStatus.Running;
                }
                else 
                {
                    return TaskStatus.Success;
                }
                
            }
            return TaskStatus.Success;
            //return TaskStatus.Failure;
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