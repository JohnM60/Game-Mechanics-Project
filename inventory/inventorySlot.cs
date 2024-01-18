using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData) 
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
            draggableItem.parentAfterDrag = transform;

            if(dropped.CompareTag("Buff")){
                dropped.GetComponentInChildren<PowerUp>().Disable();
            }
            if(dropped.CompareTag("Weapon")){
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if(player){
                    if(player.transform.Find("Hands").childCount > 0){
                        Destroy(player.transform.Find("Hands").GetChild(0).gameObject);
                    }
                }
            }
        }
    }
}
