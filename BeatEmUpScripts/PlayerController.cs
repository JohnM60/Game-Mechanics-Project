using UnityEngine;

/**
    Mosh Pit - Player Controller Script

    This script should take Input from the 'player' and move the
    player object.

*/
public class PlayerController : MonoBehaviour {
    [Header("Controls")]
    public KeyCode up = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode down = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode useItem = KeyCode.Space;

    // Update is called once per frame
    void Update() {
        Move();
        Direction();
    }

    /**
        Moves the player in a Vector2 direction based on the key being pressed.
    */
    private void Move() {
        float speed = GlobalState.Get().GetSpeed();
        if(Input.GetKey(up)) transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(Input.GetKey(down)) transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(Input.GetKey(right)) transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(Input.GetKey(left)) transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(Input.GetKey(useItem)) {
            AbstractItem item = transform.Find("Hands").gameObject.GetComponentInChildren<AbstractItem>();
            if(item) item.Use();
        }
    }

    private void Direction()
    {
        if(Input.GetKey(left))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(right)) {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }  
}
