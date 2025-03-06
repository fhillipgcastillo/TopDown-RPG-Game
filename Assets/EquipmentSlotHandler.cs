using UnityEngine;

public class EquipmentSlotHandler : MonoBehaviour
{
    public Sprite defaultSlotImage;
    public Equipement equipment;
    public EquipmentSlot slot;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(defaultSlotImage)
        {
            spriteRenderer.sprite = defaultSlotImage;
        } else
        {
            Debug.Log("Default Image is not set");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
