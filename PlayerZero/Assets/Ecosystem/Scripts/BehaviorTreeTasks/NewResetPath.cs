using UnityEngine;
using UnityEngine.AI;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    public class NewResetPath : NavMeshMovement
    {
        public NavMeshAgent navMeshAgent;

        public SharedGameObject target;
        public override void OnStart()
        {
           SetDestination(target.Value.transform.position);
        }

        public override TaskStatus OnUpdate()
        {
            if (HasArrived()) 
            {
                navMeshAgent.isStopped = true;
                navMeshAgent.ResetPath();
                return TaskStatus.Success;
            }
             return TaskStatus.Failure;
        }
    }
}
