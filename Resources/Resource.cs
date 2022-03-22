using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Resource : MonoBehaviour
{
    [field: SerializeField]
    public SOResourceData ResourceData { get; set; }

    [field: SerializeField]
    private SpriteRenderer shadowRenderer;
    [SerializeField]
    private bool shouldDestroy;

    [field: SerializeField]
    public UnityEvent DestroyEvent { get; set; }


    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (shouldDestroy)
            DestroyEvent?.Invoke();
    }

    public void PickUpResource()
    {
        StartCoroutine(DestroyCoroutine(audioSource.clip.length));
    }

    private IEnumerator DestroyCoroutine(float time)
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        shadowRenderer.enabled = false;
        audioSource.Play();
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
}