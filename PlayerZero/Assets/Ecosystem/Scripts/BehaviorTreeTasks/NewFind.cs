using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class NewFind : Action
    {
        public SharedString gameObjectName;
        public SharedString gameObjectTag;
        public SharedGameObject storeValue;

        private GameObject[] targetObjects;
        private float Distance;
        private GameObject closestObj;

        public override void OnStart()
        {          
            targetObjects = GameObject.FindGameObjectsWithTag(gameObjectTag.Value);
        }

        public override TaskStatus OnUpdate()
        {
            Distance =  Mathf.Infinity;
            foreach (GameObject targetObject in targetObjects)
            {
                if(targetObject.name.Contains(gameObjectName.Value))
                {
                    Vector3 targetPos = targetObject.transform.position;
                    Vector3 currentPos = transform.position;
                    Vector3 Space = targetPos - currentPos;
                    float curDistance = Space.sqrMagnitude;
                    if(curDistance < Distance)
                    {
                        closestObj = targetObject;
                        storeValue.Value = closestObj;
                        Distance = curDistance;
                    }
                }                
            }
            return storeValue.Value != null ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnReset()
        {
            gameObjectName = null;
            gameObjectTag = null;
            storeValue = null;
        }
    }
}
