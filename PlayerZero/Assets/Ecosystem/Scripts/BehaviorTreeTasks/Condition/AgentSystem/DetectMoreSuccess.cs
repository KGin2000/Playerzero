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
         public float maxColliderRange;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;

        public SharedString returnTag;
        public SharedGameObject returnTarget;
        public bool increaseRange = false;

        private float x;
        private float y;
        private float currentRange;

        public override void OnAwake()
        {
            currentRange = colliderRange.Value;
        }
        public override void OnStart()
        {
            increaseRange = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (returnTarget.Value == null)
            {
                if(increaseRange == true) // ต้องมี
                {
                    colliderRange.Value += 1 * Time.deltaTime;
                    if(colliderRange.Value > maxColliderRange)
                    {
                        colliderRange.Value = maxColliderRange;
                    }
                    //Debug.Log("colliderRange.Value = " + colliderRange.Value);
                }
            }

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
                        returnTag.Value = enemy.tag;
                        returnTarget.Value = enemy.gameObject;
                        colliderRange.Value = currentRange;
                        increaseRange = false;
                        Debug.Log( x + " - " + y + " = " + (x-y));
                        return TaskStatus.Success;
                    }
                }               
            }
            returnTarget.Value = null;
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