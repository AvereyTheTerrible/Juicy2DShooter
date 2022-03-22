using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectToSpawn = null;
    [SerializeField]
    protected int poolSize = 30;
    protected int currentSize;
    protected Queue<GameObject> objectPool;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    public virtual GameObject SpawnObject(GameObject currentObject = null)
    {
        if (!currentObject)
            currentObject = objectToSpawn;

        GameObject spawnedObject = null;

        if (currentSize < poolSize)
        {
            spawnedObject = Instantiate(currentObject, transform.position, Quaternion.identity);
            spawnedObject.name = currentObject.name + "_" + currentSize;
            currentSize++;
        }

        else
        {
            spawnedObject = objectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
        }

        objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }
}