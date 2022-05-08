using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class IsHot : Conditional
    {
        Climate climate;
        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            if (climate.lastTemperature >= 30f)
            {
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}

