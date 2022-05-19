using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsBoarHungry : Conditional
    {
        public Enemy enemy;
        public float Percentage1;
        public float Percentage2;

        private float calPercentage1;
        private float calPercentage2;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }

        public override void OnStart()
        {
            calPercentage1 = Percentage1 / 100f;
            calPercentage2 = Percentage2 / 100f;
        }

        public override TaskStatus OnUpdate()
        {
            //Debug.Log(enemy.currentHungryPoint);
            if(enemy.currentHungryPoint < calPercentage1 * enemy.maxHungryPoint)
            {
                if(calPercentage2 * enemy.maxHungryPoint < enemy.currentHungryPoint)
                {
                    return TaskStatus.Success;
                }
            }
            return TaskStatus.Failure;
        }
    }
}