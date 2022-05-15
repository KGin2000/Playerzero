using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskDescription("Seek the target specified using the Unity NavMesh.")]
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}SeekIcon.png")]
    public class Seek : NavMeshMovement
    {
        [Tooltip("The GameObject that the agent is seeking")]
        public SharedGameObject target;
        [Tooltip("If target is null then use the target position")]
        
        public SharedVector3 targetPosition;
        public SharedBool IsRunning;

        public override void OnStart()
        {
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

                //target.Value = null;
                IsRunning.Value = false;
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

            SetDestination(Target());
            return TaskStatus.Running;
        }
        
        // Return targetPosition if target is null
        private Vector3 Target()
        {
            if (target.Value != null) {
                return target.Value.transform.position;
            }
            return targetPosition.Value;
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