using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Tutorials
{
    [TaskCategory("Tutorial")]
    [TaskIcon("Assets/Behavior Designer Tutorials/Tasks/Editor/{SkinColor}CanSeeObjectIcon.png")]
    public class testCanHearObjectV2 : Conditional
    {


        public SharedString targetTag;

        public SharedFloat fieldOfViewAngle = 90;

        public SharedFloat viewDistance = 30;

        public SharedGameObject returnedObject;
        public SharedVector3 returnedVector3; 

    
        public override TaskStatus OnUpdate()
        {
            
            if (!string.IsNullOrEmpty(targetTag.Value))
            {
                Vector3 position = transform.position;
                float distance = Mathf.Infinity;

                GameObject[] X = GameObject.FindGameObjectsWithTag(targetTag.Value);
                foreach (GameObject a in X)
                {
                    Vector3 difftag = a.transform.position - position;
                    float curDistancetag = difftag.sqrMagnitude;
                    GameObject closest = null;
                    if (curDistancetag < distance)
                    {
                        closest = a;
                        distance = curDistancetag;
                    }

                    returnedObject.Value = WithinSight(closest, fieldOfViewAngle.Value, viewDistance.Value);
                    returnedVector3.Value = closest.transform.position;
                }
                

                if (returnedObject.Value != null)
                {
                    return TaskStatus.Success;
                }
            }         
            return TaskStatus.Failure;
        }

        
        private GameObject WithinSight(GameObject closest, float fieldOfViewAngle, float viewDistance)
        {
            if (closest == null)
            {
                return null;
            }

            var direction = closest.transform.position - transform.position;
            direction.y = 0;
            var angle = Vector3.Angle(direction, transform.forward);
            if (direction.magnitude < viewDistance && angle < fieldOfViewAngle * 0.5f)
            {
               
                if (LineOfSight(closest))
                {
                    Debug.Log(closest.transform.position);
                    return closest;

                }
            }
            Debug.Log("2");
            return null;
  
        }

        private bool LineOfSight(GameObject closest)
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, closest.transform.position, out hit))
            {
                if (hit.transform.IsChildOf(closest.transform) || closest.transform.IsChildOf(hit.transform))
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