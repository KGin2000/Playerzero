using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class CurrentHungryFull : Conditional
    {
        public Enemy enemy;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }

        public override TaskStatus OnUpdate()
        {
            enemy.currentHungryPoint = enemy.maxHungryPoint;        
            return TaskStatus.Success;
        }
    }
}