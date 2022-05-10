using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsLowHp : Conditional
    {
        // Start is called before the first frame update
        public override void OnStart()
        {

        }

        // Update is called once per frame
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.Failure;
        }
    }
}
