using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class See : Conditional
    {
        //public BehaviorTree behaviorTree;
        public SharedString MyTag;
        public SharedFloat fieldOfViewAngle = 360;
        public SharedFloat viewDistance = 15;
        public SharedGameObject returnedObject;

        private GameObject[] OurTags;

        public override void OnStart()
        {
            //behaviorTree.SetVariableValue("targetObj", returnedObject);
        }

        public override TaskStatus OnUpdate()
        {
            OurTags = GameObject.FindGameObjectsWithTag(MyTag.Value);
            foreach (GameObject OurTag in OurTags)
            {
                returnedObject.Value = WithinSight(OurTag, fieldOfViewAngle.Value, viewDistance.Value);

                //GlobalVariables.Instance.SetVariable("targetObj", returnedObject);
                //behaviorTree.SetVariableValue("targetObj", returnedObject);

                if (returnedObject.Value != null)
                {
                    Debug.Log(OurTag);
                    return TaskStatus.Success;
                }
            }
            return TaskStatus.Failure;

        }

        private GameObject WithinSight(GameObject X, float fieldOfViewAngle, float viewDistance)
        {
            if (X == null)
            {
                return null;
            }

            var direction = X.transform.position - transform.position;
            direction.y = 0;
            var angle = Vector3.Angle(direction, transform.forward);
            if (direction.magnitude < viewDistance && angle < fieldOfViewAngle * 0.5f)
            {
                // The hit agent needs to be within view of the current agent
                if (LineOfSight(X))
                {
                    return X; // return the target object meaning it is within sight
                }
            }
            return null;
        }

        private bool LineOfSight(GameObject X)
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, X.transform.position, out hit))
            {
                if (hit.transform.IsChildOf(X.transform) || X.transform.IsChildOf(hit.transform))
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = fieldOfViewAngle.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}