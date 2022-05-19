using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskCategory("Movement")]
    public class Seek_Random : NavMeshMovement
    {
        [Tooltip("The GameObject that the agent is seeking")]
        public SharedGameObject target;
        [Tooltip("If target is null then use the target position")]
        
        public SharedVector3 targetPosition;
        public SharedBool IsRunning;
        //public List<GameObject> targetList;
        public SharedGameObject[ ] targetArray;

         private int x;
    

        public override void OnStart()
        {
            x = Random.Range (0, targetArray.Length);
            target.Value = targetArray[x].Value;
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            navMeshAgent.updateRotation = false;
            base.OnStart();

            SetDestination(Target());
        }

        // Seek the destination. Return success once the agent has reached the destination.
        // Return running if the agent hasn't reached the destination yet
        public override TaskStatus OnUpdate()
        {
            IsRunning.Value = true;
            if (HasArrived()) 
            {   
                Debug.Log("Hasarrived");

                IsRunning.Value = false;
                //target.Value = null;
                return TaskStatus.Success;

            }
            if (target.Value == null)
            {

                IsRunning.Value = false;
                return TaskStatus.Failure;
            }

            if (target.Value.tag == "ImmortalObject")
            {
                Debug.Log("ImmortalObject");

                IsRunning.Value = false;
                return TaskStatus.Failure;
            }

            //SetDestination(Target());
            return TaskStatus.Running;
        }
        
        // Return targetPosition if target is null
        private Vector3 Target()
        {
            if (target.Value != null) {
                return target.Value.transform.position;
            }
            return targetPosition.Value = transform.position;
            //return targetPosition.Value;
        }

        public override void OnReset()
        {
            base.OnReset();
            target = null;
            targetPosition = Vector3.zero;
            IsRunning.Value = false;
        }
    }
}

