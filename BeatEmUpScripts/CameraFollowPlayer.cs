using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    /**
     * makes the camera follow the player
     */
    public Transform player;

    private void Update()
    {
        // assumes z "height" has been set in the inspector
        transform.position = new Vector3(
            player.position.x, 
            player.position.y, 
            transform.position.z
        );
    }
}
