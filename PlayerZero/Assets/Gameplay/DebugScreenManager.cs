using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScreenManager : SingletonMonobehaviour<DebugScreenManager>
{
    #region         //ตัวแปร
    public Text Rabbit;
    public Text Boar;
    public Text Wolf;
    public Text Tree;
    public Text Grass;
    public Text Temp;
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
    public int RabbitAgeOut;

    public int BoarKilled;
    public int BoarStarve;
    public int BoarAgeOut;

    public int WolfKilled;
    public int WolfStarve;
    public int WolfAgeOut;

     int NumberOfRabbit_Old;
     int NumberOfWildboar_Old;
     int NumberOfWolf_Old;

    public int NumberOfRabbit_All;
    public int NumberOfWildboar_All;
    public int NumberOfWolf_All;

    public int NumberOfRabbit_Immigration;
    public int NumberOfWildboar_Immigration;
    public int NumberOfWolf_Immigration;

    public int NumberOfRabbit_Child;
    public int NumberOfWildboar_Child;
    public int NumberOfWolf_Child;


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

        Rabbit.text = "Rabbit : " + NumberOfRabbit.ToString();
        Boar.text = "Boar : " + NumberOfWildboar.ToString();
        Wolf.text = "Wolf : " + NumberOfWolf.ToString();
        Tree.text = "Tree : " + NumberOfTree.ToString();
        Grass.text = "Grass : " + NumberOfGrass.ToString();
        Temp.text = "Temperature : " + Temperature.ToString() + " ํC";

        NumberofAnimalChild();
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
        NumberOfRabbit_Child =  NumberOfRabbit_All - (NumberOfRabbit_Immigration + 30);
        NumberOfWildboar_Child =  NumberOfWildboar_All - (NumberOfWildboar_Immigration + 10);
        NumberOfWolf_Child =  NumberOfWolf_All - (NumberOfWolf_Immigration + 3);
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
            else if (Cause == "AgeOut")
            {
                RabbitAgeOut++;
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
            else if (Cause == "AgeOut")
            {
                BoarAgeOut++;
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
            else if (Cause == "AgeOut")
            {
                WolfAgeOut++;
            }
        }
    }
}
