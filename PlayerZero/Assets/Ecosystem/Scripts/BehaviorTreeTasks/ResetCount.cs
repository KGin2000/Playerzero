using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class ResetCount : Conditional
    {
        public SharedInt resetCount;
        public SharedInt resetVar;
        public override void OnStart()
        {
            resetCount.Value = resetVar.Value;
        }

        public override TaskStatus OnUpdate()
        {
            resetCount.Value = resetVar.Value;
            return TaskStatus.Failure;
        }
    }
}
