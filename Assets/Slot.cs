using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

    public int slotID;

    Bag bag;

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(bag.items[slotID].ID == -1)
        {
            bag.items[droppedItem.slotIndex] = new Item();
            droppedItem.slotIndex = slotID;
            bag.items[slotID] = droppedItem.item;
        }
        else if(droppedItem.slotIndex != slotID)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotIndex = droppedItem.slotIndex;
            item.transform.SetParent(bag.slots[droppedItem.slotIndex].transform);
            item.transform.position = item.transform.parent.position;

            bag.items[droppedItem.slotIndex] = item.GetComponent<ItemData>().item;
            droppedItem.slotIndex = slotID;
            bag.items[slotID] = droppedItem.item;
        }
    }

    // Use this for initialization
    void Start () {
        bag = GameObject.Find("ItemDataBase").GetComponent<Bag>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
