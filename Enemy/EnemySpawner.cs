using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs;
    [SerializeField]
    private List<GameObject> spawnPoints;
    [SerializeField]
    private int count = 20;
    [SerializeField]
    private float minDelay = 0.8f, maxDelay = 1.5f;

    private IEnumerator SpawnCoroutine()
    {
        while (count > 0)
        {
            count--;
            var randomIndex = Random.Range(0, spawnPoints.Count);

            var randomOffset = Random.insideUnitCircle;
            var spawnPoint = spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;

            SpawnEnemy(spawnPoint);

            var randomTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSecondsRealtime(randomTime);
        }
    }

    private void SpawnEnemy(Vector3 spawnPoint)
    {
        var randomIndex = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomIndex], spawnPoint, Quaternion.identity);
    }

    private void Start()
    {
        if (spawnPoints.Count > 0)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                SpawnEnemy(spawnPoint.transform.position);
            }
        }

        StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}