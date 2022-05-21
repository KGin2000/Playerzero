using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScreenManager : MonoBehaviour
{
    public Text Rabbit;
    public Text Boar;
    public Text Wolf;
    public Text Tree;
    public int NumberOfRabbit;
    public int NumberOfWildboar;
    public int NumberOfWolf;
    public int NumberOfTree;
    
    void Start()
    {
        // Testtext.text = "Test : " + x.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfRabbit = CheckAllAgent.Instance.Rabbit;
        NumberOfWildboar = CheckAllAgent.Instance.Wildboar;
        NumberOfWolf = CheckAllAgent.Instance.Wolf;
        //NumberOfTree = CheckAllAgent.Instance.Tree;

        Rabbit.text = "Rabbit : " + NumberOfRabbit.ToString();
        Boar.text = "Boar : " + NumberOfWildboar.ToString();
        Wolf.text = "Wolf : " + NumberOfWolf.ToString();
        Tree.text = "Tree : " + NumberOfTree.ToString();
    }
}
