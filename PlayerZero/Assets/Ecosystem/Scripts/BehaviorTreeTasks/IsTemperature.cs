using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    [TaskCategory("Animals")]
    public class IsTemperature : Conditional
    {
        Climate climate;
        public bool Hot = false;
        public float highTemp;
        public bool Cold = false;
        public float lowTemp;

        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");
            climate = a.GetComponent<Climate>();
        }

        public override void OnStart()
        {
            
        }

        public override TaskStatus OnUpdate()
        {
            if(Hot)
            {
                if (climate.totalTemperature >= highTemp)
                {
                    return TaskStatus.Success;
                }
                else return TaskStatus.Failure;
            }
            else if(Cold)
            {
                if (climate.totalTemperature <= lowTemp)
                {
                    return TaskStatus.Success;
                }
                else return TaskStatus.Failure;
            }
            return TaskStatus.Failure;
        }

       
    }
}
