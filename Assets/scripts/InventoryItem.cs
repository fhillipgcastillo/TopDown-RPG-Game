using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem.LowLevel;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public Text countText;

    public Item item;
    public Equipement equipement;
    public bool isEquipement;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;
    private Canvas _mainCanvas;

    //public var collision;

    private void Awake()
    {
        _mainCanvas = GetComponentInParent<Canvas>().rootCanvas;

        if (image == null)
        {
            //Debug.Log("image was null", image);
            image = GetComponent<Image>();
            //Debug.Log("new image", image);
        } else
        {
            Debug.Log("Image is not null", image);
        }
    }
    private void Start()
    {
        if(image != null && item.useColor)
        {
            image.color = item.color;
        }
    }
    public void InitializeItem(Item newItem)
    {
        Debug.Log("Initializing item "+ newItem.name);
        item = newItem;
        if (newItem.image != null)
        {
            isEquipement = false;
            Debug.Log("Item image " + newItem.image.name);
            image.sprite = item.image;
            RefreshCount();
        }
        else
        {
            Debug.LogError("newItem.image is null!");
        }
    }
    public void InitializeItem(Equipement newItem)
    {
        Debug.Log("Initializing item "+ newItem.name);
        item = newItem;
        if (newItem.image != null)
        {
            isEquipement = true;
            //Debug.Log("Item image " + newItem.image.name);
            image.sprite = item.image;
            RefreshCount();
        }
        else
        {
            Debug.LogError("newItem.image is null!");
        }
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false; // this will take out the raycast target
        parentAfterDrag = transform.parent; // store the current parent in case of missed drop
        transform.SetParent(_mainCanvas.transform ); // te the parent as the root, so it can hover over everything
        // transform.SetParent(transform.root ); // te the parent as the root, so it can hover over everything
        // transform.SetParent(null, true ); // te the parent as the root, so it can hover over everything
        transform.SetAsLastSibling(); // put it at the button but herarchi over sibling
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // move the element based on mouse position on the screen
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true; //reset the raycast to get the target
        transform.SetParent(parentAfterDrag); // reset the previous parent on drop (for now)
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collition with Inventory  Item "+item.name);

        //InventoryManager.instance.AddItem(item);
        // should destroy itself
        //Destroy(this);
    }

}
