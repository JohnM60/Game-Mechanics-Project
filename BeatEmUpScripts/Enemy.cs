using Unity.VisualScripting;
using UnityEngine;

/**
    Mosh Pit - Enemy Script

    Script that holds enemy data, Controller/Pathfinding should be contained
    in seperate script.
*/
public class Enemy : MonoBehaviour {

    [SerializeField] GameObject ticket;
    [SerializeField] private AudioSource enemyAudio;
    [SerializeField] private AudioClip hit;

    [SerializeField] float initialMaxHealth = 100.0f;
    [SerializeField] float initialDamage = 2.0f;

    public float maxHealth;
    public float health;
    public float damageAmount;

    // for audio
    private float attackCooldown = 0f;
    private float attackRate = 3.0f;

    // Start is called before the first frame update
    void Start() {
        maxHealth = initialMaxHealth * GlobalState.Get().difficultyMultiplier;
        damageAmount = initialDamage * GlobalState.Get().difficultyMultiplier;
        health = maxHealth;
        enemyAudio = GetComponent<AudioSource>();
    }

    public void Damage(float amount) {
        health -= amount;
        //audio.clip = hit;
        //audio.PlayDelayed(0);
        if (health <= 0) OnDeath();
    }

    /**
        Function is called when this object dies, handle related events here.
    */
    public void OnDeath() {
        GameObject ticketInst = Instantiate(ticket);
        ticketInst.transform.position = transform.position;

        Destroy(gameObject);
    }

    /**
        Collision Detection for Colliding with players weapon.

        All Weapons/Items should extend AbstractItem.
    */
    private void OnTriggerEnter2D(Collider2D collision) {
        AbstractItem abstractItem = collision.gameObject.GetComponent<AbstractItem>();
        
        if(abstractItem){
            SoundManager.instance.PlayPlayerSound("CrawlerTakeDamage");
            Damage(abstractItem.damage);
            Debug.Log(abstractItem.damage);
        }
        if (collision.CompareTag("Player") && Time.time > attackCooldown)
        {
            attackCooldown = Time.time + attackRate;
            SoundManager.instance.PlayPlayerSound("PlayerTakeDamage");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Player player = collision.gameObject.GetComponent<Player>();

        if(player){
            player.Damage(damageAmount);
        }
    }
}
