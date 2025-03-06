using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EquipmentSlotSpriteMapping
{
    public EquipmentSlot slot;
    public Sprite defaultSprite;
}

public class EquipmentManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Dictionary<EquipmentSlot, Equipement> slots;
    public InventoryManager inventoryManager;
    public GameObject equipmentUi;
    public GameObject slotPrefab;
    // List to set up the default sprite for each EquipmentSlot in the inspector.
    public List<EquipmentSlotSpriteMapping> slotSpriteMappings;
    // Dictionary for quick lookup of sprites by slot type.
    private Dictionary<EquipmentSlot, Sprite> defaultSlotSprites;

    EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
        slots = Enum.GetValues(typeof(EquipmentSlot))
                    .Cast<EquipmentSlot>()
                    .ToDictionary(slot => slot, slot => (Equipement)null);
        // Automatically create a child GameObject for each EquipmentSlot enum value
        // Convert the list of mappings to a dictionary for easier lookup
        defaultSlotSprites = slotSpriteMappings.ToDictionary(mapping => mapping.slot, mapping => mapping.defaultSprite);

        // Create a child GameObject for each EquipmentSlot and assign its default sprite.
        foreach (EquipmentSlot slot in Enum.GetValues(typeof(EquipmentSlot)))
        {
            GameObject slotPrefabInstance = Instantiate(slotPrefab, equipmentUi.transform);
            //slotPrefabInstance.name = $"{slot}-slot";

            GameObject slotChild = new GameObject(slot.ToString());
            slotChild.transform.SetParent(slotPrefabInstance.transform);

            // Add an Image component to the slotChild
            Image slotImage = slotChild.AddComponent<Image>();

            // If a default sprite is found for this slot, assign it
            if (defaultSlotSprites.TryGetValue(slot, out Sprite defaultSprite))
            {
                slotImage.sprite = defaultSprite;
                
            }
            else
            {
                Debug.LogWarning($"No default sprite assigned for EquipmentSlot: {slot}");
            }

            // Optionally adjust RectTransform settings if this is a UI element.
            RectTransform rectTransform = slotChild.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.localPosition = Vector3.zero;
                rectTransform.sizeDelta = new Vector2(100, 100); // Example size; adjust as needed.
                rectTransform.localScale = Vector3.one;
                rectTransform.
            }

            // (Optional) Customize the image's properties (size, color, etc.) here.
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed down");
            //Equipe();
        }
    }

    public bool EquipItem(Equipement equipement)
    {
        //var selectedItem = inventoryManager.GetSelectedItem(false);

        if (slots[equipement.slot] != null) {
            Debug.Log($"{equipement} is already occupied");
            return false;
        }
        slots[equipement.slot] = equipement;
        Debug.Log($"{equipement.name} equiped in   {equipement.slot} slot");
        return true;
    }


}
