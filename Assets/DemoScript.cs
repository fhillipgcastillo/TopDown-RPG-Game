using System.Linq.Expressions;
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
        if (selectedItem != null)
        {
            Debug.Log("Item received " + selectedItem.name);
        }
        else
        {
            Debug.Log("There's not item in slot");
        }
    }

    public void UseSelectedItem()
    {
        Item selectedItem = inventoryManager.GetSelectedItem(true);
        if(selectedItem != null)
        {
            Debug.Log("Item Used "+selectedItem.name);
        }
        else
        {
            Debug.Log("Can't use the item");
        }
    }
}
