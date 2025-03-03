using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickupIten(int id) {
        Item pickedUpItem = itemsToPickUp[id];
        if(pickedUpItem != null ) {
            Debug.Log("Picked up item:"+ pickedUpItem.name);
            bool result = inventoryManager.AddItem(pickedUpItem);
            if(result)
            {
                Debug.Log("ITEM NOT ADDED");
            } else
            {
                Debug.Log("Item added");
            }
        } else
        {
            Debug.Log("Item doesn't exist");
        }
    }

    public void GetSelectedItem()
    {
        Item selectedItem = inventoryManager.GetSelectedItem();
        Debug.Log("Selected item was "+selectedItem.name);
    }
}
