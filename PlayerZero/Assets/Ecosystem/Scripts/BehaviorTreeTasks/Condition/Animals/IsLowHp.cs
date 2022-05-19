using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsLowHp : Conditional
    {

        public Enemy enemy;
        public SharedFloat lowHp;

        public override void OnStart()
        {
            enemy = GetComponent<Enemy>();
        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
            if(enemy.currentHealth <= lowHp.Value)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}
