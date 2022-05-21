using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    public class NewWander : NavMeshMovement
    {
        public SharedFloat minWanderDistance = 20;
        public SharedFloat maxWanderDistance = 20;
        public SharedFloat wanderRate = 2;
        public SharedFloat minPauseDuration = 0;     
        public SharedFloat maxPauseDuration = 0;      
        public SharedInt targetRetries = 1;

        private float pauseTime;
        private float destinationReachTime;
        public override void OnStart()
        {
            navMeshAgent.speed = 3;
            navMeshAgent.angularSpeed = 1;
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            navMeshAgent.updateRotation = false;
        }
        public override TaskStatus OnUpdate()
        {
            if (HasArrived()) 
            {
                // The agent should pause at the destination only if the max pause duration is greater than 0
                if (maxPauseDuration.Value > 0) 
                {
                    if (destinationReachTime == -1) 
                    {
                        destinationReachTime = Time.time;
                        pauseTime = Random.Range(minPauseDuration.Value, maxPauseDuration.Value);
                    }
                    if (destinationReachTime + pauseTime <= Time.time) 
                    {
                        // Only reset the time if a destination has been set.
                        if (TrySetTarget()) 
                        {
                            destinationReachTime = -1;
                        }
                    }
                } 
                else 
                {
                    TrySetTarget();
                }
            }
            return TaskStatus.Running;
        }

        private bool TrySetTarget()
        {
            Vector3 direction = transform.position;
            bool validDestination = false;
            var attempts = targetRetries.Value;
            Vector3 destination = transform.position;
            while (!validDestination && attempts > 0) 
            {            
                direction = direction + Random.insideUnitSphere * Random.Range(20, 20); // สุ่มจุด
                direction.y =1;
                validDestination = SamplePosition(direction); 
                //Debug.Log(direction);
                attempts--;
            }
            if (validDestination) 
            {
                SetDestination(direction);               
            }
            return validDestination;
        }
    }
}

