using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public int maxStackedItems = 4;
    public static InventoryManager instance;

    int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ChangeSelectedSlot(0);
    }
    private void Update()
    {
     if(Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number <=7)
            {
                ChangeSelectedSlot(number - 1);
            }
        }   
    }
    void ChangeSelectedSlot(int newValue)
    {
        Debug.Log("Change Selected value with " + newValue.ToString());
        if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        Debug.Log("Inventory Slots "+inventorySlots.Length);
        Debug.Log("slot to select " + (inventorySlots[newValue] ? "exist" : "null"));
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    // game will tell the InventoryManager to SpawnItem(item, stop){}
    // this will read the first empty slot on the Toolack/inventory and put th eitem in there.
    public bool AddItem(Item item)
    {
        // find existent item in the inventory
        // that is stackable and it not max stacked
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null 
                && itemInSlot.item == item 
                && itemInSlot.count < maxStackedItems
                && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        // Item No stacked
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                //Debug.Log("Item Slot is Empty");
                SpawnItem(item, slot);
                return true;
            }
            //Debug.Log("Item Slot is full");
        }
        
        return false;
    }

    public void SpawnItem(Item item,InventorySlot slot)
    {
        //Debug.Log("Spawning Item "+ item.name);
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public Item GetSelectedItem(bool use = false)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot == null)
            return null;
        
        Item item = itemInSlot.item; // return item or null
        if (item != null && use)
        {
            itemInSlot.count--;
            if (itemInSlot.count <= 0)
            {
                // destroy item
                Destroy(itemInSlot.gameObject);
            }
            else
            {
                itemInSlot.RefreshCount();
            }
        }
        return item;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collition with Inventory manager");
        //Item collectedItem = collision.
    }
}
