using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Climation
{
    [TaskCategory("Climation")]
    public class IsWolfHot : Conditional
    {
        Climate climate;
        public float tempSaidHot;

        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("InfomationManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            if (climate.totalTemperature >= tempSaidHot)
            {
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}

