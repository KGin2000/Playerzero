using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScreenManager : MonoBehaviour
{
    public Text Testtext;
    public float x;
    
    void Start()
    {
        Testtext.text = "Test : " + x.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Testtext.text = "Test : " + x.ToString();
    }
}
