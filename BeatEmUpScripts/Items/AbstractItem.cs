using UnityEngine;

public abstract class AbstractItem : MonoBehaviour {
    public float damage = 50.0f;
    public Sprite image;
    public Animator playerAnimation;

    // Start is called before the first frame update
    void Start() {}

    void OnCollisionEnter2D(Collision2D collision) {
        //TODO
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<InventoryManager>().AddItem(this);  //not 100% sure this is the right place to put this.
            Destroy(gameObject);
        }

    }

    public abstract void Use();
}
