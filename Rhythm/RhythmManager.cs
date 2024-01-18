using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    [SerializeField] private int maxDifficulty = 4;
    [SerializeField] private int minDifficulty = 1;
    [SerializeField] private AudioSource playerHurt;
    [SerializeField] private Slider bossHealth;
    [SerializeField] private SpriteRenderer[] booManGroup;
    public static RhythmManager instance = null;
    private int difficulty;
    private int currentBooManIndex;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        difficulty = minDifficulty;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBooManIndex = 0;

        for (int i = 0; i < booManGroup.Length; i++) {
            booManGroup[i].enabled = false;
        }     
    }

    public void IncrementDifficulty () {
        if (difficulty < maxDifficulty) {
            difficulty++;
        }
    }

    public void DecrementDifficulty () {
        if (difficulty > minDifficulty) {
            difficulty--;
        }
    }

    public int GetDifficulty () {
        return difficulty;
    }

    public void RecordMissedNote () {
        if (currentBooManIndex == booManGroup.Length) {
            GlobalState.Get().sceneManager.ChangeScene(MScene.GAME_OVER);
            //SceneManager.LoadScene(gameOverSceneName);
        } else {
            playerHurt.Play();

            booManGroup[currentBooManIndex].enabled = true;

            currentBooManIndex++;
        }
    }

    public void DecrementBossHealth () {
        bossHealth.value -= 10;

        if (bossHealth.value <= 0) {
            GlobalState.Get().AddTickets(15);
            GlobalState.Get().difficultyMultiplier += 0.1f;
            GlobalState.Get().sceneManager.ChangeScene(MScene.MOSH);
            instance.IncrementDifficulty();
            //SceneManager.LoadScene(beatEmUpSceneName);
        }
    }
}
