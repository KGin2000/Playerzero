using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    [SerializeField] private Sprite blank16x16sprite = null;            //27//
    [SerializeField] private UIInventorySlot[] inventorySlot = null;   //27//
    public GameObject inventoryBarDraggedItem;      //28//

    [HideInInspector] public GameObject inventoryTextBoxGameobject;

    private RectTransform rectTransform;

    private bool _isInventoryBarPositionButtom = true;

    public bool IsInventoryBarPositionButtom { get => _isInventoryBarPositionButtom; set => _isInventoryBarPositionButtom = value; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnDisable() //27//
    {
        EventHandler.InventoryUpdatedEvent -= InventoryUpdated;
    }


    private void OnEnable() //27//
    {
        EventHandler.InventoryUpdatedEvent += InventoryUpdated;
    }

    private void Update()
    {
        SwitchInventoryBarPosition();
    }

    public void ClearHighlightOnInventorySlots()
    {
        if(inventorySlot.Length > 0)
        {
            for(int i = 0; i < inventorySlot.Length; i++)
            {
                if (inventorySlot[i].isSelected)
                {
                    inventorySlot[i].isSelected = false;
                    inventorySlot[i].inventorySlotHightlight.color = new Color(0f, 0f, 0f, 0f);

                    InventoryManager.Instance.ClearSelectedInventoryItem(InventoryLocation.player);
                }
            }
        }
    }

    private void ClearInventorySlots()
    {
        if (inventorySlot.Length > 0)
        {
            for(int i = 0; i < inventorySlot.Length; i++)
            {
                inventorySlot[i].inventorySlotImage.sprite = blank16x16sprite;
                inventorySlot[i].textMeshProUGUI.text = "";
                inventorySlot[i].itemDetails = null;
                inventorySlot[i].itemQuantity = 0;

                SetHighlightedInventorySlots(i);
            }
        }
    }

    private void InventoryUpdated(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (inventoryLocation == InventoryLocation.player)
        {
            ClearInventorySlots();

            if (inventorySlot.Length > 0 && inventoryList.Count > 0)
            {
                for (int i = 0; i < inventorySlot.Length; i++)
                {
                    if (i < inventoryList.Count)
                    {
                        int itemCode = inventoryList[i].itemCode;

                        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);

                        if (itemDetails != null)
                        {
                            inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                            inventorySlot[i].textMeshProUGUI.text = inventoryList[i].itemQuantity.ToString();
                            inventorySlot[i].itemDetails = itemDetails;
                            inventorySlot[i].itemQuantity = inventoryList[i].itemQuantity;

                            SetHighlightedInventorySlots(i); //32//
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    public void SetHighlightedInventorySlots()
    {
        if(inventorySlot.Length > 0)
        {
            for (int i = 0; i < inventorySlot.Length; i++)
            {
                SetHighlightedInventorySlots(i);
            }
        }
    }

    public void SetHighlightedInventorySlots(int itemPosition)
    {
        if(inventorySlot.Length > 0 && inventorySlot[itemPosition].itemDetails != null)
        {
            if(inventorySlot[itemPosition].isSelected)
            {
                inventorySlot[itemPosition].inventorySlotHightlight.color = new Color(1f, 1f, 1f, 1f);

                InventoryManager.Instance.SetSelectedInventoryItem(InventoryLocation.player, inventorySlot[itemPosition].itemDetails.itemCode);
            }
        }
    }

    private void SwitchInventoryBarPosition()
    {
        Vector3 playerViewportPosition = Player.Instance.GetPlayerViewporPosition();
        
        if (playerViewportPosition.y > 0.3f && IsInventoryBarPositionButtom == false)
        {
            rectTransform.pivot = new Vector2(0.5f, 0f);
            rectTransform.anchorMin = new Vector2(0.5f, 0f);
            rectTransform.anchorMax = new Vector2(0.5f, 0f);
            rectTransform.anchoredPosition = new Vector2(0f, 2.5f);

            IsInventoryBarPositionButtom = true;
        }
        else if (playerViewportPosition.y <= 0.3f && IsInventoryBarPositionButtom == true)
        {
            rectTransform.pivot = new Vector2(0.5f, 1f);
            rectTransform.anchorMin = new Vector2(0.5f, 1f);
            rectTransform.anchorMax = new Vector2(0.5f, 1f);
            rectTransform.anchoredPosition = new Vector2(0f, -2.5f);

            IsInventoryBarPositionButtom = false;
        }
    }

    public void DestroyCurrentlyDraggedItems()
    {
        for(int i = 0; i < inventorySlot.Length; i++)
        {
            if(inventorySlot[i].draggedItem != null)
            {
                Destroy(inventorySlot[i].draggedItem);
            }
        }
    }

    public void ClearCurrentlySelectedItems()
    {
        for(int  i = 0; i < inventorySlot.Length; i++)
        {
            inventorySlot[i].ClearSelectedItem();
        }
    }
}
