using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class IdleUntilTime : Action
    {

        public int pointOfTimeToFail;
        public SharedBool IsSleeping;
        private int Hour;

        public override TaskStatus OnUpdate()
        {
            IsSleeping.Value = true;
            Hour = TimeManager.Instance.gameHour;
            if (Hour == pointOfTimeToFail)
            {
                Debug.Log(Hour);
                IsSleeping.Value = false;
                return TaskStatus.Failure;
            }
            return TaskStatus.Running;
        }
    }
}