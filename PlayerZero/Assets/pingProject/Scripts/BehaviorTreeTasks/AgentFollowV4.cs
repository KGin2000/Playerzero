using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV4 : Action
    {
        public SharedString Mytag;
        public float colliderRange;
        public LayerMask enemyLayers;

        public SharedFloat speed;
        public SharedFloat search;
        public SharedFloat touchedDist;
        public SharedFloat fieldOfViewAngle = 360;

        private Vector3 prevDir;

        private int x;
        private int y;
        private string a;
        private string b;
        private SharedString tag;
        private SharedString enemyTag;

        public override void OnStart()
        {
            base.OnStart();
            search = colliderRange;
        }

        public override TaskStatus OnUpdate()
        {

            GameObject closest = null;
            GameObject closestEnemy = null;

            float distance = Mathf.Infinity;
            float z = Mathf.Infinity;


            Vector3 dir = Vector3.zero;

            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                a = Mytag.Value; // a = 1
                x = Convert.ToInt32(a);


                b = enemy.tag;
                y = Convert.ToInt32(b);

                if (x > y) // 1 > 0  แท็กเรามากกว่าแท็กศัตรู
                {
                    tag = b;
                    GameObject[] tags;
                    tags = GameObject.FindGameObjectsWithTag(tag.Value);
                    foreach (GameObject tag in tags)
                    {
                        Vector3 difftag = tag.transform.position - thisObjPos;
                        float curDistancetag = difftag.sqrMagnitude;
                        if (curDistancetag < distance)
                        {
                            closest = tag;
                            distance = curDistancetag;
                        }
                    }
                }
                if (x < y) // 1 < 2 แท็กเราน้อยกว่าแท็กศัตรู
                {
                    enemyTag = b;
                    GameObject[] ETags;
                    ETags = GameObject.FindGameObjectsWithTag(enemyTag.Value);
                    foreach (GameObject ETag in ETags)
                    {
                        Vector3 diffETag = ETag.transform.position - thisObjPos;
                        float curDistanceETag = diffETag.sqrMagnitude;
                        if (curDistanceETag < z)
                        {
                            closestEnemy = ETag;
                            z = curDistanceETag;
                        }
                    }
                }
            }

            if ((closest != null) || (closestEnemy != null))
            {               
                Vector3 currentPos = transform.position;

                if (closest != null)
                {
                    Vector3 targetPos = closest.transform.position;
                    Vector3 toward = targetPos - currentPos;
                    if (toward.magnitude <= touchedDist.Value)
                    {
                        return TaskStatus.Success;
                    }
                    if (toward.magnitude < search.Value)
                    {
                        dir += toward;
                    }
                }

                if (closestEnemy != null)
                {
                    Vector3 enemyPos = closestEnemy.transform.position;
                    Vector3 x = enemyPos - currentPos;
                    if (x.magnitude <= touchedDist.Value)
                    {
                        return TaskStatus.Success;
                    }
                    if (x.magnitude < search.Value)
                    {
                        dir += x;
                    }
                }
            }
            if ((closest == null) && (closestEnemy == null))
            {
                return TaskStatus.Failure;
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

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = fieldOfViewAngle.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, search.Value);

            UnityEditor.Handles.color = oldColor;
#endif
        }
    }

}