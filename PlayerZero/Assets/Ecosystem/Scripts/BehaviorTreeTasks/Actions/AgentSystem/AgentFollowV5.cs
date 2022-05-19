using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV5 : Action
    {
        public SharedFloat speed;
        public SharedFloat search;
        public SharedFloat touchedDist;
        public SharedGameObject targetObject;
        public SharedBool IsRunning;

        private Vector3 prevDir;

        public override void OnStart()
        {

        }
        public override TaskStatus OnUpdate()
        {
            IsRunning.Value = true;
            Vector3 dir = Vector3.zero;
            GameObject x = targetObject.Value;
            //Vector3 targetPosition = targetObject.transform.position;
            Vector3 currentPosition = transform.position;
            Vector3 toward = x.transform.position - transform.position;

            if (toward.magnitude < touchedDist.Value)
            {
                IsRunning.Value = false;
                return TaskStatus.Success;
            }
            if (toward.magnitude < search.Value)
            {
                dir += toward;
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
            IsRunning.Value = false;
        }
    }
}
