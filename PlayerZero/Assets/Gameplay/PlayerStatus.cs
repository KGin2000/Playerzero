using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Stat
{
    public int maxVal;
    public int currVal;

    public Stat(int curr, int max)
    {
        maxVal = max;
        currVal = curr;
    }

    internal void Subtract(int amount)
    {
        currVal -= amount;
        
        if (currVal < 0)
        {
            currVal = 0;
        }
    }

    internal void Add(int amount)
    {
        currVal += amount;

        if (currVal > maxVal)
        {
            currVal = maxVal;
        }
    }

    internal void SetToMax()
    {
        currVal = maxVal;
    }

    internal void SetToHalf()
    {
        int halfVal = (maxVal/2);
        currVal += halfVal;
        
        if (currVal > maxVal)
        {
            currVal = maxVal;
        }
    }
}

public class PlayerStatus : SingletonMonobehaviour<PlayerStatus>//, ISaveable
{
    public Stat hp;
    [SerializeField] StatusBar hpBar;
    public Stat stamina;
    [SerializeField] StatusBar staminaBar;
    public bool isDead;
    public bool isExhausted;

    // private string _iSaveableUniqueID;
    // public  string ISaveableUniqueID { get { return _iSaveableUniqueID; } set { _iSaveableUniqueID = value; } }
    // private GameObjectSave _gameObjectSave;
    // public GameObjectSave GameObjectSave { get { return _gameObjectSave; } set { _gameObjectSave = value; } }

    // protected override void Awake()
    // {
    //     base.Awake();

    //     ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
    //     GameObjectSave = new GameObjectSave();
    // }

    //  private void OnEnable()
    // {
    //     ISaveableRegister();
    // }

    //  private void OnDisable()
    // {
    //     ISaveableDeregister();
    // }

    private void Start()
    {
        UpdateHPBar();
        UpdateStaminaBar();
    }

    public void UpdateHPBar()
    {
        hpBar.Set(hp.currVal, hp.maxVal);
    }

    public void UpdateStaminaBar()
    {
        staminaBar.Set(stamina.currVal, stamina.maxVal);
    }

    public void TakeDamage(int amount)
    {
        hp.Subtract(amount);
        UpdateStatus();
        UpdateHPBar();  
    }

    public void Heal(int amount)
    {
        hp.Add(amount);
        UpdateStatus();
        UpdateHPBar();
    }

    public void FullHeal()
    {
        hp.SetToMax();
        UpdateStatus();
        UpdateHPBar();
    }

    public void GetTired(int amount)
    {
        stamina.Subtract(amount);
        UpdateStatus();
        UpdateStaminaBar();
    }

    public void Rest(int amount)
    {
        stamina.Add(amount);
        UpdateStatus();
        UpdateStaminaBar();
    }

    public void FullRest()
    {
        stamina.SetToMax();
        UpdateStatus();
        UpdateStaminaBar();
    }

    public void HalfRest()
    {
        stamina.SetToHalf();
        UpdateStatus();
        UpdateStaminaBar();
    }

    public void UpdateStatus()
    {
        if (hp.currVal <= 0)
        {
            isDead = true;
        }
        // else if (hp.currVal > 0)
        // {
        //     isDead = false;
        // }

         if(stamina.currVal <= 0)
        {
            isExhausted = true;
        }
        else if(stamina.currVal > 0)
        {
            isExhausted = false;
        }
    }

    private void Update()
    {
        // Debug.Log("isDead = " + isDead);
        // Debug.Log("isExhausted = " + isExhausted);
        if(Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            FullHeal();
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            GetTired(10);
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            FullRest();
        }
    }

    // public void ISaveableRegister()
    // {
    //     SaveLoadManager.Instance.iSaveableObjectList.Add(this);
    // }

    // public void ISaveableDeregister()
    // {
    //     SaveLoadManager.Instance.iSaveableObjectList.Remove(this);
    // }

    // public GameObjectSave ISaveableSave()
    // {
    //     //Delete existing scene save if exists
    //     GameObjectSave.sceneData.Remove(Settings.PersistentScene);

    //     //Create new scene save
    //     SceneSave sceneSave = new SceneSave();

    //     //Create new int dictionary
    //     sceneSave.intDictionary = new Dictionary<string, int>();

    //     //Add values to the int dictionary
    //     sceneSave.intDictionary.Add("hp", hp.currVal);
    //     sceneSave.intDictionary.Add("stamina", stamina.currVal);

    //     //Add scene save to game object for persistent scene
    //     GameObjectSave.sceneData.Add(Settings.PersistentScene, sceneSave);

    //     Debug.Log("Saved");
    //     return GameObjectSave;
    // }

    // public void ISaveableLoad(GameSave gameSave)
    // {
    //     //Get saved gameobject from gameSave data
    //     if (gameSave.gameObjectData.TryGetValue(ISaveableUniqueID, out GameObjectSave gameObjectSave))
    //     {
    //         GameObjectSave = gameObjectSave;

    //         //Get savedscene data for gameobject
    //         if(GameObjectSave.sceneData.TryGetValue(Settings.PersistentScene, out SceneSave sceneSave))
    //         {
    //             //if int and string dictionaries are found
    //             if(sceneSave.intDictionary != null)
    //             {
    //                 //populate saved int values
    //                 if(sceneSave.intDictionary.TryGetValue("hp", out int savedhp))
    //                     hp.currVal = savedhp;
                    
    //                 if(sceneSave.intDictionary.TryGetValue("stamina", out int savedstamina))
    //                     stamina.currVal = savedstamina;
    //             }
    //         }
    //     }
    // }

    // public void ISaveableStoreScene(string sceneName)
    // {
    //     //Nothing required here since Time Manager is running on the persistent scene
    // }

    // public void ISaveableRestoreScene(string sceneName)
    // {
    //     //Nothing required here since Time Manager is running on the persistent scene
    // }
}
