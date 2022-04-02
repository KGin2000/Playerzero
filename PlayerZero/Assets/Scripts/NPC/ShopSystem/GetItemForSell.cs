using UnityEngine;

public class GetItemForSell : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item != null)
        {
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);

            //Debug.Log(itemDetails.itemDescription);

            if(itemDetails.canBeSell == true)
            {
                InventoryManager.Instance.GetItemForCalculate(item, collision.gameObject);
            }
            else
            {
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, collision.gameObject);
            }

        }
    }
}
