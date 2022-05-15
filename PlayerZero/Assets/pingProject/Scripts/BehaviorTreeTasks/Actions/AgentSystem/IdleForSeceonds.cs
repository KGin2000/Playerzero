using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class IdleForSeceonds : Action
    {
        public float Seconds;
        private float x;

        public override void OnStart()
        {
            x= Seconds;
        }

        public override TaskStatus OnUpdate()
        {
            if(x != null)
            {
                x -= Time.deltaTime;;
                if(x <= 0)
                {
                    x = 0;
                    return TaskStatus.Failure;
                }
            }
            return TaskStatus.Running;
        }
    }
}