using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class IsInNight : Conditional
    {
        Climate climate;
        public int nightTime;

        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            if (climate.gameHour >= nightTime)
            {
                Debug.Log(climate.gameHour);
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}

