using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class IdleUntilTemp : Action
    {
        Climate climate;
        public float temp;
      
        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");
            climate = a.GetComponent<Climate>();
        }
        
        public override TaskStatus OnUpdate()
        {   
            if(climate.totalTemperature <= temp)
            {
                 return TaskStatus.Success;
            }       
            return TaskStatus.Running;
        }
    }
}