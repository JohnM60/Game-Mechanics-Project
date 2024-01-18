using UnityEngine;

/**
    Singleton GlobalState - Script

    This should contain global data for multiple scenes to access.

*/
public class GlobalState {
    private static GlobalState state = null;
    private float health;
    private float speed = 10.0f;
    private int tickets;
    public float lastBossEncounterTime;
    public float difficultyMultiplier;
    public float maxHealth = 100.0f;
    public MSceneManager sceneManager;
    public GameObject inventoryGameObject;
    public Player player;

    public GlobalState() {
        sceneManager = new MSceneManager();
        tickets = 0;
        difficultyMultiplier = 1.0f;
        lastBossEncounterTime = 0.0f;
        health = maxHealth;
    }

    public static GlobalState Get() {
        state ??= new GlobalState();
        return state;
    }

    public int GetTickets() { 
        return tickets; 
    }

    public void SetTickets(int i) { 
        tickets = i; 
    }

    public void AddTickets(int i) {
        tickets += i;
    }

    public void RemoveTickets(int i) {
        if (tickets - i < 0) {
            tickets = 0;
        } else {
            tickets -= i;
        }
    }

    public void SetLastBossEncounterTime() {
        lastBossEncounterTime = Time.time;
    }

    public void SetMaxHealth(float newHealth){
        maxHealth = newHealth;
    }

    public float GetMaxHealth(){
        return maxHealth;
    }

    public float GetPlayerHealth() {
        return health;
    }

    public void SetPlayerHealth(float newHealth) {
        health = newHealth;
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }
}
