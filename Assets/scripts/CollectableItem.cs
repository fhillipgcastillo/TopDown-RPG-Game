using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
    public Item item;

    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        if (item != null)
        {
            sr.sprite = item.image;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collectable " + this.name +" colided with Item " + other.name);
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(item);
            Destroy(gameObject); // destroy this instance from game
        }
    }
}
