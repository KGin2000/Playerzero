using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float touchDistance;    

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    public Animator anim;
    private Vector3 movementV3;
    public Vector3 dir;

    private bool isInChaseRange;

    void Start()
    {
        GameObject a = GameObject.FindWithTag("sprite");
        if (a != null)
        {
            anim = a.GetComponent<Animator>();
            Debug.Log("Have Animator");
        }
        //anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        anim.SetBool("IsRunning", isInChaseRange);

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, checkRadius, whatIsPlayer);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.tag == "Player")
            {
                isInChaseRange = true;
            }
        }

        dir = target.position - transform.position;
        if(dir.magnitude <= touchDistance)
        {
            isInChaseRange = false;
        }
        dir.Normalize();
        movementV3 = dir;

        if (shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
            anim.SetFloat("Z", dir.z);
        }
    }

    private void FixedUpdate()
    {
        if(isInChaseRange)
        {
            MoveCharacter(movementV3);
        }
    }

    private void MoveCharacter(Vector3 dir)
    {
        gameObject.transform.position = (transform.position + (dir * speed * Time.deltaTime));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
