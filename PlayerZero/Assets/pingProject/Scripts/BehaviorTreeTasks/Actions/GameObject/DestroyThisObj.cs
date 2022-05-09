using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject
{
    [TaskCategory("Unity/GameObject")]
    [TaskDescription("Destorys the specified GameObject. Returns Success.")]
    public class DestroyThisObj : Action
    {        
        public int time; // time to die 

        public override TaskStatus OnUpdate()
        {           
            GameObject.Destroy(gameObject, time);
            return TaskStatus.Success;
        }

        public override void OnReset()
        {

        }
    }
}