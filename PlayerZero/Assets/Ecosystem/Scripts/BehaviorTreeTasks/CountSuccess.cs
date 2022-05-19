using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CountSuccess : Conditional
    {
        public SharedInt countSuccess;

        public override void OnStart()
        {

        }
        public override TaskStatus OnUpdate()
        {
            if(countSuccess.Value != 0)
            {
                countSuccess.Value -=1;
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}
