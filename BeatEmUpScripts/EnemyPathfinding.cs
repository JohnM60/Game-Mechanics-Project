using System.Collections;
using UnityEngine;

/**
    Mosh Pit - EnemyPathfinding (Script)

    This should control the enemy node and it's pathfinding.
    TODO: Plan on making this a state machine with more complicated pathfinding goals.

    Right now it should just path directly to the Player Node, for the sake of simplicity in POC.
    - Nicholas R    
*/
public class EnemyPathfinding : MonoBehaviour {
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private GameObject enemy;
    private GameObject player;
    private Animator animController;
    public float lungeCooldown = 5f;
    public float lungeTime;
    public float attackPower = 20.0f;
    public float attackTime = 0.7f;
    public float attackCharge = 0.5f;
    public float attackInitiatedTime;
    public EnemyState state;
    public enum EnemyState {
        MOVING,
        CAN_ATTACK,
        ATTACKING
    }

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        lungeTime = Time.time;
        animController = gameObject.GetComponentInParent<Animator>();

        if (animController == null)
        {
            Debug.LogError("Object was not found.");
        }

        animController.SetBool("AttackAnim", false);
    }

    // Update is called once per frame
    void Update() {
        if (state == EnemyState.MOVING)
        {
            Move();
            animController.SetBool("AttackAnim", false);
        }

        if (state == EnemyState.CAN_ATTACK)
            StartCoroutine(Attack());

        if(state == EnemyState.ATTACKING){
            animController.SetBool("AttackAnim", true);

            if (attackInitiatedTime + attackCharge <= Time.time)
            {
                enemy.transform.position += attackPower * Time.deltaTime * transform.forward;
            }
        }
    }

    void Move() {
        if(player){

            if(lungeTime < Time.time && Vector2.Distance(enemy.transform.position, player.transform.position) <= 4.0f){
                state = EnemyState.CAN_ATTACK;
                lungeTime = Time.time + lungeCooldown;
            }else{
                transform.LookAt(player.transform.position);
                enemy.transform.position += speed * Time.deltaTime * transform.forward;
            }
        }
    }

    private IEnumerator Attack() {
        state = EnemyState.ATTACKING;
        attackInitiatedTime = Time.time;
        yield return new WaitForSeconds(attackTime);
        state = EnemyState.MOVING;
    }
}