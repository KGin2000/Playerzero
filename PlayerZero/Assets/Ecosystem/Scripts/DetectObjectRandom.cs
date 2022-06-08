using UnityEngine; 
using System.Collections.Generic;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectObjectRandom : Conditional
    {
        public SharedString objectTag;
        public SharedFloat colliderRange;
        public LayerMask enemyLayers;
        public SharedFloat fieldOfViewAngle = 360;
        public SharedGameObject returnGameObject;

        private List<GameObject> gameObjects = new List<GameObject>();

        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange.Value, enemyLayers);
            foreach (Collider obj in hitObj)
            {
                if ( obj.tag == objectTag.Value)
                {
                    gameObjects.Add(obj.gameObject);
                    returnGameObject.Value = gameObjects[Random.Range(0, gameObjects.Count)];
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
            //UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, colliderRange.Value, enemyLayers);
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, colliderRange.Value);


            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}