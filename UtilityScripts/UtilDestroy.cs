using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UtilDestroy : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy, timeToFlash;

    private float timeToDestroyCounter;

    [SerializeField]
    private GameObject GOToDestroy;
    [field: SerializeField]
    public UnityEvent FlashEvent { get; set; }

    private void Awake()
    {
        timeToDestroyCounter = timeToDestroy;
    }

    public void DestroyAfterTime()
    {
        StartCoroutine(DestroyAfterTimeCoroutine());
    }

    private IEnumerator DestroyAfterTimeCoroutine()
    {
        while (timeToDestroyCounter > 0)
        {
            timeToDestroyCounter -= 0.2f;
            if (timeToDestroyCounter <= timeToFlash)
            {
                FlashEvent?.Invoke();

            }
            yield return new WaitForSecondsRealtime(0.2f);
        }

        Destroy(GOToDestroy);
    }
}