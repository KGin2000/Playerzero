using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class testCondition : Action
    {
        public Enemy ememy;
        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Min,
            Max,
            Modulo
        }
    }
}

