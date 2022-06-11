using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsBoarPregnant : Conditional
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
                Debug.Log("numForPregnant");
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}
