using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsWolfFull : Conditional
    {
        public Enemy enemy;
        public float pointOfFull;

        private float tatalPointOfFull;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }

        public override void OnStart()
        {
            tatalPointOfFull = pointOfFull / 100f;
        }

        public override TaskStatus OnUpdate()
        {
            //Debug.Log(enemy.currentHungryPoint);
            if (enemy.currentHungryPoint >= tatalPointOfFull * enemy.maxHungryPoint)
            {
                return TaskStatus.Success;
            }
            else
                return TaskStatus.Failure;
        }
    }
}