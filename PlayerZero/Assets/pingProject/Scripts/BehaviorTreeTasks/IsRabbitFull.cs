using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class IsRabbitFull : Conditional
    {
        public Enemy enemy;
        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }

        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            Debug.Log(enemy.currentHungryPoint);
            if (enemy.currentHungryPoint >= 0.8f * enemy.maxHungryPoint)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }
    }
}

