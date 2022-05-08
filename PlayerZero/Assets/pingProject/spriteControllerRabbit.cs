using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteControllerRabbit : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    [SerializeField] private string Tag;

    private float lastXVal;
    private bool isInChaseRange;


    void Start()
    {
        lastXVal = transform.position.x;
        GameObject baseObject = GameObject.FindWithTag(Tag);
        if (baseObject != null)
        {
            rb = baseObject.GetComponent<Rigidbody>();
        }

        GameObject a = GameObject.FindWithTag("sprite");
        if (a != null)
        {
            anim = a.GetComponent<Animator>();
        }
    }
    void Update()
    {

        //if (transform.hasChanged)
        //{            
        //Debug.Log("anim.SetBool");

        if (transform.position.x < lastXVal) //เดินซ้าย
        {
            anim.SetBool("rabbit_walkRight", false);
            anim.SetBool("rabbit_walkLeft", true);
            Debug.Log("Left");
            lastXVal = transform.position.x;
        }

        else if (transform.position.x > lastXVal) //เดินขวา
        {
            anim.SetBool("rabbit_walkRight", true);
            anim.SetBool("rabbit_walkLeft", false);
            Debug.Log("Right");
            lastXVal = transform.position.x;
        }

        //transform.hasChanged = false;
        //}

    }
}
