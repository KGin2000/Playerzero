using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.OnDay
{
    [TaskCategory("OnDay")]
    public class IsInNight : Conditional
    {
        public int nightTime;
        private int Hour;

        public override TaskStatus OnUpdate()
        {
            Hour = TimeManager.Instance.gameHour;
            if (Hour >= nightTime)
            {
                //Debug.Log(Hour);
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}