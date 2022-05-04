using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BehaviorDesigner.Runtime.Tasks.Movement
{    

    public class NewWander : Action
    {
        public SharedFloat speed;

        public SharedFloat minWanderDistance = 20;
        public SharedFloat maxWanderDistance = 20;
        public SharedFloat wanderRate = 2;
        public SharedFloat minPauseDuration = 0;
        public SharedFloat maxPauseDuration = 0;
        public float pauseTime;

        private Animator animator;
        private float lastXVal;
        private float time;
        private bool randomPos = false;
        private bool randomTime = false;
        private Vector3 newPos;
        private Vector3 direction;
        private Vector3 destination;

        public SharedBool findNewPos = false;

        public override void OnAwake()
        {
            GameObject a = this.gameObject.transform.GetChild(0).gameObject;
            animator = a.GetComponent<Animator>();
        }
        public override void OnStart()
        {
            lastXVal = transform.position.x;
        }

        public override TaskStatus OnUpdate()
        {
 
            if (maxPauseDuration.Value > 0)
            {
                if (randomTime == false)
                {
                    pauseTime = Random.Range(minPauseDuration.Value, maxPauseDuration.Value);
                    randomTime = true;                                      
                }

                if (randomTime == true)
                {
                    pauseTime -= Time.deltaTime;
                    if (pauseTime <= 0f)
                    {
                        if (randomPos == false)
                        {
                            randomPosition();
                            randomPos = true;

                        }
                        else if (randomPos == true)
                        {
                            walkToPos();
                            if (transform.position == destination)
                            {
                                randomPos = false;
                                randomTime = false;
                            }
                        }
                    }
                }

            }
            else if (maxPauseDuration.Value <= 0)
            {
                if (findNewPos.Value == true)
                {
                    randomPosition();
                    randomPos = false;
                    findNewPos.Value = false;
                    //Debug.Log("aaaaaaaaaaaaaaaaaaaaaaa");
                }

                if (randomPos == false)
                {
                    randomPosition();
                    randomPos = true;
                    //Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbb");
                }

                else if (randomPos == true)
                {
                    walkToPos();
                    if (transform.position == destination)
                    {
                        randomPos = false;
                        return TaskStatus.Success;
                        //Debug.Log("CCCCCCCCCCCCCCCCCCCCCCCCCCC");
                    }
                }
            }           
            return TaskStatus.Running;
        }

        void randomPosition()
        {
            direction = transform.forward;
            direction = direction + Random.insideUnitSphere * wanderRate.Value;            
            //Debug.Log(newPos);
        }

       void walkToPos()
        {
            destination = transform.position;
            destination = transform.forward + direction.normalized * Random.Range(minWanderDistance.Value, maxWanderDistance.Value); // เดินไปทิศนั้น
            destination.y = 0;
        }
        public override void OnReset()
        {
            minWanderDistance = 20;
            maxWanderDistance = 20;
            wanderRate = 2;
        }
    }
}