using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class IsInMoring : Conditional
    {
        public Climate climate;
        public int morningTime;
        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            //Debug.Log(climate.Hour);
            if (climate.gameHour >= morningTime)
            {
                //Debug.Log(climate.Hour);
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}