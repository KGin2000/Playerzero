using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScreenManager : SingletonMonobehaviour<DebugScreenManager>
{
    public Text Rabbit;
    public Text Boar;
    public Text Wolf;
    public Text Tree;
    public Text Grass;
    public int NumberOfRabbit;
    public int NumberOfWildboar;
    public int NumberOfWolf;
    public float NumberOfTree;
    public int NumberOfGrass;
    
    void Start()
    {
        // Testtext.text = "Test : " + x.ToString();
    }

    public void GetData(int Rabbit, int Boar, int Wolf,int Grass,float Tree)
    {
        NumberOfRabbit = Rabbit;
        NumberOfWildboar = Boar;
        NumberOfWolf = Wolf;
        NumberOfGrass = Grass;
        NumberOfTree = Tree;
    }

    // Update is called once per frame
    void Update()
    {
        // NumberOfRabbit = CheckAllAgent.Instance.Rabbit;
        // NumberOfWildboar = CheckAllAgent.Instance.Wildboar;
        // NumberOfWolf = CheckAllAgent.Instance.Wolf;
        // //NumberOfTree = CheckAllAgent.Instance.Tree;

        Rabbit.text = "Rabbit : " + NumberOfRabbit.ToString();
        Boar.text = "Boar : " + NumberOfWildboar.ToString();
        Wolf.text = "Wolf : " + NumberOfWolf.ToString();
        Tree.text = "Tree : " + NumberOfTree.ToString();
        Grass.text = "Grass : " + NumberOfGrass.ToString();
    }
}
