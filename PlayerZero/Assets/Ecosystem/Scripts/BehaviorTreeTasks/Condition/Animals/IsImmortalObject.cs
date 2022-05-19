using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsImmortalObject : Conditional
    {        
        public SharedString getStatus;
        public override TaskStatus OnUpdate()
        {
            if (gameObject.layer == 31)
            {
                if(getStatus.Value == "Run")
                {
                    
                    return TaskStatus.Success;
                }
                 //return TaskStatus.Failure;
            }
            return TaskStatus.Failure;

        }
            
    }
}

