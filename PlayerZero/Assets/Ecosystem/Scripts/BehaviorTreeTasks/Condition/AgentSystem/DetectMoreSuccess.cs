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
        public SharedGameObject returnTargetObject;

        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            GameObject closest = null;
            float distance = Mathf.Infinity;
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
                    if( Mathf.Abs(x - y) <=3 )
                    {
                        Vector3 space = enemy.transform.position - thisObjPos;
                        float curDistancetag = space.sqrMagnitude;
                        if (curDistancetag < distance)
                        {
                            closest = enemy.gameObject;
                            distance = curDistancetag;
                        }
                    }
                }
            }
            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;
                Vector3 toward = targetPos - currentPos;
                if (toward.magnitude <= colliderRange.Value)
                {
                    Debug.Log("success");
                    returnTargetObject.Value = closest.gameObject;
                    return TaskStatus.Success;
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