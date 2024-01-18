using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    [SerializeField] private AudioSource playerDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        playerDeath.Play();
    }
}
