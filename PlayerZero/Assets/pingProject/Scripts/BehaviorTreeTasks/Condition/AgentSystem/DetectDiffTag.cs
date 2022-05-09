using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectDiffTag : Conditional
    {
        public SharedString Mytag;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;
        public SharedFloat search;

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
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, search.Value, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                string a = Mytag.Value;
                x = float.Parse(a);

                string b = enemy.tag;
                y = float.Parse(b);

                if ((x > y) || (x < y))
                {
                    returnTag.Value = enemy.tag;
                    returnTargetObject.Value = enemy.gameObject;
                    return TaskStatus.Success;
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

            var halfFOV = search.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            //UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, colliderRange, enemyLayers);
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, search.Value);


            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}