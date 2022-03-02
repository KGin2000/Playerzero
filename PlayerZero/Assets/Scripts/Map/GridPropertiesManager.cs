using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateGUID))]
public class GridPropertiesManager : SingletonMonobehaviour<GridPropertiesManager>, ISaveable
{
     public Grid grid;
     private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;
     [SerializeField] private SO_GridProperties[] so_gridPropertiesArray = null;

     private string _iSaveableUniqueID;
     public string ISaveableUniqueID { get { return _iSaveableUniqueID; } set { _iSaveableUniqueID = value; }}

     private GameObjectSave _gameObjectSave;
     public GameObjectSave GameObjectSave { get { return _gameObjectSave; } set { _gameObjectSave = value; } }

     protected override void Awake ()
     {
        base. Awake();

         ISaveableUniqueID = GetComponent<GenerateGUID>().GUID;
         GameObjectSave = new GameObjectSave();
     }

     private void OnEnable ()
     {
        ISaveableRegister();

        EventHandler.AfterSceneLoadEvent += AfterSceneLoaded;
     }

     private void OnDisable()
     {
        ISaveableDeregister();

        EventHandler.AfterSceneLoadEvent -= AfterSceneLoaded;
     }

     private void Start()
     {
         InitialiseGridProperties();
     }

     private void InitialiseGridProperties()
    {
        // Loop through all gridproperties in the array
        foreach (SO_GridProperties so_GridProperties in so_gridPropertiesArray)
    {
       // Create dictionary of grid property details
        Dictionary<string, GridPropertyDetails> gridPropertyDictionary = new Dictionary<string, GridPropertyDetails>();
                                               
        foreach (GridProperty gridProperty in so_GridProperties.gridPropertyList)
        {
            GridPropertyDetails gridPropertyDetails;
            gridPropertyDetails = GetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDictionary);

            if (gridPropertyDetails == null)
            {
                gridPropertyDetails = new GridPropertyDetails();
            }

            switch (gridProperty.gridBoolProperty)
            {
                case GridBoolProperty.diggable:
                    gridPropertyDetails.isDiggable = gridProperty.gridBoolValue;
                    break;

                case GridBoolProperty.canDropItem:
                    gridPropertyDetails.canDropItem = gridProperty.gridBoolValue;
                    break;

                case GridBoolProperty.canPlaceFurniture:
                    gridPropertyDetails.canPlaceFurniture = gridProperty.gridBoolValue;
                    break;

                case GridBoolProperty.isPath:
                    gridPropertyDetails.isPath = gridProperty.gridBoolValue;
                    break;
                                     
                case GridBoolProperty.isNPCObstacle:
                    gridPropertyDetails.isNPCObstacle = gridProperty.gridBoolValue;
                    break;
                                             
                default:
                    break;
            }

        SetGridPropertyDetails(gridProperty.gridCoordinate.x, gridProperty.gridCoordinate.y, gridPropertyDetails, gridPropertyDictionary);

        }

        SceneSave sceneSave = new SceneSave ();

        sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;

        if (so_GridProperties.sceneName.ToString() == SceneControllerManager.Instance.startingSceneName.ToString())
        {
            this.gridPropertyDictionary = gridPropertyDictionary;
        }

        // Add scene save to game object scene data
        GameObjectSave.sceneData.Add(so_GridProperties.sceneName.ToString(), sceneSave);
    }
}

    public void AfterSceneLoaded()
    {
        grid = GameObject.FindObjectOfType<Grid>();
    }

    public GridPropertyDetails GetGridPropertyDetails(int gridx, int gridy, Dictionary<string, GridPropertyDetails> gridPropertyDictionary)
    {
        string key = "x" + gridx + "y" + gridy;

        GridPropertyDetails gridPropertyDetails;
        
        if (!gridPropertyDictionary.TryGetValue(key, out gridPropertyDetails))
        {
            return null;
        }
        else
        {
            return gridPropertyDetails;
        }
    }

    public GridPropertyDetails GetGridPropertyDetails(int gridX, int gridY)
    {
        return GetGridPropertyDetails(gridX, gridY, gridPropertyDictionary);
    }

    public void ISaveableDeregister()
    {
        SaveLoadManager.Instance.iSaveableObjectList.Remove(this);
    }

    public void ISaveableRegister()
    {
        SaveLoadManager. Instance.iSaveableObjectList.Add(this);
    }

    public void ISaveableRestoreScene(string sceneName)
    {
        if (GameObjectSave.sceneData.TryGetValue(sceneName, out SceneSave sceneSave))
            {  
                if (sceneSave.gridPropertyDetailsDictionary != null)
                {
                    gridPropertyDictionary = sceneSave.gridPropertyDetailsDictionary;
                }
            }
    }

    public void ISaveableStoreScene(string sceneName)
    {
            // Remove sceneSave for scene
        GameObjectSave.sceneData. Remove(sceneName);

            // Create sceneSave for scene
        SceneSave sceneSave = new SceneSave ();

            // create & add dict grid property details dictionary
        sceneSave.gridPropertyDetailsDictionary = gridPropertyDictionary;

            // Add scene save to game object scene data
        GameObjectSave.sceneData. Add(sceneName, sceneSave);
    }

    public void SetGridPropertyDetails(int gridx, int gridY, GridPropertyDetails gridPropertyDetails)
    {
        SetGridPropertyDetails(gridx, gridY, gridPropertyDetails, gridPropertyDictionary);
    }

    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails, Dictionary<string, GridPropertyDetails>gridPropertyDictionary)
        {
            string key = "x" + gridX + "y" + gridY;

            gridPropertyDetails.gridx = gridX;
            gridPropertyDetails.gridY = gridY;

            gridPropertyDictionary[key] = gridPropertyDetails;
   
        }
}
    