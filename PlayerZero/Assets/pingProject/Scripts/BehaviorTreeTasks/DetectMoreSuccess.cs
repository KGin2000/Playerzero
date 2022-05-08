using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectMoreSuccess : Conditional
    {
        public SharedString Mytag;
        public SharedFloat colliderRange;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;

        private float x;
        private float y;

        public SharedString returnTag;
        public SharedGameObject returnTarget;

        public override void OnStart()
        {
            returnTarget.Value = null;
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange.Value, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                string a = Mytag.Value;
                x = float.Parse(a);
                //x = Convert.ToInt32(a);

                string b = enemy.tag;
                y = float.Parse(b);
                //y = Convert.ToInt32(b);
                
                if (x > y)
                {
                    returnTag.Value = enemy.tag;
                    returnTarget.Value = enemy.gameObject;
                    return TaskStatus.Success;
                }
                if (x < y)
                {
                    returnTag.Value = enemy.tag;
                    returnTarget.Value = enemy.gameObject;
                    return TaskStatus.Failure;
                }
            }
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
            //UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, colliderRange, enemyLayers);
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, colliderRange.Value);


            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}