using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickupIten(int id) {
        Item pickedUpItem = itemsToPickUp[id];
        if(pickedUpItem != null ) {
            Debug.Log("Item Exist "+ pickedUpItem.name);
            inventoryManager.AddItem(pickedUpItem);
        } else
        {
            Debug.Log("Item doesn't exist");
        }
    }
}
