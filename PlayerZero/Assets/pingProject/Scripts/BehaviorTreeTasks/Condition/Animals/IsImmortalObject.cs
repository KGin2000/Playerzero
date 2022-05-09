using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsImmortalObject : Conditional
    {        

        public override TaskStatus OnUpdate()
        {
            if (gameObject.layer == 31)
            {
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}

