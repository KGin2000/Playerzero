using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class CoolDown : Action
    {
        public SharedInt count;

        public override void OnStart()
        {
            count.Value = Random.Range(0, 2);
        }
        public override TaskStatus OnUpdate()
        {
            if(count.Value == 1)
            {
                Debug.Log("successs");
                return TaskStatus.Success;
            }
            Debug.Log("Faill");
            return TaskStatus.Failure;
        }
    }
}
