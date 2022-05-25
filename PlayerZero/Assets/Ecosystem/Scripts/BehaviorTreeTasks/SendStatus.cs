using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class SendStatus : Action
    {
        public SharedString Status;
        public string statusToSend;

        public override TaskStatus OnUpdate()
        {
            if(statusToSend != null)
            {
                Status.Value = statusToSend;
                //Debug.Log("ผ่านนนนนนนนน");
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
            
            
            
        }
    }
}

