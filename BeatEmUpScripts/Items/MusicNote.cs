using UnityEngine;

public class MusicNote : MonoBehaviour {
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float lifetime = 3.0f;
    [SerializeField] private Sprite[] sprites;
    public AbstractItem owner;
    public Vector2 direction = new(0,0);

    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<SpriteRenderer>().sprite = 
            sprites[Random.Range(0, sprites.Length)];
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Enemy")) {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.Damage(owner.damage);
            Destroy(gameObject);
            //Debug.Log("Collision!");
            //Debug.Log(enemy.health + " / " + enemy.maxHealth);
        }
        //Debug.Log("Collided with " + collider.gameObject.name);
    }
}
