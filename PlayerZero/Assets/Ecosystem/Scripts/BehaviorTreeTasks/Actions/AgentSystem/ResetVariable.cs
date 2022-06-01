using UnityEngine;
namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class ResetVariable : Action
    {
        public SharedBool boolVar;
        public SharedInt IntVar;
        public SharedFloat floatVar;
        public float setFloat;
        public SharedGameObject gameObjectVar1;
        public SharedGameObject gameObjectVar2;
        public SharedString status;

        public override void OnStart()
        {
        
        }


        public override TaskStatus OnUpdate()
        {
            if(status.Value != null)
            {
                status.Value = null;
            }
            if(gameObjectVar1.Value)
            {
                gameObjectVar1.Value = null;               
            }
            if(gameObjectVar2.Value)
            {
                gameObjectVar2.Value = null;               
            }
            
            floatVar.Value = setFloat;
            return TaskStatus.Success;
        }
    }   
}
