using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WeaponSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) 
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            if(dropped.CompareTag("Weapon")){
                InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
                draggableItem.parentAfterDrag = transform;

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if(player){
                    Instantiate(draggableItem.item.gameObject, player.transform.Find("Hands").transform);
                }

                //TODO add it to the players hands.
            }
        }
    }
}
