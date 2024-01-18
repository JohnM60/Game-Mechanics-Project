using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /**
     * 
     * constantly get player cordinates
     * spawn enemy prefabs around player,
     * but outside camera view
     */
    [SerializeField] private float minSpawnRadius = 10f; // 8 units = distance from camera
    [SerializeField] private float maxSpawnRadius = 14f; // 8 units = distance from camera
    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;
    private GameObject player;
    public List<GameObject> EnemyList = new();

    private void Awake()
    {
        player = GameObject.FindWithTag("Player"); 
    }

    private void Update()
    {
        // make spawn follow the player
        gameObject.transform.position = player.transform.position;

        if (Time.time > spawnTimer)
        {
            SpawnRandomEnemy();
            spawnTimer = Time.time + spawnRate;
        }
    }

    private void SpawnRandomEnemy()
    {
        int[] direction = {-1, 1};
        float spawnPosX = player.transform.position.x + ( UnityEngine.Random.Range(minSpawnRadius, maxSpawnRadius) * direction[UnityEngine.Random.Range(0, 2)] );
        float spawnPosY = player.transform.position.y + ( UnityEngine.Random.Range(minSpawnRadius, maxSpawnRadius) * direction[UnityEngine.Random.Range(0, 2)] );
        Instantiate(EnemyList[UnityEngine.Random.Range(0, EnemyList.Count)], new Vector2(spawnPosX, spawnPosY), Quaternion.Euler(0, 0, 0));
        //Debug.Log("enemy spawned at x: " + spawnPosX + ", y: " + spawnPosY);
    }
}
