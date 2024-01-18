using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) 
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;

            if(dropped.CompareTag("Buff")){
                InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
                draggableItem.parentAfterDrag = transform;
                dropped.GetComponentInChildren<PowerUp>().Enable();

            }else{
                //TODO
            }
        }
    }
}
