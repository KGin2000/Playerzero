using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Climation
{
    [TaskCategory("Climation")]
    public class IsHot : Conditional
    {
        Climate climate;
        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("InfomationManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            if (climate.totalTemperature >= 30f)
            {
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}

