using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowAction : Action
    {
        public SharedString tag;
        public SharedFloat speed;
        public SharedFloat search;
        public SharedFloat touchedDist;

        private GameObject[] targetObjects;
        private Vector3 prevDir;

        public override void OnStart()
        {
            base.OnStart();

            targetObjects = GameObject.FindGameObjectsWithTag(tag.Value);
        }
        
        public override TaskStatus OnUpdate()
        {
            Vector3 dir = Vector3.zero;

            foreach (GameObject targetObject in targetObjects)
            {
                Vector3 targetPos = targetObject.transform.position;
                Vector3 currentPos = transform.position; // this obj position

                Vector3 toward = targetPos - currentPos;
                if (toward.magnitude < touchedDist.Value)
                {
                    return TaskStatus.Success;
                }                           

                if (toward.magnitude < search.Value)
                {
                    dir += toward;
                }
            }
            dir.Normalize();
            dir = dir * speed.Value * Time.deltaTime;
            dir = Vector3.Lerp(prevDir, dir, 0.2f);
            transform.position += dir;
            prevDir = dir;
            return TaskStatus.Running;            
        }

        public override void OnReset()
        {
            base.OnReset();
        }
    }
}