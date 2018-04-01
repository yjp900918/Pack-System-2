using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

    public Item item;
    public int slotIndex;

    Bag bag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            this.transform.SetParent(transform.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(bag.slots[slotIndex].transform);
        this.transform.position = this.transform.parent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // Use this for initialization
    void Start () {
        bag = GameObject.Find("ItemDataBase").GetComponent<Bag>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
