using UnityEngine;

public class MainMenu : MonoBehaviour{
    void Start() {
        GameObject inventory = Instantiate((GameObject)Resources.Load(
            "InventoryModule", 
            typeof(GameObject)
        ));
        GlobalState.Get().inventoryGameObject = inventory;
        DontDestroyOnLoad(inventory);
        inventory.SetActive(false);
    }

    public void Play() {
        GlobalState.Get().sceneManager.ChangeScene(MScene.MOSH);
    }

    public void Quit() {
        Application.Quit();
    }
}
