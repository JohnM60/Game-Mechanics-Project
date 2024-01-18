using UnityEngine;

public class MicrophoneItem : AbstractItem {
    [SerializeField] private float cooldown = 1.5f;
    [SerializeField] private MusicNote projectile;
    private float shootTime = 0.0f;
    private GameObject player;

    public override void Use() {
        if (shootTime <= Time.time) {
            SoundManager.instance.PlayPlayerSound("PlayerAttackMicrophone");
            projectile.transform.position = player.transform.position;
            projectile.direction.Set(player.transform.localScale.x * -1, 0.0f);
            projectile.owner = this;
            Instantiate(projectile);
            shootTime = Time.time + cooldown;
        }
    }

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
