using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.OnDay
{
    [TaskCategory("OnDay")]
    public class IsInMoring : Conditional
    {
        public int morningTime;
        private int Hour;

        public override TaskStatus OnUpdate()
        {
            Hour = TimeManager.Instance.gameHour;
            if (Hour >= morningTime)
            {
                //Debug.Log(Hour);
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}