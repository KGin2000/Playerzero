using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public Vector3 MPosition; 
    private Canvas canvas;
    private Camera mainCamera;
    [SerializeField] private Image cursorImage = null;
    [SerializeField] private RectTransform cursorRectTransform = null;
    [SerializeField] private Sprite greenCursorSprite = null;
    [SerializeField] private Sprite transparentCursorSprite = null;
    [SerializeField] private GridCursor gridCursor = null;

    private bool _cursorIsEnabled = false;

    public bool CursorIsEnabled { get => _cursorIsEnabled; set => _cursorIsEnabled = value;}

    private bool _cursorPositionIsValid = false;
    public bool CursorPositionIsValid { get => _cursorPositionIsValid; set => _cursorPositionIsValid = value;}

    private ItemType _selectedItemType;
    public ItemType SelectedItemType { get => _selectedItemType; set => _selectedItemType = value;}

    private float _itemUseRadius = 0f;
    public float ItemUseRadius { get => _itemUseRadius; set => _itemUseRadius = value;}

    private void Start()
    {
         MousePosition.sendposition += getNewPosition; //  เรียก Class MousePosition
        mainCamera = Camera.main;
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if (CursorIsEnabled)
        {
            DisplayCursor();
        }
    }

    private void DisplayCursor()
    {
        //Get Position for cursor
        Vector3 cursorWorldPosition = GetWorldPositionForCursor();

        //Set cursor Sprite
        SetCursorValidity(cursorWorldPosition, Player.Instance.GetPlayerCentrePosition());

        //Get rect transform position for cursor
        cursorRectTransform.position = GetRectTransformPositionForCursor();
    }

    private void SetCursorValidity(Vector3 cursorPosition, Vector3 playerPosition)
    {
        
        SetCursorToValid();
        
        if  (
            cursorPosition.x > (playerPosition.x + ItemUseRadius / 2f) && cursorPosition.z > (playerPosition.z + ItemUseRadius / 2f)
            ||
            cursorPosition.x < (playerPosition.x - ItemUseRadius / 2f) && cursorPosition.z > (playerPosition.z + ItemUseRadius / 2f)
            ||
            cursorPosition.x > (playerPosition.x - ItemUseRadius / 2f) && cursorPosition.z < (playerPosition.z - ItemUseRadius / 2f)
            ||
            cursorPosition.x < (playerPosition.x + ItemUseRadius / 2f) && cursorPosition.z < (playerPosition.z - ItemUseRadius / 2f)
            )
            {
                SetCursorToInvalid();
                return;
            }
        
        if (Mathf.Abs(cursorPosition.x - playerPosition.x) > ItemUseRadius 
        || Mathf.Abs(cursorPosition.z - playerPosition.z) > ItemUseRadius)
        {
            SetCursorToInvalid();
            return;
        }
        Debug.Log("WOW");

        //Get Selected item details
        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedInventoryItemDetails(InventoryLocation.player);

        Debug.Log("Go" + itemDetails);

        if (itemDetails == null)
        {
            SetCursorToInvalid();
            return;
        }

        //Determine cursor validity based on inventory item selected and what Obj the cursor is over
        switch (itemDetails.itemType)
        {
            case ItemType.Watering_tool :
            case ItemType.Breaking_tool :
            case ItemType.Chopping_tool :
            case ItemType.Hoeing_tool :
            case ItemType.Reaping_tool :
            case ItemType.Collecting_tool :
                if(!SetCursorValidityTool(cursorPosition, playerPosition, itemDetails))
                {
                    SetCursorToInvalid();
                    return;
                }
                break;

            case ItemType.none :
                break;

            case ItemType.count :
                break;

            default :
                break;
        }
    }

    private void SetCursorToValid()
    {
        cursorImage.sprite = greenCursorSprite;
        CursorPositionIsValid = true;

        gridCursor.DisableCursor();
    }

    private void SetCursorToInvalid()
    {
        cursorImage.sprite = transparentCursorSprite;
        CursorPositionIsValid = false;

        gridCursor.EnableCursor();
    }

    private bool SetCursorValidityTool(Vector3 cursorPosition, Vector3 playerPosition, ItemDetails itemDetails)
    {
        switch (itemDetails.itemType)
        {
            case ItemType.Reaping_tool :
                return SetCursorValidityReapingTool(cursorPosition, playerPosition, itemDetails);

            default:
                return false;
        }
    }

    private bool SetCursorValidityReapingTool(Vector3 cursorPosition, Vector3 playerPosition, ItemDetails equippedItemDetails)
    {
        List<Item> itemList = new List<Item>();

        if(HelperMethods.GetComponentsAtCursorLocation<Item>(out itemList, cursorPosition))
        {
            if(itemList.Count != 0)
            {
                foreach (Item item in itemList)
                {
                    if(InventoryManager.Instance.GetItemDetails(item.ItemCode).itemType == ItemType.Reapable_scenary)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void DisableCursor()
    {
        cursorImage.color = new Color(1f, 1f, 1f, 0f);
        CursorIsEnabled = false;
    }

    public void EnableCursor()
    {
        cursorImage.color = new Color(1f, 1f, 1f, 1f);
        CursorIsEnabled = true;
    }
    void getNewPosition(Vector3 newposition)
    {
        MPosition = newposition;
    }    

    public Vector3 GetWorldPositionForCursor()
    {
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);

        return worldPosition;
    }

    public Vector2 GetRectTransformPositionForCursor()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        return RectTransformUtility.PixelAdjustPoint(screenPosition, cursorRectTransform, canvas);
    }
}
