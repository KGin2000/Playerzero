using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class BoarSleeping : Action
    {
        public Enemy enemy;
        public float pointOfFull;
        public SharedBool IsSleeping;

         private float tatalPointOfFull;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
            IsSleeping.Value = true;
        }
        public override void OnStart()
        {
            tatalPointOfFull = pointOfFull / 100f;
            IsSleeping.Value = true;
        }
        public override TaskStatus OnUpdate()
        {
            if (enemy.currentHungryPoint < tatalPointOfFull * enemy.maxHungryPoint)
            {
               // IsSleeping.Value = false;
                return TaskStatus.Failure;
            }   
            return TaskStatus.Running;
        }
        public override void OnEnd()
        {
            IsSleeping.Value = false;
        }
        public override void OnReset()
        {
            IsSleeping.Value = false;
        }
    }
}