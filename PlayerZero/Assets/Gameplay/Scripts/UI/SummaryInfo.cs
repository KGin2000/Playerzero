using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryInfo : MonoBehaviour
{
    [SerializeField] float NumofTree_Start;
    [SerializeField] int NumofRabbit_Start;
    [SerializeField] int NumofBoar_Start;
    [SerializeField] int NumofWolf_Start;

    [SerializeField] float NumofTree_Lastest;
    [SerializeField] int NumofRabbit_Lastest;
    [SerializeField] int NumofBoar_Lastest;
    [SerializeField] int NumofWolf_Lastest;

    public string treeRatio;
    public string rabbitRatio;
    public string boarRatio;
    public string wolfRatio;

    public float HighestTemp;
    public float LowestTemp;

    public Text NumTree;
    public Text TreeRatio;
    public Text NumRabbit;
    public Text RabbitRatio;
    public Text NumBoar;
    public Text BoarRatio;
    public Text NumWolf;
    public Text WolfRatio;

    public Text TextHighestTemp;
    public Text TextLowestTemp;

    [SerializeField] GameObject CloseButton;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject QuitButton;


    void Start()
    {
        
    }

    void Update()
    {
        GetInfo();
        CalculateInfo();
        UISummary();

        if(TimeManager.Instance.gameDay == 30 && TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        {
            UIManager.Instance.EnableSummary();
            PlayButton.SetActive(true);
            QuitButton.SetActive(true);
        }
    }

    private void GetInfo()
    {
        NumofTree_Lastest = DebugScreenManager.Instance.NumberOfTree;
        NumofRabbit_Lastest = DebugScreenManager.Instance.NumberOfRabbit;
        NumofBoar_Lastest = DebugScreenManager.Instance.NumberOfWildboar;
        NumofWolf_Lastest = DebugScreenManager.Instance.NumberOfWolf;

        HighestTemp = Climate.Instance.HighestTemp;
        LowestTemp = Climate.Instance.LowestTemp;
    }

    void UISummary()
    {
        NumTree.text = "จำนวนต้นไม้ (ปัจจุบัน) = " + NumofTree_Lastest + " ต้น";
        NumRabbit.text = "จำนวนกระต่าย (ปัจจุบัน) = " + NumofRabbit_Lastest + " ตัว";
        NumBoar.text = "จำนวนหมูป่า (ปัจจุบัน) = " + NumofBoar_Lastest + " ตัว";
        NumWolf.text = "จำนวนหมาป่า (ปัจจุบัน) = " + NumofWolf_Lastest + " ตัว";

        TreeRatio.text = treeRatio.ToString();
        RabbitRatio.text = rabbitRatio.ToString();
        BoarRatio.text = boarRatio.ToString();
        WolfRatio.text = wolfRatio.ToString();

        TextHighestTemp.text = "อุณหภูมิสูงสุด : " + HighestTemp + " องศา";
        TextLowestTemp.text = "อุณหภูมิต่ำสุด : " + LowestTemp + " องศา"; 
    }

    private void CalculateInfo()
    {
        Tree_Ratio();
        Rabbit_Ratio();
        Boar_Ratio();
        Wolf_Ratio();
    }

    void Tree_Ratio()
    {   
        float percentTree = (NumofTree_Lastest / NumofTree_Start)*100;
        if (NumofTree_Lastest < NumofTree_Start)
        {
            treeRatio = "ปริมาณต้นไม้ ลดลง = " + (100 - percentTree) + "%";
        }
        else if (NumofTree_Lastest > NumofTree_Start)
        {
            treeRatio = "ปริมาณต้นไม้ เพิ่มขึ้น = " + (percentTree - 100) + "%";
        }
        else if (NumofTree_Lastest == NumofTree_Start)
        {
            treeRatio = "ปริมาณต้นไม้ เท่าเดิม";
        }
    }

    void Rabbit_Ratio()
    {
        float percentRabbit = (NumofRabbit_Lastest / NumofRabbit_Start)*100;
            if(NumofRabbit_Lastest < NumofRabbit_Start)
            {
                rabbitRatio = "จำนวนกระต่าย ลดลง = " + (100 - percentRabbit) + "%";
            }
            else if(NumofRabbit_Lastest > NumofRabbit_Start)
            {
                rabbitRatio = "จำนวนกระต่าย เพิ่มขึ้น = " + (percentRabbit - 100) + "%";
            }
            else if(NumofRabbit_Lastest == NumofRabbit_Start)
            {
                rabbitRatio = "จำนวนกระต่าย เท่าเดิม";
            }
    }

    void Boar_Ratio()
    {
        float percentTBoar = (NumofBoar_Lastest / NumofBoar_Start)*100;
            if(NumofBoar_Lastest < NumofBoar_Start)
            {
                boarRatio = "จำนวนหมูป่า ลดลง = " + (100 - percentTBoar) + "%";
            }
            else if(NumofBoar_Lastest > NumofBoar_Start)
            {
                boarRatio = "จำนวนหมูป่า เพิ่มขึ้น = " + (percentTBoar - 100) + "%";
            }
            else if(NumofBoar_Lastest == NumofBoar_Start)
            {
                boarRatio = "จำนวนหมูป่า เท่าเดิม";
            }
    }

    void Wolf_Ratio()
    {
        float percentTWolf = (NumofWolf_Lastest / NumofWolf_Start)*100;
            if(NumofWolf_Lastest < NumofWolf_Start)
            {
                wolfRatio = "จำนวนหมาป่า ลดลง = " + (100 - percentTWolf) + "%";
            }
            else if(NumofWolf_Lastest > NumofWolf_Start)
            {
                wolfRatio = "จำนวนหมาป่า เพิ่มขึ้น = " + (percentTWolf - 100) + "%";
            }
            else if(NumofWolf_Lastest == NumofWolf_Start)
            {
                wolfRatio = "จำนวนหมาป่า เท่าเดิม";
            }
    }
}
