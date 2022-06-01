using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AttackAgent : Action
    {

        //[SerializeField] Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
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
                if(target.Value == null)
                {
                    return TaskStatus.Failure;  
                }      
                else if (enemy.tag == "ImmortalObject")
                {
                    return TaskStatus.Failure;
                }
                else if(target.Value.tag == enemy.tag)
                {
                    if(enemy.tag == "0")
                    {
                        enemy.GetComponent<PlantStatus>().TakeDamage(attackPower);
                    }
                    else 
                    {
                        enemy.GetComponent<Enemy>().TakeDamage(attackPower);                    
                    }
                    return TaskStatus.Success;   
                }                         
            }
            return TaskStatus.Failure;  
        }       
    }
}