using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject GOToSpawn;

    [SerializeField]
    private int minAmountToSpawn, maxAmountToSpawn;
    [SerializeField]
    private float timeToWaitBeforeSpawn;

    public void SpawnGO()
    {
        StartCoroutine(SpawnCoroutine());


    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSecondsRealtime(timeToWaitBeforeSpawn);
        var randomAmount = Random.Range(minAmountToSpawn, maxAmountToSpawn + 1);

        for (int i = 0; i < randomAmount; i++)
        {
            var randomPosition = Random.insideUnitCircle;
            Instantiate(GOToSpawn, (Vector3)randomPosition + transform.position, Quaternion.identity);
        }
    }
}