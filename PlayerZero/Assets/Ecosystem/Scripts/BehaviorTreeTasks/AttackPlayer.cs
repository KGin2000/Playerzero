using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AttackPlayer : Action
    {
        public SharedGameObject target;
        public int attackPower;
        
        public override void OnStart()
        {

        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
            if(target.Value.tag == "Player")
            {
                PlayerStatus.Instance.TakeDamage(attackPower);
                return TaskStatus.Success;
            } 
            return TaskStatus.Failure;                       
        }
    }
}
