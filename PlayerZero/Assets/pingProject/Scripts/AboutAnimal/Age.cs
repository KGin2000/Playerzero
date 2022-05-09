using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Age : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float age; //second


    // Start is called before the first frame update
    void Start()
    {
        time = age;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        Destroy(gameObject, age);
    }
}
