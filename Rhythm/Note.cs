using System;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float baseY = 5.25f;
    [SerializeField] private float minScrollSpeed = 1.0f;
    private float scrollSpeed;
    private float destroyY;
    private float spawnY;

    void Start()
    {
        destroyY = baseY + Math.Abs(GetLastChild().position.y);
        spawnY = -baseY;
        scrollSpeed = minScrollSpeed 
            + ((RhythmManager.instance.GetDifficulty() - 1.0f) / 2.0f);
        transform.position = new Vector3(transform.position.x, spawnY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= destroyY) {
            RhythmManager.instance.RecordMissedNote();

            Destroy(gameObject);
        }

        transform.Translate(scrollSpeed * Time.deltaTime * Vector3.up);
    }

    public Transform GetLastChild() {
        int lastChildIndex = transform.childCount - 1;
        
        return transform.GetChild(lastChildIndex);
    }
}
