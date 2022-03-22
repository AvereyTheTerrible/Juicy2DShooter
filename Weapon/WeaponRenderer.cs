using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField]
    private int playerSortingIndex = 0;

    [SerializeField]
    private SpriteRenderer weaponRenderer;

    private void Awake()
    {
        if (!weaponRenderer)
            weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool val)
    {
        int flipModifier = val ? -1 : 1;
        transform.localScale = new Vector2(
            transform.localScale.x, 
            flipModifier * Mathf.Abs(transform.localScale.y));
    }

    public void RenderBehindHead(bool val)
    {
        if (val)
            weaponRenderer.sortingOrder = playerSortingIndex - 1;
        else
            weaponRenderer.sortingOrder = playerSortingIndex + 1;
    }
}