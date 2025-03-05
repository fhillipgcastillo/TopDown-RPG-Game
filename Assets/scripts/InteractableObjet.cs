using UnityEngine;
using UnityEngine.Events;

public class InteractableObjet : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactionKey;
    public Item[] itemsToAdd;
    public InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(interactKey)) {
            Debug.Log("Interact with "+gameObject.name);
            OpenChest();
        }
    }
    public void OpenChest()
    {
        Debug.Log("Opening CHest");
        // futre ideas: randomly, add items from possible array, which now is itemsToAdd.
        // instead of array of items it should have another kind of object data, with a Item and the min and max amount to give,
        // and randomnly give certain items with a randomlu amount from the min and max, based on probabilities.
        foreach (Item item in itemsToAdd)
        {
            inventoryManager.AddItem(item);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // could add a dynamic list or single object of triggable tag/s
        {
            Debug.Log("In proximity");
            isInRange = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isInRange == true)
        {
            Debug.Log("Out of proximity");
            isInRange = false;
        }
    }
}
