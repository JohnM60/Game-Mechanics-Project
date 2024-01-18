using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{

    private GameObject player;
    public static bool isMagnet = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnet)
        {
            MoveTowardsPlayer();
        }
    }
    // move towards player
    public void MoveTowardsPlayer()
    {
        transform.position = Vector3.Lerp(this.transform.position, player.transform.position, 4f * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalState.Get().AddTickets(1);
            Debug.Log("TICKETS = " + GlobalState.Get().GetTickets());
            Destroy(this.gameObject);
        }
    }
}
