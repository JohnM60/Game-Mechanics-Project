using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] Text ticketText;

    // the starting weapon will go in here.
    public AbstractItem[] startItems;

    public InventorySlot[] invSlots;
    public BuffSlot[] buffSlots;
    public GameObject inventoryItemPrefab;
    public Text Tickets; // text values
    public Text Health;
    public Text Damage;
    public Text Speed;

    private void Start()
    {
        foreach (var item in startItems)
        {
            AddItem(item);
        }
    }

    // adds item to the inventory in the nearest open slot
    // returns true if item was successfully added to inv, false otherwise.
    public bool AddItem(AbstractItem item)
    {
             for (int i = 0; i < invSlots.Length; i++)
            {
                InventorySlot slot = invSlots[i];
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot == null && i != 20) // cant spawn in equip slot
                {
                    SpawnNewItem(item, slot);
                    return true;
                }

            }

        return false;
    }

    // spawns the item in the slot
    void SpawnNewItem(AbstractItem item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem invItem = newItemGo.GetComponent<InventoryItem>();
        invItem.InitialiseItem(item);
    }

    //gets the current item in the equipped slot and returns it, if none returns null
    public AbstractItem GetEquippedWeapon()
    {
        InventorySlot slot = invSlots[20];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Debug.Log("EQUIP");
            return itemInSlot.item;
        }
        return null;
    }

    // functions that get the current item in the buff slots
    public AbstractItem GetBuffSlot1()
    {
        BuffSlot slot = buffSlots[0];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Debug.Log("EQUIP");
            return itemInSlot.item;
        }
        return null;
    }

    public AbstractItem GetBuffSlot2()
    {
        BuffSlot slot = buffSlots[1];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Debug.Log("EQUIP");
            return itemInSlot.item;
        }
        return null;
    }

    public AbstractItem GetBuffSlot3()
    {
        BuffSlot slot = buffSlots[2];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Debug.Log("EQUIP");
            return itemInSlot.item;
        }
        return null;
    }

    public void Pause(){
        Time.timeScale = 0;
    }

    public void Play(){
        Time.timeScale = 1;
    }

    /**
    * Not how this should be done, should use events & listeners.
    * Out of time and don't want to implement it the right way.
    */
    void Update(){
        Tickets.text = "Tickets: " + GlobalState.Get().GetTickets();
        Health.text = "Health: " + GlobalState.Get().GetPlayerHealth();
        Speed.text = "Speed: " + GlobalState.Get().GetSpeed();
        // TODO Add damage <-
    }

    // public void setInvDmgText()
    // {
    //     Damage.text = "Damage: " + GlobalState.Get().getItemDmg();
    // }
}
