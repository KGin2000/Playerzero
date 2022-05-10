using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsRabbitFull : Conditional
    {
        public Enemy enemy;
        public float pointOfFull;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }

        public override void OnStart()
        {
            pointOfFull = pointOfFull / 100f;
        }

        public override TaskStatus OnUpdate()
        {
            Debug.Log(enemy.currentHungryPoint);
            if (enemy.currentHungryPoint >= pointOfFull * enemy.maxHungryPoint)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }
    }
}

