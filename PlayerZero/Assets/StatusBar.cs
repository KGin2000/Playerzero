using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Slider Bar;

    public void Set(int curr, int max)
    {
        Bar.maxValue = max;
        Bar.value = curr;

        text.text = max.ToString() + "/" + curr.ToString();
    }
}
