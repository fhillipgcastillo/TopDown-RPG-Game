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
    
    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    private void Start()
    {
        InitializeItem(item);
    }

    private void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false; // this will take out the raycast target
        parentAfterDrag = transform.parent; // store the current parent in case of missed drop
        transform.SetParent(transform.root ); // te the parent as the root, so it can hover over everything
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
