using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private float damageRate = 1.0f;
    [SerializeField] private Slider health;
    private float damageTime;
    public AudioClip hurt;
    public AudioClip death;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start() {
        float healthValue = GlobalState.Get().GetPlayerHealth();

        playerAudio = GetComponent<AudioSource>();
        health.maxValue = healthValue;
        health.value = healthValue;
    }

    public void Damage(float amount) {
        if (Time.time > damageTime) {
            float newHealth = GlobalState.Get().GetPlayerHealth() - amount;

            health.value = newHealth;

            GlobalState.Get().SetPlayerHealth(newHealth);

            //audio.clip = hurt;
            //audio.PlayDelayed(0);
            if (GlobalState.Get().GetPlayerHealth() <= 0) {
                //audio.clip = death;
                //audio.PlayDelayed(0);
                OnDeath(); 
            }

            damageTime = Time.time + damageRate;
        } 
    }

    public void OnDeath() {
        GlobalState.Get().sceneManager.ChangeScene(MScene.GAME_OVER);
    }

    // Player can only take damage every x seconds
    // Default is set to 3 seconds.
    // public void OnCollisionStay2D(Collision2D collision){
    //     Debug.Log("Player collision with enemy");
    //     if(collision.collider.gameObject.CompareTag("Enemy") && Time.time > damageTime){
    //         damage(20.0f);
    //         Debug.Log("player took" + 20.0f + "damage");
    //     }
    // }
}
