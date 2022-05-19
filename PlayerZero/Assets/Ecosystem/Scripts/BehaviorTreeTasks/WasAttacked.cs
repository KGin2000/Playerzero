using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class WasAttacked : Conditional
    {
        public Enemy enemy;
        public float totalDamage;
        [SerializeField] private float dmg;

        public override void OnStart()
        {
            enemy = GetComponent<Enemy>();
        }
        public override TaskStatus OnUpdate()
        {
            dmg = enemy.Damaged;
            if(totalDamage <= enemy.Damaged)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }        
    }
}
