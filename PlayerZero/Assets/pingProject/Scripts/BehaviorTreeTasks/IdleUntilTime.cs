using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns a TaskStatus of running. Will only stop when interrupted or a conditional abort is triggered.")]
    [TaskIcon("{SkinColor}IdleIcon.png")]
    public class IdleUntilTime : Action
    {
        public Climate climate;
        public int pointOfTimeToFail;
        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            if (climate.gameHour == pointOfTimeToFail)
            {
                Debug.Log(climate.gameHour);
                return TaskStatus.Failure;
            }
            return TaskStatus.Running;
        }
    }
}