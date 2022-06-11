using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class GivingBirth : Action
    {
        public Enemy enemy;

        public override void OnAwake()
        {
            enemy = GetComponent<Enemy>();
        }
        public override TaskStatus OnUpdate()
        {           
            enemy.countEat = 0;
            Debug.Log("GivingBirth");
            return TaskStatus.Success;
        }
    }
}