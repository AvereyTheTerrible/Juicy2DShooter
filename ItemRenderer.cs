using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRenderer : MonoBehaviour
{
    [SerializeField]
    private Sprite defaultSprite = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ResetSprite()
    {
        spriteRenderer.sprite = defaultSprite;
    }
}