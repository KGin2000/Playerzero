using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class IdleUntilTime : Action
    {

        public int pointOfTimeToFail;
        private int Hour;

        public override TaskStatus OnUpdate()
        {
            Hour = TimeManager.Instance.gameHour;
            if (Hour == pointOfTimeToFail)
            {
                Debug.Log(Hour);
                return TaskStatus.Failure;
            }
            return TaskStatus.Running;
        }
    }
}