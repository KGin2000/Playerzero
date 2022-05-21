using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Animals
{
    public class IsSunrise : Conditional
    {
        Climate climate;
        public float sunLight;

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
            sunLight = climate.light;
            if(sunLight > 0)
            {
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }   
    }
}
