using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item itemData;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Start()
    {
        if (itemData!= null)
        {
            spriteRenderer.sprite = itemData.image;

        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collectable " + this.name + " colided with Item " + other.name);
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(itemData);
            Destroy(gameObject); // destroy this instance from game
        }
    }
}
