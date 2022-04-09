using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonAnimation : MonoBehaviour
{
    
    int x;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        x = TimeManager.Instance.gameHour;
    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X = "+ x);
            Debug.Log("X");
            //TestAnimator.Instance.CallMe();
            //StartCoroutine(GetComponent<TestAnimator>().ExampleCoroutine());
        }
    }
}
