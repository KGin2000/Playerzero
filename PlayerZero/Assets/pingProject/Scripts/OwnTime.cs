using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnTime : MonoBehaviour
{

    private float time;
    public int IntTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        IntTime = Mathf.RoundToInt(time);
        Debug.Log(IntTime);
    }
}
