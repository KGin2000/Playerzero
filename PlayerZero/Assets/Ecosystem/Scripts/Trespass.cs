using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
        [TaskCategory("Animals")]
    public class Trespass : Conditional
    {
        public Enemy enemy;
        public float Percentage;

        private float calPercentage;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }

        public override void OnStart()
        {
            calPercentage = Percentage / 100f;
        }

        public override TaskStatus OnUpdate()
        {
            //Debug.Log(enemy.currentHungryPoint);
            if (enemy.currentHungryPoint > calPercentage * enemy.maxHungryPoint)
            {
                //Debug.Log(calPercentage);
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }
    }
}

