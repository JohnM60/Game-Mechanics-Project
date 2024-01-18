using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/**
* Tracks when to switch scenes to the Rhythm Section.
*/
public class RhythmTimer : MonoBehaviour{
    [SerializeField] private float minTimeSeconds = 90.0f;
    [SerializeField] private float maxTimeSeconds = 180.0f;

    [SerializeField] GameObject notification;
    private Text text;
    private float nextEncounter;

    // Start is called before the first frame update
    void Start() {
        notification.SetActive(false);
        text = gameObject.GetComponent<Text>();
        GlobalState.Get().SetLastBossEncounterTime();
        float offset = Random.Range(minTimeSeconds, maxTimeSeconds);
        nextEncounter = GlobalState.Get().lastBossEncounterTime + offset;
    }

    // Update is called once per frame
    void Update() {
        int timeRemaining = (int)Mathf.Ceil(nextEncounter - Time.time);
        if(timeRemaining == 0){
            StartCoroutine(SwitchLevels());
        } else{
            text.text = "BAND ENCOUNTER IN " + timeRemaining + "s";
        }
    }

    IEnumerator SwitchLevels(){
        notification.SetActive(true);
        notification.GetComponent<Animator>().SetTrigger("MoshEnd");
        yield return new WaitForSeconds(2.0f);
        GlobalState.Get().sceneManager.ChangeScene(MScene.RHYTHM);
    }
}
