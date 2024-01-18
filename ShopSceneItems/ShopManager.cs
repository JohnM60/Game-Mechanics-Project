using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    public bool inRange;
    public GameObject shop;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("in Range");
            inRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("not in range");
            inRange = false;
            shop.SetActive(false);
        }
    }
}
