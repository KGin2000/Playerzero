using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScreenManager : SingletonMonobehaviour<DebugScreenManager>
{
    #region  // Text UI

    //Rabbit
    public Text NumberOfRabbitText;
    public Text NumberOfRabbit_AllText;
    public Text RabbitKilledText;
    public Text RabbitStarveText;
    public Text RabbitDefunctText;
    public Text RabbitImmigrationText;
    public Text NumberOfRabbit_ImmigrationText;
    public Text NumberOfRabbit_HeirText;

    //WildBoar
    public Text NumberOfWildboarText;
    public Text NumberOfWildboar_AllText;
    public Text WildboarKilledText;
    public Text WildboarStarveText;
    public Text WildboarDefunctText;
    public Text WildboarImmigrationText;
    public Text NumberOfWildboar_ImmigrationText;
    public Text NumberOfWildboar_HeirText;

    public Text NumberOfWolfText;
    public Text NumberOfWolf_AllText;
    public Text WolfKilledText;
    public Text WolfStarveText;
    public Text WolfDefunctText;
    public Text WolfImmigrationText;
    public Text NumberOfWolf_ImmigrationText;
    public Text NumberOfWolf_HeirText;

    public Text NumberOfTreeText;
    public Text NumberOfGrassText;

    public Text TemperatureText;

    

    #endregion

    #region         //ตัวแปร
    public int NumberOfRabbit;
    public int NumberOfWildboar;
    public int NumberOfWolf;
    public float NumberOfTree;
    public int NumberOfGrass;

    public float Temperature;

    public int RabbitImmigration;
    public int BoarImmigration;
    public int WolfImmigration;

    public int RabbitKilled;
    public int RabbitStarve;
    public int RabbitDefunct;

    public int BoarKilled;
    public int BoarStarve;
    public int BoarDefunct;

    public int WolfKilled;
    public int WolfStarve;
    public int WolfDefunct;

     int NumberOfRabbit_Old;
     int NumberOfWildboar_Old;
     int NumberOfWolf_Old;

    public int NumberOfRabbit_All;
    public int NumberOfWildboar_All;
    public int NumberOfWolf_All;

    public int NumberOfRabbit_Immigration;
    public int NumberOfWildboar_Immigration;
    public int NumberOfWolf_Immigration;

    public int NumberOfRabbit_Heir;
    public int NumberOfWildboar_Heir;
    public int NumberOfWolf_Heir;


    #endregion
    
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

        CheckIncreaseAnimal();
    }

    public void GetDataTemp(float totalTemperature)
    {
        Temperature = totalTemperature;
    }

    // Update is called once per frame
    void Update()
    {
        // NumberOfRabbit = CheckAllAgent.Instance.Rabbit;
        // NumberOfWildboar = CheckAllAgent.Instance.Wildboar;
        // NumberOfWolf = CheckAllAgent.Instance.Wolf;
        // //NumberOfTree = CheckAllAgent.Instance.Tree;

        DebugScreenTextUI();

        NumberofAnimalChild();
    }

    void DebugScreenTextUI()
    {
        // Rabbit.text = "Rabbit : " + NumberOfRabbit.ToString();
        // Boar.text = "Boar : " + NumberOfWildboar.ToString();
        // Wolf.text = "Wolf : " + NumberOfWolf.ToString();
        // Tree.text = "Tree : " + NumberOfTree.ToString();
        // Grass.text = "Grass : " + NumberOfGrass.ToString();
        // Temp.text = "Temperature : " + Temperature.ToString() + " ํC";

        //Rabbit
        NumberOfRabbitText.text = "Rabbit : " + NumberOfRabbit.ToString();
        NumberOfRabbit_AllText.text = "All : " + NumberOfRabbit_All.ToString();
        RabbitKilledText.text = "Killed : " + RabbitKilled.ToString();
        RabbitStarveText.text = "Starve : " + RabbitStarve.ToString();
        RabbitDefunctText.text = "Defunct :" + RabbitDefunct.ToString();
        RabbitImmigrationText.text = "Immigration : " + RabbitImmigration.ToString();
        NumberOfRabbit_ImmigrationText.text = "NumIm : " + NumberOfRabbit_Immigration.ToString();
        NumberOfRabbit_HeirText.text = "Heir : " + NumberOfRabbit_Heir.ToString();

        //WildBoar
        NumberOfWildboarText.text = "Boar : " + NumberOfWildboar.ToString();
        NumberOfWildboar_AllText.text = "All : " + NumberOfWildboar_All.ToString();
        WildboarKilledText.text = "Killed : " + BoarKilled.ToString();
        WildboarStarveText.text = "Starve : " + BoarStarve.ToString();
        WildboarDefunctText.text = "Defunct :" + BoarDefunct.ToString();
        WildboarImmigrationText.text = "Immigration : " + BoarImmigration.ToString();
        NumberOfWildboar_ImmigrationText.text = "NumIm : " + NumberOfWildboar_Immigration.ToString();
        NumberOfWildboar_HeirText.text = "Heir : " + NumberOfWildboar_Heir.ToString();

        //Wolf
        NumberOfWolfText.text = "Wolf : " + NumberOfWolf.ToString();
        NumberOfWolf_AllText.text = "All : " + NumberOfWolf_All.ToString();
        WolfKilledText.text = "Killed : " + WolfKilled.ToString();
        WolfStarveText.text = "Starve : " + WolfStarve.ToString();
        WolfDefunctText.text = "Defunct :" + WolfDefunct.ToString();
        WolfImmigrationText.text = "Immigration : " + WolfImmigration.ToString();
        NumberOfWolf_ImmigrationText.text = "NumIm : " + NumberOfWolf_Immigration.ToString();
        NumberOfWolf_HeirText.text = "Heir : " + NumberOfWolf_Heir.ToString();

        NumberOfTreeText.text = "NumTree : " + NumberOfTree.ToString();
        NumberOfGrassText.text = "NumGrass : " + NumberOfGrass.ToString();

        TemperatureText.text = "Temperature : " + Temperature.ToString() + " ํC";
    }

    public void CheckImmigration(int Rabbit, int Boar, int Wolf)
    {
        RabbitImmigration += Rabbit;
        BoarImmigration += Boar;
        WolfImmigration += Wolf;
    }

    public void PrintTimeImmigration(string Animal)
    {
        Debug.LogWarning(Animal + " => Day : " + TimeManager.Instance.gameDay + " Hour : " + TimeManager.Instance.gameHour + " Minute : " + TimeManager.Instance.gameMinute);
    }

    void NumberofAnimalChild()
    {
        NumberOfRabbit_Heir =  NumberOfRabbit_All - (NumberOfRabbit_Immigration + 30);
        NumberOfWildboar_Heir =  NumberOfWildboar_All - (NumberOfWildboar_Immigration + 10);
        NumberOfWolf_Heir =  NumberOfWolf_All - (NumberOfWolf_Immigration + 3);
    }

    private void CheckIncreaseAnimal()
    {
        if(NumberOfRabbit > NumberOfRabbit_Old)
        {
            int x = NumberOfRabbit - NumberOfRabbit_Old;
            NumberOfRabbit_All += x;
            NumberOfRabbit_Old = NumberOfRabbit;
        }
        else if (NumberOfRabbit < NumberOfRabbit_Old)
        {
            NumberOfRabbit_Old = NumberOfRabbit;
        }

        if(NumberOfWildboar > NumberOfWildboar_Old)
        {
            int x = NumberOfWildboar - NumberOfWildboar_Old;
            NumberOfWildboar_All += x;
            NumberOfWildboar_Old = NumberOfWildboar;
        }
        else if (NumberOfWildboar < NumberOfWildboar_Old)
        {
            NumberOfWildboar_Old = NumberOfWildboar;
        }

        if(NumberOfWolf > NumberOfWolf_Old)
        {
            int x = NumberOfWolf - NumberOfWolf_Old;
            NumberOfWolf_All += x;
            NumberOfWolf_Old = NumberOfWolf;
        }
        else if (NumberOfWolf < NumberOfWolf_Old)
        {
            NumberOfWolf_Old = NumberOfWolf;
        }
        
    }

    public void GetNumAnimalImmigration(string Name, int x)
    {
        if(Name == "Rabbit")
        {
            NumberOfRabbit_Immigration += x;
        }
        if(Name == "Boar")
        {
            NumberOfWildboar_Immigration += x;
        }
        if(Name == "Wolf")
        {
            NumberOfWolf_Immigration += x;
        }
    }

    public void GetDataDeath(string Name, string Cause)
    {
        if(Name == "Rabbit")
        {
            if(Cause == "Strave")
            {
                RabbitStarve++;
            }
            else if (Cause == "Killed")
            {
                RabbitKilled++;
            }
            else if (Cause == "Defunct")
            {
                RabbitDefunct++;
            }
        }
        else if(Name == "Boar")
        {
            if(Cause == "Strave")
            {
                BoarStarve++;
            }
            else if (Cause == "Killed")
            {
                BoarKilled++;
            }
            else if (Cause == "Defunct")
            {
                BoarDefunct++;
            }
        }
        if(Name == "Wolf")
        {
            if(Cause == "Strave")
            {
                WolfStarve++;
            }
            else if (Cause == "Killed")
            {
                WolfKilled++;
            }
            else if (Cause == "Defunct")
            {
                WolfDefunct++;
            }
        }
    }
}
