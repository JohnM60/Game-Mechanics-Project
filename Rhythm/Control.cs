using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    [SerializeField] private KeyCode controlKey;
    [SerializeField] private Text controlText;
    [SerializeField] private Color32 activeColor;
    [SerializeField] private AudioSource controlAudio;
    private Color32 defaultColor;
    private GameObject currentNote;
    private GameObject currentNoteBlock;

    void Start()
    {
        defaultColor = controlText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(controlKey) || Input.GetKeyDown(controlKey)) {
            controlText.color = activeColor;

            if (!controlAudio.isPlaying) {
                controlAudio.Play();
            }

            if (currentNote && currentNoteBlock) {
                if (currentNote == currentNoteBlock.transform.parent.gameObject) {
                    Destroy(currentNoteBlock);
                }
            } else if (currentNote) {
                if (currentNote.transform.childCount == 0) {
                    RhythmManager.instance.DecrementBossHealth();

                    Destroy(currentNote);
                }
            }
        } else {
            controlAudio.Stop();

            controlText.color = defaultColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note Block") && !Input.GetKey(controlKey)) {
            currentNote = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Note Block")) {
            if (other.transform.position.y <= transform.position.y) {
                currentNoteBlock = other.transform.gameObject;
            } else {
                currentNoteBlock = null;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Note Block")) {
            currentNoteBlock = null;
        }
    }
}
