using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GenerateGUID))]
public class GridPropertiesManager : SingletonMonobehaviour<GridPropertiesManager>, ISaveable
{
    public LayerMask xzy;
    private Transform cropParentTransform;
    private Tilemap groundDecoration1;
    private Tilemap groundDecoration2;
     private Grid grid;
     private Dictionary<string, GridPropertyDetails> gridPropertyDictionary;
     [SerializeField] private SO_CropDetailsList so_CropDetailsList = null;
     [SerializeField] private SO_GridProperties[] so_gridPropertiesArray = null;
     [SerializeField] private Tile[] dugGround = null;
     [SerializeField] private Tile[] wateredGround = null;

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
        EventHandler.AdvanceGameDayEvent += AdvanceDay;
     }

     private void OnDisable()
     {
        ISaveableDeregister();

        EventHandler.AfterSceneLoadEvent -= AfterSceneLoaded;
        EventHandler.AdvanceGameDayEvent -= AdvanceDay;
     }

     private void Start()
     {
         InitialiseGridProperties();
     }

     private void ClearDisplayGroundDecorations()
     {
         groundDecoration1.ClearAllTiles();
         groundDecoration2.ClearAllTiles();
     }

     private void ClearDisplayAllPlantedCrops()
     {
         //Destroy all crops in scene
         Crop[] cropArray;
         cropArray = FindObjectsOfType<Crop>();

         foreach (Crop crop in cropArray)
         {
             Destroy(crop.gameObject);
         } 
     }

     private void ClearDisplayGridPropertyDetails()
     {
         ClearDisplayGroundDecorations();

         ClearDisplayAllPlantedCrops();
     }

     public void DisplayDugGround(GridPropertyDetails gridPropertyDetails)
     {
         if (gridPropertyDetails.daysSinceDug > -1)
         {
             ConnectDugGround(gridPropertyDetails);
         }
     }

     public void DisplayWateredGround(GridPropertyDetails gridPropertyDetails)
     {
         if(gridPropertyDetails.daysSinceWatered > -1)
         {
             ConnectWateredGround(gridPropertyDetails);
         }
     }

     private void ConnectDugGround(GridPropertyDetails gridPropertyDetails)
     {
        Tile dugTile0 = SetDugTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY);
        groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY,0), dugTile0);

        GridPropertyDetails adjacentGridPropertyDetails;

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile1 = SetDugTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1,0), dugTile1);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile2 = SetDugTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1,0), dugTile2);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > -1)
        {
            Tile dugTile3 = SetDugTile(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX -1, gridPropertyDetails.gridY,0), dugTile3);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceDug > - 1)
        {
            Tile dugTile4 = SetDugTile(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
            groundDecoration1.SetTile(new Vector3Int(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY,0), dugTile4);
        }
     }

     private void ConnectWateredGround(GridPropertyDetails gridPropertyDetails)
     {
         #region 
         Tile wateredTile0 = SetWateredTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY);
         groundDecoration2.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY, 0), wateredTile0);

         GridPropertyDetails adjacentGridPropertyDetails;

         adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceWatered > -1)
        {
            Tile wateredTile1 = SetWateredTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1);
            groundDecoration2.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY + 1,0), wateredTile1);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceWatered > -1)
        {
            Tile wateredTile2 = SetWateredTile(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1);
            groundDecoration2.SetTile(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY - 1,0), wateredTile2);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceWatered > -1)
        {
            Tile wateredTile3 = SetWateredTile(gridPropertyDetails.gridX - 1, gridPropertyDetails.gridY);
            groundDecoration2.SetTile(new Vector3Int(gridPropertyDetails.gridX -1, gridPropertyDetails.gridY,0), wateredTile3);
        }

        adjacentGridPropertyDetails = GetGridPropertyDetails(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
        if(adjacentGridPropertyDetails != null && adjacentGridPropertyDetails.daysSinceWatered > - 1)
        {
            Tile wateredTile4 = SetWateredTile(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY);
            groundDecoration2.SetTile(new Vector3Int(gridPropertyDetails.gridX + 1, gridPropertyDetails.gridY,0), wateredTile4);
        }
        #endregion
     }

     private Tile SetDugTile(int xGrid, int yGrid)
     {
         bool upDug = IsGridSquareDug(xGrid, yGrid + 1);
         bool downDug = IsGridSquareDug(xGrid, yGrid - 1);
         bool leftDug = IsGridSquareDug(xGrid - 1, yGrid);
         bool rightDug = IsGridSquareDug(xGrid + 1, yGrid);

         #region Set Tile based
         
         if (!upDug && !downDug && !rightDug && !leftDug)
         {
             return dugGround[0];
         }
        else if (!upDug && downDug && rightDug && !leftDug)
         {
             return dugGround[1];
         }
         else if (!upDug && downDug && rightDug && leftDug)
         {
             return dugGround[2];
         }
         else if (!upDug && downDug && !rightDug && leftDug)
         {
             return dugGround[3];
         }
         else if (!upDug && downDug && !rightDug && !leftDug)
         {
             return dugGround[4];
         }
         else if (upDug && downDug && rightDug && !leftDug)
         {
             return dugGround[5];
         }
         else if (upDug && downDug && rightDug && leftDug)
         {
             return dugGround[6];
         }
         else if (upDug && downDug && !rightDug && leftDug)
         {
             return dugGround[7];
         }
         else if (upDug && downDug && !rightDug && !leftDug)
         {
             return dugGround[8];
         }
         else if (upDug && !downDug && rightDug && !leftDug)
         {
             return dugGround[9];
         }
         else if (upDug && !downDug && rightDug && leftDug)
         {
             return dugGround[10];
         }
         else if (upDug && !downDug && !rightDug && leftDug)
         {
             return dugGround[11];
         }
         else if (upDug && !downDug && !rightDug && !leftDug)
         {
             return dugGround[12];
         }
         else if (!upDug && !downDug && rightDug && !leftDug)
         {
             return dugGround[13];
         }
         else if (!upDug && !downDug && rightDug && leftDug)
         {
             return dugGround[14];
         }
         else if (!upDug && !downDug && !rightDug && leftDug)
         {
             return dugGround[15];
         }
         return null;

         #endregion Set TileBase Dug
     }

     private bool IsGridSquareDug(int xGrid,int yGrid)
     {
         GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(xGrid, yGrid);

         if (gridPropertyDetails == null)
         {
             return false;
         }
         else if (gridPropertyDetails.daysSinceDug > -1)
         {
             return true;
         }
         else
         {
             return false;
         }
     }

    private Tile SetWateredTile(int xGrid, int yGrid)
     {
         
         bool upWatered = IsGridSquareWatered(xGrid, yGrid + 1);
         bool downWatered = IsGridSquareWatered(xGrid, yGrid - 1);
         bool leftWatered = IsGridSquareWatered(xGrid - 1, yGrid);
         bool rightWatered = IsGridSquareWatered(xGrid + 1, yGrid);

         #region Set Tile based
         
         if (!upWatered && !downWatered && !rightWatered && !leftWatered)
         {
             Debug.Log("0");return wateredGround[0];
         }
        else if (!upWatered && downWatered && rightWatered && !leftWatered)
         {
             Debug.Log("1");return wateredGround[1];
         }
         else if (!upWatered && downWatered && rightWatered && leftWatered)
         {
             Debug.Log("2");return wateredGround[2];
         }
         else if (!upWatered && downWatered && !rightWatered && leftWatered)
         {
             Debug.Log("3");return wateredGround[3];
         }
         else if (!upWatered && downWatered && !rightWatered && !leftWatered)
         {
             Debug.Log("4");return wateredGround[4];
         }
         else if (upWatered && downWatered && rightWatered && !leftWatered)
         {
             Debug.Log("5");return wateredGround[5];
         }
         else if (upWatered && downWatered && rightWatered && leftWatered)
         {
             Debug.Log("6");return wateredGround[6];
         }
         else if (upWatered && downWatered && !rightWatered && leftWatered)
         {
             Debug.Log("7");return wateredGround[7];
         }
         else if (upWatered && downWatered && !rightWatered && !leftWatered)
         {
             Debug.Log("8");return wateredGround[8];
         }
         else if (upWatered && !downWatered && rightWatered && !leftWatered)
         {
             Debug.Log("9");return wateredGround[9];
         }
         else if (upWatered && !downWatered && rightWatered && leftWatered)
         {
             Debug.Log("10");return wateredGround[10];
         }
         else if (upWatered && !downWatered && !rightWatered && leftWatered)
         {
             Debug.Log("11");return wateredGround[11];
         }
         else if (upWatered && !downWatered && !rightWatered && !leftWatered)
         {
             Debug.Log("12");return wateredGround[12];
         }
         else if (!upWatered && !downWatered && rightWatered && !leftWatered)
         {
             Debug.Log("13");return wateredGround[13];
         }
         else if (!upWatered && !downWatered && rightWatered && leftWatered)
         {
             Debug.Log("14");return wateredGround[14];
         }
         else if (!upWatered && !downWatered && !rightWatered && leftWatered)
         {
             return wateredGround[15];
         }
         return null;

         #endregion Set TileBase Watered
        
     }

     private bool IsGridSquareWatered(int xGrid, int yGrid)
     {
         GridPropertyDetails gridPropertyDetails = GetGridPropertyDetails(xGrid, yGrid);

         if(gridPropertyDetails == null)
         {
             return false;
         }
         else if (gridPropertyDetails.daysSinceWatered > -1)
         {
             return true;
         }
         else
         {
             return false;
         }
     }

     private void DisplayGridPropertyDetails()
     {
         foreach (KeyValuePair<string, GridPropertyDetails> item in gridPropertyDictionary)
         {
             GridPropertyDetails gridPropertyDetails = item.Value;

             DisplayDugGround(gridPropertyDetails);

             DisplayWateredGround(gridPropertyDetails);

             DisplayPlantedCrop(gridPropertyDetails);
         }
     }

     public void DisplayPlantedCrop(GridPropertyDetails gridPropertyDetails)
     {
         if (gridPropertyDetails.seedItemCode > -1)
         {
             //get crop details
             CropDetails cropDetails = so_CropDetailsList.GetCropDetails(gridPropertyDetails.seedItemCode);

             //prefab to use
             GameObject cropPrefab;

             //Instantiate crops prefab at grid location
             int growthStages = cropDetails.growthDays.Length;

             int currentGrowthStage = 0;
            //  int daysCounter = cropDetails.totalGrowthDays;
             for (int i = growthStages - 1; i >= 0; i--)
             {
                 if(gridPropertyDetails.growthDays >= cropDetails.growthDays[i]) // >= daysCounter
                 {
                     currentGrowthStage = i;
                     break;
                 }
                //  daysCounter = daysCounter - cropDetails.growthDays[i];
             }
             
             cropPrefab = cropDetails.growthPrefab[currentGrowthStage];

             Sprite growthSprite = cropDetails.growthSprite[currentGrowthStage];

             Vector3 worldPosition = groundDecoration2.CellToWorld(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY, 0));

             worldPosition = new Vector3(worldPosition.x + Settings.gridCellSize / 2, worldPosition.y, worldPosition.z + 1);

             GameObject cropInstance = Instantiate(cropPrefab, worldPosition, Quaternion.identity);
             cropInstance.transform.Rotate(90.0f,0.0f,0.0f,Space.Self);

             cropInstance.GetComponentInChildren<SpriteRenderer>().sprite = growthSprite;
             cropInstance.transform.SetParent(cropParentTransform);
             cropInstance.GetComponent<Crop>().cropGridPosition = new Vector2Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY);
         }
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
        if (GameObject.FindGameObjectWithTag(Tags.CropsParentTransform) != null)
        {
            cropParentTransform = GameObject.FindGameObjectWithTag(Tags.CropsParentTransform).transform;
        }
        else
        {
            cropParentTransform = null;
        }

        //Get Grid
        grid = GameObject.FindObjectOfType<Grid>();

        //Get Tile Map
        groundDecoration1 = GameObject.FindGameObjectWithTag(Tags.GroundDecoration1).GetComponent<Tilemap>();
        groundDecoration2 = GameObject.FindGameObjectWithTag(Tags.GroundDecoration2).GetComponent<Tilemap>();
    }

    public Crop GetCropObjectAtGridLocation(GridPropertyDetails gridPropertyDetails)
    {
        Vector3 worldPosition = grid.GetCellCenterWorld(new Vector3Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY, 0));
        Collider[] colliderArray = Physics.OverlapSphere(worldPosition, 10, xzy);

        //Loop through colliders to get crop game object
        Crop crop = null;

        foreach (Collider i in colliderArray)
        {
            crop = i.gameObject.GetComponentInParent<Crop>();
            if (crop != null && crop.cropGridPosition == new Vector2Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY))
                break;

            crop = i.gameObject.GetComponentInChildren<Crop>();
            if (crop != null && crop.cropGridPosition == new Vector2Int(gridPropertyDetails.gridX, gridPropertyDetails.gridY))
                break;
        }
        return crop;
    }

    //Return Crop Details for the provided SeedItemCode
    public CropDetails GetCropDetails(int seedItemCode)
    {
        return so_CropDetailsList.GetCropDetails(seedItemCode);
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

                if (gridPropertyDictionary.Count > 0)
                {
                    ClearDisplayGridPropertyDetails();

                    DisplayGridPropertyDetails();
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

    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails)
    {
        SetGridPropertyDetails(gridX, gridY, gridPropertyDetails, gridPropertyDictionary);
    }

    public void SetGridPropertyDetails(int gridX, int gridY, GridPropertyDetails gridPropertyDetails, Dictionary<string, GridPropertyDetails>gridPropertyDictionary)
        {
            string key = "x" + gridX + "y" + gridY;

            gridPropertyDetails.gridX = gridX;
            gridPropertyDetails.gridY = gridY;

            gridPropertyDictionary[key] = gridPropertyDetails;
   
        }

    private void AdvanceDay(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int gameSecond)
    {
        ClearDisplayGridPropertyDetails();

        foreach (SO_GridProperties so_GridProperties in so_gridPropertiesArray)
        {

            if(GameObjectSave.sceneData.TryGetValue(so_GridProperties.sceneName.ToString(), out SceneSave sceneSave))
            {
                if(sceneSave.gridPropertyDetailsDictionary != null)
                {
                    for (int i = sceneSave.gridPropertyDetailsDictionary.Count - 1; i >= 0; i--)
                    {
                        KeyValuePair<string, GridPropertyDetails> item = sceneSave.gridPropertyDetailsDictionary.ElementAt(i);

                        GridPropertyDetails gridPropertyDetails = item.Value;

                        #region Update all Grid Properties to reflect the advance in the day

                        //If a crop is planted
                        if(gridPropertyDetails.growthDays > -1)
                        {
                            gridPropertyDetails.growthDays += 1;
                        }

                        if(gridPropertyDetails.daysSinceWatered > -1)
                        {
                            gridPropertyDetails.daysSinceWatered = -1;
                        }

                        SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails, sceneSave.gridPropertyDetailsDictionary);

                        #endregion
                    }
                }
            }
        }

        DisplayGridPropertyDetails();
    }
}
    