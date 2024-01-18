using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrumsItem : AbstractItem{
    [SerializeField] private float cooldown = 3.0f;
    [SerializeField] private MusicNote projectile;
    private float shootTime = 0.0f;
    private GameObject player;

    private SpriteRenderer spriteRenderer;

    private Vector3[] notes = {new Vector3(-1.0f, 1.0f, 0.0f), new Vector3(-1.5f, 0.3f, 0.0f), new Vector3(-1.5f, -0.3f, 0.0f), new Vector3(-1.0f, -1.0f, 0)};

    public override void Use() {
        if (shootTime <= Time.time) {
            spriteRenderer.enabled = true;
            SoundManager.instance.PlayPlayerSound("PlayerAttackDrums");
            foreach(Vector3 notePos in notes){
                MusicNote proj = Instantiate(projectile);
                proj.transform.position = player.transform.position;
                Vector3 offset = notePos * player.transform.localScale.x;
                proj.transform.Translate(offset);
                proj.direction.Set(player.transform.localScale.x * -1, 0.0f);
                proj.owner = this;
            }
            StartCoroutine(Freeze());
            shootTime = Time.time + cooldown;
        }
    }

    IEnumerator Freeze(){
        float oldSpeed = GlobalState.Get().GetSpeed();
        GlobalState.Get().SetSpeed(0.0f);
        yield return new WaitForSeconds(1);
        GlobalState.Get().SetSpeed(oldSpeed);
        spriteRenderer.enabled = false;
    }

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
}
