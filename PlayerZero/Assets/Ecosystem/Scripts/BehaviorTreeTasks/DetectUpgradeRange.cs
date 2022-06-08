using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectUpgradeRange : Conditional
    {
        public string targetContainName;
        public SharedString targetTag;
        public SharedFloat colliderRange;
        public float maxColliderRange;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;

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
            //colliderRange.Value = currentRange;

            increaseRange = true;
        }

        public override TaskStatus OnUpdate()
        {
            if(increaseRange == true) // ต้องมี
            {
                colliderRange.Value += 1 * Time.deltaTime;
                if(colliderRange.Value > maxColliderRange)
                {
                    colliderRange.Value = maxColliderRange;
                }
            }           

            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange.Value, enemyLayers);
            foreach (Collider obj in hitObj)
            {
                if ( obj.tag == targetTag.Value)
                {
                    // if(obj.name.Contains(targetContainName))
                    // {
                        Vector3 space = obj.transform.position - thisObjPos;
                        float curDistancetag = space.sqrMagnitude;
                        if (curDistancetag < distance)
                        {
                            closest = obj.gameObject;
                            distance = curDistancetag;
                        }
                    // }
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
                    returnTarget.Value = closest.gameObject;
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

            var halfFOV = colliderRange.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            //UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, colliderRange, enemyLayers);
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, colliderRange.Value);


            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}
