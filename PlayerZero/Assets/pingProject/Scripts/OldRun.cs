using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class OldRun : Action
    {
        public SharedString tag;
        public SharedFloat speed;
        public SharedFloat runRange;

        private GameObject[] targetObjects;
        private Vector3 prevDir;

        public override void OnStart()
        {
            base.OnStart();

            targetObjects = GameObject.FindGameObjectsWithTag(tag.Value);
        }

        public override TaskStatus OnUpdate()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(tag.Value);

            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position; // this obj position
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }

            //Debug.Log("closest = " + closest);


            Vector3 dir = Vector3.zero;
            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;

                Vector3 toward = targetPos - currentPos;

                if (toward.magnitude > runRange.Value)
                {
                    return TaskStatus.Success;
                }
                else dir -= toward;

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