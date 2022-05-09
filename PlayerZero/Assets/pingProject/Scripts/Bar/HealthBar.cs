using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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
        float Health = enemy.currentHealth;
        slider.value = Health;
        slider.maxValue = enemy.maxHealth;
    }
}