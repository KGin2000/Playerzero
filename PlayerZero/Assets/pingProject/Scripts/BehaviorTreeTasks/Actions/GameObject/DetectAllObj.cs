using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAllObj : MonoBehaviour
{
    [SerializeField] private int NumBerOfCarnivore = 0;
    [SerializeField] private int NumBerOfHerbivore = 0;

    void Start()
    {
        
    }

    void Update()
    {
        NumBerOfCarnivore = GameObject.FindGameObjectsWithTag("Carnivore").Length;
        Debug.Log("NumBerOfCarnivore" + NumBerOfCarnivore);

        NumBerOfHerbivore = GameObject.FindGameObjectsWithTag("Herbivore").Length;
        Debug.Log("NumBerOfHerbivore" + NumBerOfHerbivore);
    }
}
