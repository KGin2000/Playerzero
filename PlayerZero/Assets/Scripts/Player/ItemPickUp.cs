using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item != null)
        {
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);

            //Debug.Log(itemDetails.itemDescription);

            if(itemDetails.canBePickedUp == true)
            {
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, collision.gameObject);

                //Play pick up sound
                AudioManager.Instance.PlaySound(SoundName.effectPickupSound);
            }

        }
    }
}
