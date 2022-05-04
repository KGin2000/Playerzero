using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAi : MonoBehaviour
{
    public Animator _animator;

    private float lastXVal;
    private bool isInChaseRange;
    public GameObject a;

    void Start()
    {
        lastXVal = transform.position.x;

     
        if (a != null)
        {
            _animator = a.GetComponent<Animator>();
        }
    }
    void Update()
    {
        if (transform.position.x < lastXVal) //เดินซ้าย
        {
            _animator.SetBool("isRabbitWalkRight", false);
            _animator.SetBool("isRabbitWalkLeft", true);
            //Debug.Log("Left");
            lastXVal = transform.position.x;
        }

        else if (transform.position.x > lastXVal) //เดินขวา
        {
            _animator.SetBool("isRabbitWalkRight", true);
            _animator.SetBool("isRabbitWalkLeft", false);
            //Debug.Log("Right");
            lastXVal = transform.position.x;
        }
        
    }
}
