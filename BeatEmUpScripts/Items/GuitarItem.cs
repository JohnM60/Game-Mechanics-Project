using UnityEngine;

public class GuitarItem : AbstractItem{
    [SerializeField] private GameObject handlePoint;
    [SerializeField] private GameObject handleTarget;
    [SerializeField] private AudioClip pluck2;
    [SerializeField] private AudioSource itemAudio;
    private bool audioHasPlayed = false;

    void Start() {
        itemAudio = GetComponent<AudioSource>();
    }
    
    public override void Use() {
        if (!audioHasPlayed)
        {
            SoundManager.instance.PlayPlayerSound("PlayerAttackGuitar");
            audioHasPlayed = true;
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        GameObject.FindGameObjectWithTag("Player")
                .GetComponent<Animator>().SetTrigger("Attack");
        Invoke(nameof(DisableCollider), 1.0f);
    }

    private void DisableCollider() {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        audioHasPlayed = false;
    }

    private void Update()
    {
        LinkHandleToObject();
    }

    private void LinkHandleToObject()
    {
        handlePoint.transform.position = handleTarget.transform.position;
    }
}
