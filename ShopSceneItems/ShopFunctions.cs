using UnityEngine;
using UnityEngine.UI;

public class ShopFunctions : MonoBehaviour
{
    [SerializeField] private AudioClip basicDrum;
    [SerializeField] private AudioClip pluck;
    [SerializeField] private AudioClip bell;
    [SerializeField] private AudioClip tap;
    [SerializeField] private AudioSource shopAudio;
    private int randomVar;
    private int randomVar2;
    private int randomVar3;
    private int cost1; // temp cost until we can get item costs
    private int cost2;
    private int cost3;
    public AbstractItem[] items;
    public Text Slot1;
    public Text Slot2;
    public Text Slot3;

    // Start is called before the first frame update
    void Start()
    {
        shopAudio = GetComponent<AudioSource>();
        // temp
        cost1 = Random.Range(10, 50);
        cost2 = Random.Range(10, 50);
        cost3 = Random.Range(10, 50);

        spawnRandomItems();
    }

    // spawning 3 random items from the array.
    // very simple right now 
    public void spawnRandomItems()
    {
        // TODO stop dupes from spawning
        randomVar = Random.Range(0, items.Length);
        randomVar2 = Random.Range(0, items.Length);
        randomVar3 = Random.Range(0, items.Length);

        Slot1.text = items[randomVar].name + " " + cost1;
        Slot2.text = items[randomVar2].name + " " + cost2;
        Slot3.text = items[randomVar3].name + " " + cost3;
    }

    public void BuyShopItem1()
    {
        Debug.Log(items[randomVar].ToString() + cost1);

        if (GlobalState.Get().GetTickets() >= cost1)
        {
            GlobalState.Get().RemoveTickets(cost1);
            // send to inventory right here
            //GlobalState.Get().inventory.AddItem(items[randomVar]);
            GlobalState.Get().inventoryGameObject.transform.GetChild(0).gameObject.GetComponent<InventoryManager>().AddItem(items[randomVar]);
        }
    }

    public void BuyShopItem2()
    {
        Debug.Log(items[randomVar2].ToString() + cost2);
        
        if (GlobalState.Get().GetTickets() >= cost2)
        {
            GlobalState.Get().RemoveTickets(cost2);
            // send to inventory right here
            GlobalState.Get().inventoryGameObject.transform.GetChild(0).gameObject.GetComponent<InventoryManager>().AddItem(items[randomVar]);
        }
    }

    public void BuyShopItem3()
    {
        Debug.Log(items[randomVar3].ToString() + cost3);
        
        if (GlobalState.Get().GetTickets() >= cost3)
        {
            GlobalState.Get().RemoveTickets(cost3);
            // send to inventory right here
            GlobalState.Get().inventoryGameObject.transform.GetChild(0).gameObject.GetComponent<InventoryManager>().AddItem(items[randomVar]);
        }
    }

    public void CloseShop()
    {
        //maybe not best way to do this
        gameObject.SetActive(false);
    }

    /*
    public void BuyDrum() {
        if (GameManager.instance.tickets >= 30) {
            GameManager.instance.tickets -= 30;
            GameManager.instance.SetTicketText();
            storeAudio.clip = basicDrum;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuyGuitar() {
        if (GameManager.instance.tickets >= 50) {
            GameManager.instance.tickets -= 50;
            GameManager.instance.SetTicketText();
            storeAudio.clip = pluck;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuyBell() {
        if (GameManager.instance.tickets >= 70) {
            GameManager.instance.tickets -= 70;
            GameManager.instance.SetTicketText();
            storeAudio.clip = bell;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuyStrength() {
        if (GameManager.instance.tickets >= 40) {
            GameManager.instance.tickets -= 40;
            GameManager.instance.SetTicketText();
            storeAudio.clip = tap;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuyHealth() {
        if (GameManager.instance.tickets >= 30) {
            GameManager.instance.tickets -= 30;
            GameManager.instance.SetTicketText();
            storeAudio.clip = tap;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuySpeed() {
        if (GameManager.instance.tickets >= 40) {
            GameManager.instance.tickets -= 40;
            GameManager.instance.SetTicketText();
            storeAudio.clip = tap;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuySkill1() {
        if (GameManager.instance.tickets >= 120) {
            GameManager.instance.tickets -= 120;
            GameManager.instance.SetTicketText();
            storeAudio.clip = tap;
            storeAudio.PlayDelayed(0);
        }
    }

    public void BuySkill2() {
        if (GameManager.instance.tickets >= 90) {
            GameManager.instance.tickets -= 90;
            GameManager.instance.SetTicketText();
            storeAudio.clip = tap;
            storeAudio.PlayDelayed(0);
        }
    }

    public void UpgradeInst() {
        if (GameManager.instance.tickets >= 100) {
            GameManager.instance.tickets -= 100;
            GameManager.instance.SetTicketText();
            storeAudio.clip = tap;
            storeAudio.PlayDelayed(0);
        }
    }
    */
}
