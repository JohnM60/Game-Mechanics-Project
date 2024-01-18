using UnityEngine;

public class GameOver : MonoBehaviour {
    public void Restart() {
        GlobalState state = GlobalState.Get();
        Destroy(state.inventoryGameObject);
        state.difficultyMultiplier = 1.0f;
        state.SetTickets(0);
        state.SetMaxHealth(100.0f);
        state.SetPlayerHealth(100.0f);
        state.SetSpeed(10.0f);
        state.sceneManager.ChangeScene(MScene.MAIN_MENU);
    }
}
