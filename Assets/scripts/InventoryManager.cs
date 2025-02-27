using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    public GameObject inventoryItemPrefab;
    public int maxStackedItems = 4;

    // game will tell the InventoryManager to SpawnItem(item, stop){}
    // this will read the first empty slot on the Toolack/inventory and put th eitem in there.
    public bool AddItem(Item item)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
            Debug.Log("Item Slot is full");
        }

        Debug.Log("received item - "+ item.name);
        for(int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                Debug.Log("Item Slot is Empty");
                SpawnItem(item, slot);
                return true;
            }
            Debug.Log("Item Slot is full");
        }
        
        return false;
    }

    public void SpawnItem(Item item,InventorySlot slot)
    {
        Debug.Log("Spawning Item "+ item.name);
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
}
