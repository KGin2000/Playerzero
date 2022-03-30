using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{//555

     public Vector3 MPosition; //สร้างตัวแปรนอก จะได้ไม่หนัก

    private Camera mainCamera; 

    private Canvas parentCanvas;        //30//
    private Transform parentItem;
    private GridCursor gridCursor;       //      46      //
    private Cursor cursor;
    public GameObject draggedItem;

    public Image inventorySlotHightlight;
    public Image inventorySlotImage;
    public TextMeshProUGUI textMeshProUGUI;

    [SerializeField] private UIInventoryBar inventoryBar = null;
    [SerializeField] private GameObject inventoryTextBoxPrefab = null;
    [HideInInspector] public bool isSelected = false; // 32 // 
    [HideInInspector] public ItemDetails itemDetails;
    [SerializeField] private GameObject itemPrefab = null;
    [HideInInspector] public int itemQuantity;
    [SerializeField] private int slotNumber = 0;

    private void Awake()        //30//
    {
        parentCanvas = GetComponentInParent<Canvas>();
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadEvent += SceneLoaded;
        EventHandler.RemoveSelectedItemFromInventoryEvent += RemoveSelectedItemFromInventory;
        EventHandler.DropSelectedItemEvent += DropSelectedItemAtMousePosition;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadEvent -= SceneLoaded;
        EventHandler.RemoveSelectedItemFromInventoryEvent -= RemoveSelectedItemFromInventory;
        EventHandler.DropSelectedItemEvent -= DropSelectedItemAtMousePosition;
    }

    private void Start()
    {
        //mainCamera = Camera.main;// original
        //parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;

        MousePosition.sendposition += getNewPosition;       //  เรียก Class MousePosition

        gridCursor = FindObjectOfType<GridCursor>();        //      46      //

        cursor = FindObjectOfType<Cursor>();
    }

    private void ClearCursor()
    {
        gridCursor.DisableCursor();
        cursor.DisableCursor();

        gridCursor.SelectedItemType = ItemType.none;
    }

    private void SetSelectedItem()
    {
        inventoryBar.ClearHighlightOnInventorySlots();

        isSelected = true;

        inventoryBar.SetHighlightedInventorySlots();

        gridCursor.ItemUseGridRadius = itemDetails.itemUseGridRadius;       //      46  {

        cursor.ItemUseRadius = itemDetails.itemUseRadius;

        if (itemDetails.itemUseGridRadius > 0)
        {
            gridCursor.EnableCursor();
        }
        else
        {
            gridCursor.DisableCursor();
        }


        if(itemDetails.itemUseRadius > 0f)
        {
            cursor.EnableCursor();
        }
        else
        {
            cursor.DisableCursor();
        }

        gridCursor.SelectedItemType = itemDetails.itemType;                 //      46  }
        cursor.SelectedItemType = itemDetails.itemType;

        InventoryManager.Instance.SetSelectedInventoryItem(InventoryLocation.player, itemDetails.itemCode);
    }

    public void ClearSelectedItem()
    {
        ClearCursor();
        
        inventoryBar.ClearHighlightOnInventorySlots();
        
        isSelected = false;

        InventoryManager.Instance.ClearSelectedInventoryItem(InventoryLocation.player);
    }

    void getNewPosition(Vector3 newposition)
    {
        MPosition = newposition;
    }

    private void DropSelectedItemAtMousePosition()
    {
        if (itemDetails != null && isSelected)
        {
            //Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
            //Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -screenPoint.z);
            //Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
            //curPosition.y = 0.0f;
            //transform.position = curPosition;

            //Debug.Log("test" + transform.position);
        //transform.position = curPosition;


            //Debug.Log(curPosition);
            //worldPosition = transform.position;
                        // เซตค่า Y = 0;
            //transform.position = worldPosition;
            //Debug.Log(curPosition);

            //If Can Drop Item Here
                 // 45  // Vector3Int gridPosition = GridPropertiesManager.Instance.grid.WorldToCell(MPosition);
                 // 45  // GridPropertyDetails gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(gridPosition.x, gridPosition.y);

            //if (gridPropertyDetails != null && gridPropertyDetails.canDropItem)   // out 46
            if (gridCursor.CursorPositionIsValid)
            {
                GameObject itemGameObject = Instantiate(itemPrefab, MPosition, Quaternion.identity, parentItem);
                Item item = itemGameObject.GetComponent<Item>();
                    //Debug.Log("Before item" + item.transform.rotation);
                item.transform.Rotate(90.0f,0.0f,0.0f,Space.Self);
                    //Debug.Log("After item" + item.transform.rotation);
                item.ItemCode = itemDetails.itemCode;

                InventoryManager.Instance.RemoveItem(InventoryLocation.player, item.ItemCode);

                //32//
                if(InventoryManager.Instance.FindItemInInventory(InventoryLocation.player, item.ItemCode) == -1)
                {
                    ClearSelectedItem();
                }
            }   
        }
    }

    private void RemoveSelectedItemFromInventory()
    {
        if (itemDetails != null && isSelected)
        {
            int itemCode = itemDetails.itemCode;

            //Remove item from players inventory
            InventoryManager.Instance.RemoveItem(InventoryLocation.player , itemCode);

            //IF no more of item then clear selected
            if (InventoryManager.Instance.FindItemInInventory(InventoryLocation.player, itemCode) == -1)
            {
                ClearSelectedItem();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemDetails != null)
        {
            Player.Instance.DisablePlayerInputAndResetMovement();

            draggedItem = Instantiate(inventoryBar.inventoryBarDraggedItem, inventoryBar.transform);
                            // draggedItem.transform.position = vector3;
                            // draggedItem.transform.Rotate(90.0f,0.0f,0.0f,Space.Self);
                            //Debug.Log("OnBeginDrag" + "Position => " + draggedItem.transform.position + "Rotation =>" + draggedItem.transform.rotation);

            Image draggedItemImage = draggedItem.GetComponentInChildren<Image>();
                            //Debug.Log("OnBeginDrag" + "Position => " + draggedItemImage.transform.position + "Rotation =>" + draggedItemImage.transform.rotation);
            draggedItemImage.sprite = inventorySlotImage.sprite;

            SetSelectedItem();  //32//
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            draggedItem.transform.position = MPosition;
            
            
            //Debug.Log("OnDrag" + draggedItem.transform.rotation);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (draggedItem != null)
        {
            Destroy(draggedItem);

            if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null)
            {
                int toSlotNumber = eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>().slotNumber;

                InventoryManager.Instance.SwapInventoryItems(InventoryLocation.player, slotNumber, toSlotNumber);

                DestroyInventoryTextBox(); //30//

                ClearSelectedItem();    //32//
            }
            else
            {
                if (itemDetails.canBeDropped)
                {
                    Debug.Log("EndDrag");
                    //ClearCursor();
                    DropSelectedItemAtMousePosition();
                }
            }
            Player.Instance.EnablePlayerInput();
        }
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        if (eventdata.button == PointerEventData.InputButton.Left)
        {
            if (isSelected == true)
            {
                ClearSelectedItem();
            }
            else
            {
                if(itemQuantity > 0)
                {
                    SetSelectedItem();
                }   
            }
        }
    }

    public  void OnPointerEnter(PointerEventData eventData)
    {
        if(itemQuantity != 0)
        {
            inventoryBar.inventoryTextBoxGameobject = Instantiate(inventoryTextBoxPrefab, transform.position, Quaternion.identity);
            inventoryBar.inventoryTextBoxGameobject.transform.SetParent(parentCanvas.transform, false);

            UIInventoryTextBox inventoryTextBox = inventoryBar.inventoryTextBoxGameobject.GetComponent<UIInventoryTextBox>();

            string itemTypeDescription = InventoryManager.Instance.GetItemTypeDescription(itemDetails.itemType);

            inventoryTextBox.SetTextboxText(itemDetails.itemDescription, itemTypeDescription, "", itemDetails.itemLongDescription, "", "");

            if (inventoryBar.IsInventoryBarPositionButtom)
            {
                inventoryBar.inventoryTextBoxGameobject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0f);
                inventoryBar.inventoryTextBoxGameobject.transform.position = new Vector3(transform.position.x, transform.position.y + 50f, transform.position.z);
            }

            else
            {
                inventoryBar.inventoryTextBoxGameobject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
                inventoryBar.inventoryTextBoxGameobject.transform.position = new Vector3(transform.position.x, transform.position.y - 50f, transform.position.z);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyInventoryTextBox();
    }
    
    public void DestroyInventoryTextBox()
    {
        if (inventoryBar.inventoryTextBoxGameobject != null)
        {
            Destroy(inventoryBar.inventoryTextBoxGameobject);
        }
    }

    public void SceneLoaded()
    {
        parentItem = GameObject.FindGameObjectWithTag(Tags.ItemsParentTransform).transform;
    } 
}
