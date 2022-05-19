using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AttackObject : Action
    {

        //[SerializeField] Transform attackPoint;
        [SerializeField] float attackRange = 0.5f;
        [SerializeField] LayerMask enemyLayers;
        public int attackPower;
        
        public SharedGameObject target;
        
        public override void OnStart()
        {
        
        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.tag == "ImmortalObject")
                {
                    return TaskStatus.Failure;
                }
                else if(target.Value.tag == enemy.tag)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackPower);
                    //enemy.gameObject.GetComponent<Enemy>().CounterAttack(gameObject);
                    return TaskStatus.Success;                                           
                }
                else if(target.Value == null)
                {
                    return TaskStatus.Failure;  
                }                   
            }
            return TaskStatus.Failure;  
        }       
    }
}