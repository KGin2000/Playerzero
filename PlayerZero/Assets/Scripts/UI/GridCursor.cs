using UnityEngine;
using UnityEngine.UI;
public class GridCursor : MonoBehaviour
    {
    public Vector3 MPosition;   // แก้Mouse
    private Canvas canvas;
    private Grid grid;
    private Camera mainCamera;
    [SerializeField] private Image cursorImage = null;
    [SerializeField] private RectTransform cursorRectTransform = null;
    [SerializeField] private Sprite greenCursorSprite = null;
    [SerializeField] private Sprite redCursorSprite = null;
    private bool _cursorPositionIsValid = false;
    public bool CursorPositionIsValid { get => _cursorPositionIsValid; set => _cursorPositionIsValid = value; }
    private int _itemUseGridRadius = 0;
    public int ItemUseGridRadius { get => _itemUseGridRadius; set => _itemUseGridRadius = value; }
    private ItemType _selectedItemType;
    public ItemType SelectedItemType { get => _selectedItemType; set => _selectedItemType = value; } 
    private bool _cursorIsEnabled = false;
    public bool CursorIsEnabled { get => _cursorIsEnabled; set => _cursorIsEnabled = value; }
    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= SceneLoaded; 
    }
    
    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += SceneLoaded;
    }

    // Start is called before the first frame update
    private void Start()
    {
        MousePosition.sendposition += getNewPosition;       //  เรียก Class MousePosition
        mainCamera = Camera.main;
        canvas = GetComponentInParent<Canvas>();

    }
        
    // Update is called once per frame
    private void Update()
    {
        if (CursorIsEnabled)
        {
            DisplayCursor();
        }
    }

    void getNewPosition(Vector3 newposition)
    {
        MPosition = newposition;
    }    
    
    private Vector3Int DisplayCursor()
    {
        if (grid != null)
        {
            // Get grid position for cursor
            Vector3Int gridPosition = GetGridPositionForCursor();
        // Get grid position for player
            Vector3Int playerGridPosition = GetGridPositionForPlayer ();
        // Set cursor sprite
            SetCursorValidity(gridPosition, playerGridPosition);
            // Get rect transform position for cursor
            cursorRectTransform.position = GetRectTransformPositionForCursor(gridPosition);

            return gridPosition;
        }
        else
        {
            return Vector3Int.zero;
        }
            
    }

    private void SceneLoaded()
    {
        grid = GameObject.FindObjectOfType<Grid>();
    }

    private void SetCursorValidity(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        SetCursorToValid();

        // Check item use radius is valid
        if (Mathf.Abs(cursorGridPosition.x - playerGridPosition.x) > ItemUseGridRadius
            || Mathf.Abs(cursorGridPosition.y - playerGridPosition.y) > ItemUseGridRadius)
            {
                SetCursorToInvalid();
                return;
            }
            
         // Get selected item details
        ItemDetails itemDetails = InventoryManager. Instance.GetSelectedInventoryItemDetails(InventoryLocation.player);

        if (itemDetails == null)
        {
            SetCursorToInvalid();
            return;
        }
            
        // Get grid property details at cursor position
        GridPropertyDetails gridPropertyDetails = GridPropertiesManager. Instance.GetGridPropertyDetails(cursorGridPosition.x, cursorGridPosition.y);

        if (gridPropertyDetails != null)
        {
            // Determine cursor validity based on inventory item selected and grid property details
            switch (itemDetails.itemType)
            {
                case ItemType.Seed:
                if (!IsCursorValidForSeed(gridPropertyDetails))
                {
                    SetCursorToInvalid();
                    return;
                }
                break;
                case ItemType.Commodity:
                if (!IsCursorValidForCommodity(gridPropertyDetails))
                {
                    SetCursorToInvalid();
                    return;
                }
                break;

            case ItemType.none:
                break;
            case ItemType.count:
                break;
            default:
                break;
                }
            }
        else
        {
            SetCursorToInvalid();
            return;
        }
}

    /// <summary>
    /// Set the cursor to be invalid
    /// </summary>
    private void SetCursorToInvalid()
    {
        cursorImage.sprite = redCursorSprite;
        CursorPositionIsValid = false;
    }
  
    /// <summary>
    /// Set the cursor to be valid
    /// </summary>
    private void SetCursorToValid()
    {
        cursorImage.sprite = greenCursorSprite;
        CursorPositionIsValid = true;
    }

    private bool IsCursorValidForCommodity(GridPropertyDetails gridPropertyDetails)
    {
        return gridPropertyDetails.canDropItem;
    }
    
    private bool IsCursorValidForSeed(GridPropertyDetails gridPropertyDetails)
    {
        return gridPropertyDetails.canDropItem;
    }
    
    public void DisableCursor()
    {
        cursorImage.color = Color.clear;
        CursorIsEnabled = false;
    }

    public void EnableCursor()
    {
        cursorImage.color = new Color(1f, 1f, 1f, 1f);
        CursorIsEnabled = true;
    }

    public Vector3Int GetGridPositionForCursor()
    {
        //Vector3 worldPosition = mainCamera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
       
        return grid.WorldToCell(MPosition);
    }    
        
    public Vector3Int GetGridPositionForPlayer()
    {
        return grid.WorldToCell(Player. Instance.transform.position);
    }
    
    public Vector2 GetRectTransformPositionForCursor (Vector3Int gridPosition)
    {
        Vector3 gridworldPosition =  grid.CellToWorld(gridPosition);
        Vector2 gridScreenPosition =  mainCamera.WorldToScreenPoint(gridworldPosition); 
        return RectTransformUtility.PixelAdjustPoint(gridScreenPosition, cursorRectTransform, canvas);
    }
}
           

                                                                                                  
                                                                                                     