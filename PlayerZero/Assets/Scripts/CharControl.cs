using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * (speed*1.7f) * Time.deltaTime;

        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        this.transform.Translate(0,moveVertical ,moveVertical);
        this.transform.Translate(moveHorizontal,0, 0);

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        animator.SetFloat("Vertical", Input.GetAxis("Vertical") * speed * Time.deltaTime);

    }
}
