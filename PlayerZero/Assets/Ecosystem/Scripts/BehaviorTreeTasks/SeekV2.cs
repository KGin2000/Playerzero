using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskDescription("Seek the target specified using the Unity NavMesh.")]
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}SeekIcon.png")]
    public class SeekV2 : NavMeshMovement
    {
        [Tooltip("The GameObject that the agent is seeking")]
        public SharedGameObject target;
        [Tooltip("If target is null then use the target position")]
        
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

                IsRunning.Value = false;
                //target.Value = null;
                return TaskStatus.Success;

            }

            SetDestination(Target());
            return TaskStatus.Running;
        }
        
        private Vector3 Target()
        {
            Vector3 a = transform.position;
            a = new Vector3(Random.Range(-a.x, a.x), 0, Random.Range(-a.z, a.z) );
            return a;
        }

        public override void OnReset()
        {
            base.OnReset();
            target = null;
            IsRunning.Value = false;
        }
    }
}