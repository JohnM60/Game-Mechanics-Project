using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {
    [SerializeField] private Enemy owner;
    private Image image;

    void Start() {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        image.fillAmount = owner.health / owner.maxHealth;
    }
}
