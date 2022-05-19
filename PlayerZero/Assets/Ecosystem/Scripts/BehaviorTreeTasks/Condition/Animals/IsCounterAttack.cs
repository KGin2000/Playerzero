using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class IsCounterAttack : Conditional
    {
        public SharedBool isCounterAttack;


        public override void OnStart()
        {
        
        }

    
        public override TaskStatus OnUpdate()
        {
            if(isCounterAttack.Value == true)
            {
                 return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}
