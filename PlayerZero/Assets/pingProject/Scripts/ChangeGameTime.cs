using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameTime : MonoBehaviour
{

    public float timeCount;
    public float modifiedScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = modifiedScale;
        timeCount += Time.deltaTime;
    }
}
