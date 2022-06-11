using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryInfo : MonoBehaviour
{
    #region     //SetValue
    [SerializeField] float NumofTree_Start;
    [SerializeField] float NumofRabbit_Start;
    [SerializeField] float NumofBoar_Start;
    [SerializeField] float NumofWolf_Start;
    [SerializeField] float NumofGrass_Start;

    [SerializeField] float NumofTree_Lastest;
    [SerializeField] float NumofRabbit_Lastest;
    [SerializeField] float NumofBoar_Lastest;
    [SerializeField] float NumofWolf_Lastest;
    [SerializeField] float NumofGrass_Lastest;

    [SerializeField] float Coin_MaxScore;
    float Coin_Lastest;

    int ScoreTree;
    int ScoreGrass;
    int ScoreRabbit;
    int ScoreBoar;
    int ScoreWolf;
    int ScoreCoin;

    public int ScoreEndGame;

    public string treeRatio;
    public string rabbitRatio;
    public string boarRatio;
    public string wolfRatio;

    public float HighestTemp;
    public float LowestTemp;

    #endregion

    #region     //GetText
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

    public Text TreeScore;
    public Text GrassScore;
    public Text RabbitScore;
    public Text BoarScore;
    public Text WolfScore;
    public Text CoinScore;
    public Text GradeScore;
    string Grade;

    #endregion

    [SerializeField] GameObject SummaryInfoMan;
    [SerializeField] GameObject SummaryEndDemo;

    void Start()
    {
        
    }

    void Update()
    {
        GetInfo();
        CalculateInfo();
        UISummary();

        // if(TimeManager.Instance.gameDay == 30 && TimeManager.Instance.gameHour == 12 && TimeManager.Instance.gameMinute == 0)
        // {
        //     UIManager.Instance.EnableSummary();
        //     SummaryEndDemo.SetActive(true);
        //     SummaryInfoMan.SetActive(false);
        // }

        ShowInfoEndGame();

    }

    private void ShowInfoEndGame()
    {
        CalculateEndGame();

        TreeScore.text = ScoreTree + "/15";
        GrassScore.text = ScoreGrass + "/15";
        RabbitScore.text = ScoreRabbit + "/15";
        BoarScore.text = ScoreBoar + "/15";
        WolfScore.text = ScoreWolf + "/15";
        CoinScore.text = ScoreCoin + "/25";

        GradeScore.text = Grade;
    }

    private void CalculateEndGame()
    {
        if(NumofTree_Lastest < NumofTree_Start)
        {
            ScoreTree = (int)((NumofTree_Lastest/NumofTree_Start) * 15f);
        }
        else if(NumofTree_Lastest >= NumofTree_Start)
        {
            ScoreTree = 15;
        }

        if(NumofGrass_Lastest < NumofGrass_Start)
        {
            ScoreGrass = (int)((NumofGrass_Lastest/NumofGrass_Start) * 15f);
        }
        else if(NumofGrass_Lastest >= NumofGrass_Start)
        {
            ScoreGrass = 15;
        }

        if(NumofRabbit_Lastest < NumofRabbit_Start)
        {
            ScoreRabbit = (int)((NumofRabbit_Lastest/NumofRabbit_Start) * 15f);
        }
        else if(NumofRabbit_Lastest >= NumofRabbit_Start)
        {
            ScoreRabbit = 15;
        }

        if(NumofBoar_Lastest < NumofBoar_Start)
        {
            ScoreBoar = (int)((NumofBoar_Lastest/NumofBoar_Start) * 15f);
        }
        else if(NumofBoar_Lastest >= NumofBoar_Start)
        {
            ScoreBoar = 15;
        }        
        
        if(NumofWolf_Lastest < NumofWolf_Start)
        {
            ScoreWolf = (int)((NumofWolf_Lastest/NumofWolf_Start) * 15f);
        }
        else if(NumofWolf_Lastest >= NumofWolf_Start)
        {
            ScoreWolf = 15;
        }  
       
        if(Coin_Lastest < Coin_MaxScore)
        {
            ScoreCoin = (int)((Coin_Lastest/Coin_MaxScore)*25);
        }
        else if(Coin_Lastest >= Coin_MaxScore)
        {
            ScoreCoin = 25;
        }

        ScoreEndGame = ScoreTree + ScoreGrass + ScoreRabbit + ScoreBoar + ScoreWolf + ScoreCoin;

        if(ScoreEndGame >= 80)
        {
            Grade = "A";
        }
        else if(ScoreEndGame < 80 && ScoreEndGame >= 60)
        {
            Grade = "B";
        }
        else if(ScoreEndGame < 60 && ScoreEndGame >= 40)
        {
            Grade = "C";
        }
        else if(ScoreEndGame < 40 && ScoreEndGame >= 20)
        {
            Grade = "D";
        }
        else if(ScoreEndGame < 20)
        {
            Grade = "E";
        }
    }

    public void Play_Button()
    {
        UIManager.Instance.DisableSummary();
        SummaryEndDemo.SetActive(false);
        SummaryInfoMan.SetActive(true);
    }
    

    private void GetInfo()
    {
        NumofTree_Lastest = DebugScreenManager.Instance.NumberOfTree;
        NumofRabbit_Lastest = (float)(DebugScreenManager.Instance.NumberOfRabbit);
        NumofBoar_Lastest = (float)DebugScreenManager.Instance.NumberOfWildboar;
        NumofWolf_Lastest = (float)DebugScreenManager.Instance.NumberOfWolf;
        NumofGrass_Lastest = (float)DebugScreenManager.Instance.NumberOfGrass;

        Coin_Lastest = ShopManagerScript.Instance.coins;

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

        TextHighestTemp.text = "อุณหภูมิสูงสุด : " + string.Format("{0:0.##}", HighestTemp)  + " องศา";
        TextLowestTemp.text = "อุณหภูมิต่ำสุด : " + string.Format("{0:0.##}", LowestTemp)  + " องศา"; 
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
            
            treeRatio = "ปริมาณต้นไม้ ลดลง = " + string.Format("{0:0.##}", (100 - percentTree)) + "%";
        }
        else if (NumofTree_Lastest > NumofTree_Start)
        {
            treeRatio = "ปริมาณต้นไม้ เพิ่มขึ้น = " + string.Format("{0:0.##}", (percentTree - 100)) + "%";
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
                rabbitRatio = "จำนวนกระต่าย ลดลง = " + string.Format("{0:0.##}", (100 - percentRabbit)) + "%";
            }
            else if(NumofRabbit_Lastest > NumofRabbit_Start)
            {
                rabbitRatio = "จำนวนกระต่าย เพิ่มขึ้น = " + string.Format("{0:0.##}", (percentRabbit - 100)) + "%";
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
                boarRatio = "จำนวนหมูป่า ลดลง = " + string.Format("{0:0.##}", (100 - percentTBoar)) + "%";
            }
            else if(NumofBoar_Lastest > NumofBoar_Start)
            {
                boarRatio = "จำนวนหมูป่า เพิ่มขึ้น = " + string.Format("{0:0.##}", (percentTBoar - 100)) + "%";
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
                wolfRatio = "จำนวนหมาป่า ลดลง = " + string.Format("{0:0.##}", (100 - percentTWolf)) + "%";
            }
            else if(NumofWolf_Lastest > NumofWolf_Start)
            {
                wolfRatio = "จำนวนหมาป่า เพิ่มขึ้น = " + string.Format("{0:0.##}", (percentTWolf - 100)) + "%";
            }
            else if(NumofWolf_Lastest == NumofWolf_Start)
            {
                wolfRatio = "จำนวนหมาป่า เท่าเดิม";
            }
    }
}
