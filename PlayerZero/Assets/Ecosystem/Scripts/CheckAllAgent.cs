using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CheckAllAgent : SingletonMonobehaviour<CheckAllAgent>
{
    [SerializeField] public float maxTree;
    [SerializeField] public float Tree;
    [SerializeField] public int Grass;
    [SerializeField] public int Rabbit;
    [SerializeField] public int Wildboar;
    [SerializeField] public int Wolf;
    


    private float time;
    void Awake()
    {
        maxTree = GameObject.FindGameObjectsWithTag("tree").Length;
    }

    void Start()
    {
        CreateText();
        maxTree = GameObject.FindGameObjectsWithTag("tree").Length;
    }

    void Update()
    {
        Grass = GameObject.FindGameObjectsWithTag("0").Length;
        Rabbit = GameObject.FindGameObjectsWithTag("1").Length;
        Wildboar = GameObject.FindGameObjectsWithTag("2").Length;
        Wolf = GameObject.FindGameObjectsWithTag("3").Length;
        Tree = GameObject.FindGameObjectsWithTag("tree").Length;




        time += Time.deltaTime;
        if ( time >= 10.0f)
        {
            //CreateText();
            time = 0.0f;
        }
    }

    void CreateText()
    {
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }
        string content = "Login date : " + System.DateTime.Now + "\n" + "Rabbit = " + Rabbit + "\n" + "Wildboar = " + Wildboar + "\n" + "Wolf = " + Wolf + "\n\n";

        File.AppendAllText(path, content);
    }
}
