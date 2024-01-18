using UnityEngine;

public class OutlawBottle : MonoBehaviour
{
    [SerializeField] private float speed = 8.0f;
    private bool hasAimed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hasAimed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // so project only aims initially, not constantly tracking
        if (!hasAimed)
        {
            gameObject.transform.LookAt(player.transform.position);
            hasAimed = true;
        }

        //gameObject.transform.LookAt(player.transform.position);
        gameObject.transform.position += Time.deltaTime * transform.forward * speed;

        // projectily lifetime
        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.PlayPlayerSound("PlayerTakeDamage2");
            other.gameObject.GetComponent<Player>().Damage(5.0f);
            Destroy(gameObject);
        }

    }
}
