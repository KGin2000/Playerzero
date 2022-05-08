using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class IsPregnant : Conditional
    {
        public Enemy enemy;
        public int numForPregnant;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }
        public override TaskStatus OnUpdate()
        {
            if(enemy.countEat >= numForPregnant)
            {
                enemy.countEat = 0;
                Debug.Log("numForPregnant");
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}

