using UnityEngine;

public class Composer : MonoBehaviour
{
    [SerializeField] private float spawnY = -2.8f;
    [SerializeField] private float leftNoteX = -1.87f;
    [SerializeField] private float upNoteX = -0.62f;
    [SerializeField] private float downNoteX = 0.62f;
    [SerializeField] private float rightNoteX = 1.87f;
    [SerializeField] private GameObject[] noteSequence;
    private int currentNoteIndex;
    private GameObject currentNote;

    // Start is called before the first frame update
    void Start()
    {
        float difficulty = 
            (RhythmManager.instance.GetDifficulty() - 1.0f) / 2.0f;

        currentNoteIndex = 0;

        spawnY -= difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNote != null) {
            Transform currentLastChild = 
                currentNote.GetComponent<Note>().GetLastChild();

            if (currentLastChild.position.y >= spawnY) {
                currentNoteIndex++;

                if (currentNoteIndex == noteSequence.Length) {
                    currentNoteIndex = 0;
                }

                SpawnNote();
            }
        } else {
            SpawnNote();
        }
    }

    private void SpawnNote() {
        float x = 0.0f;
        int control = Random.Range(0, 4);

        switch (control) {
            case 0:
                x = leftNoteX;

                break;
            case 1:
                x = upNoteX;

                break;
            case 2:
                x = downNoteX;

                break;
            case 3:
                x = rightNoteX;

                break;
        }

        currentNote = Instantiate(noteSequence[currentNoteIndex]);
        currentNote.transform.position = 
            new Vector3(x, currentNote.transform.position.y);
    }
}
