using UnityEngine;
namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class ResetVariable : Action
    {
        public SharedBool boolVar;
        public SharedInt IntVar;
        public SharedGameObject gameObjectVar;

        public override void OnStart()
        {
        
        }


        public override TaskStatus OnUpdate()
        {
            if(gameObjectVar.Value)
            {
                gameObjectVar.Value = null;
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }   
}
