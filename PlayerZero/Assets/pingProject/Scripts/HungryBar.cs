using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Enemy enemy;

    void Start()
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        int Hungry = enemy.currentHungryPoint;
        slider.value = Hungry;
        slider.maxValue = enemy.maxHungryPoint;
    }
}