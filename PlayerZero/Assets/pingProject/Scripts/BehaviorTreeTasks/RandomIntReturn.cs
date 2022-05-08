using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.Math
{
    [TaskCategory("Unity/Math")]
    [TaskDescription("Sets a random int value")]
    public class RandomIntReturn : Action
    {
        [Tooltip("The minimum amount")]
        public SharedInt min;
        [Tooltip("The maximum amount")]
        public SharedInt max;

        public SharedInt Ans;

        [Tooltip("The variable to store the result")]
        public SharedInt storeResult;

        public override TaskStatus OnUpdate()
        {
            storeResult.Value = Random.Range(min.Value, max.Value + 1);
            if (storeResult.Value == Ans.Value)
            {
                return TaskStatus.Success;
            }          
            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            min.Value = 0;
            max.Value = 0;
            storeResult = 0;
        }
    }
}