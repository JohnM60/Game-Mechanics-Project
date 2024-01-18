using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private GameObject shop;
    public int tickets = 300;
    public GameObject shopWindow;
    public Text scoreText;

    void Awake() {
        if (instance == null) {
            instance = this;
            SceneManager.CreateScene("newGame");
        }

        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTicketText();
        OpenShopMenu();
    }

    public void SetTicketText() {
        //scoreText.text = "Tickets: " + tickets.ToString();
    }

    void OpenShopMenu() {
        shop = Instantiate(shopWindow, transform.position, transform.rotation);
    }

    public void CloseShopMenu() {
        Destroy(shop);
    }
}

