using UnityEngine;

public class OutlawPathing : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 4.0f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject projectile;
    private readonly float attackRate = 4f;
    private float attackCooldown = 0f;
    private GameObject player;
    private Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animController = gameObject.GetComponentInParent<Animator>();
        animController.SetBool("Move", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            // move towards player if not in range
            if (Vector2.Distance(enemy.transform.position, player.transform.position) >= 8.0f)
            {
                animController.SetBool("Move", true);
                gameObject.transform.LookAt(player.transform.position);
                enemy.transform.position += movementSpeed * Time.deltaTime * transform.forward;
            }
            else // start attacking player
            {
                animController.SetBool("Move", false);
                Attack();
            }
        }
    }

    void Attack()
    {
        if (Time.time > attackCooldown)
        {
            SoundManager.instance.PlayEnemySound("OutlawAttack");
            attackCooldown = Time.time + attackRate;
            //Debug.Log("enemy has attacked" + Time.time);
            //Instantiate(projectile, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
