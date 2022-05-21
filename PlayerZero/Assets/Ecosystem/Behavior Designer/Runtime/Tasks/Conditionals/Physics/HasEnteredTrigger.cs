using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when an object enters the trigger. This task will only receive the physics callback if it is being reevaluated (with a conditional abort or under a parallel task).")]
    [TaskCategory("Physics")]
    public class HasEnteredTrigger : Conditional
    {
        [Tooltip("The tag of the GameObject to check for a trigger against")]
        public SharedString tag = "";
        [Tooltip("The object that entered the trigger")]
        public SharedGameObject otherGameObject;

        private bool enteredTrigger = false;

        public override TaskStatus OnUpdate()
        {
            return enteredTrigger ? TaskStatus.Success : TaskStatus.Failure;
        }

        public override void OnEnd()
        {
            enteredTrigger = false;
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (string.IsNullOrEmpty(tag.Value) || other.gameObject.CompareTag(tag.Value)) {
                Debug.Log("behavior triggerEnter");
                otherGameObject.Value = other.gameObject;
                enteredTrigger = true;
            }
        }

        public override void OnReset()
        {
            tag = "";
            otherGameObject = null;
        }
    }
}