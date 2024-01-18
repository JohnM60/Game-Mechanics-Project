using UnityEngine;
using UnityEngine.SceneManagement;

/**
    Singleton GlobalState - Script

    This should contain global data for multiple scenes to access.

*/
public class MSceneManager{
    public MScene currentScene;
    public MSceneManager(){
        currentScene = MScene.MAIN_MENU;
    }
    public void ChangeScene(MScene scene){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GameObject inventory = GlobalState.Get().inventoryGameObject;
        inventory.SetActive(scene == MScene.MOSH);
        SceneManager.LoadScene((int)scene);
    }

}

public enum MScene{
    MAIN_MENU,
    RHYTHM,
    MOSH,
    GAME_OVER
}