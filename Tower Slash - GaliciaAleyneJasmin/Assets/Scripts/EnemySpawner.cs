using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    public Player player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float minSpawnInterval;
    [SerializeField] private float maxSpawnInterval;
    private float spawnInterval;
    private float spawnTime;

    void Update()
    {
        if (Time.time > spawnTime && !player.isInvulnerable && !player.isDead)
        {
            SpawnEnemies();
            spawnTime = Time.time + spawnInterval;
        }

        else if (Time.time > spawnTime && player.isInvulnerable && !player.isDead)
        {
            SpawnEnemies();
            spawnTime = Time.time + spawnInterval / 4;
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    private void SpawnEnemies()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemies.Add(enemy);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.player = player;
    }
}
