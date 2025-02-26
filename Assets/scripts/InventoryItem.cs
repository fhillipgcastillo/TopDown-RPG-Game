using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public int countText = 1;

    /*[HideInInspector]*/ public Item item;
    [HideInInspector] public Transform parentAfterDrag;
    private void Awake()
    {
        if (image == null)
        {
            Debug.Log("image was null", image);
            image = GetComponent<Image>();
            Debug.Log("new image", image);
        } else
        {
            Debug.Log("Image is not null", image);
        }
    }
    public void InitializeItem(Item newItem)
    {
        Debug.Log("Initializing item "+ newItem.name);
        item = newItem;
        if (newItem.image != null)
        {
            Debug.Log("Item image " + newItem.image.name);
            //image = GetComponent<Image>();
            image.sprite = item.image;
        }
        else
        {
            Debug.LogError("newItem.image is null!");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false; // this will take out the raycast target
        parentAfterDrag = transform.parent; // store the current parent in case of missed drop
        transform.SetParent(transform.root ); // te the parent as the root, so it can hover over everything
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

}
