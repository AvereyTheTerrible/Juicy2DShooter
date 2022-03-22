using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackFlashSprite : Feedback
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    [SerializeField]
    private float flashTime = 0.1f;
    [SerializeField]
    private Material flashMaterial = null;

    private Shader originalMaterialShader;

    private void Start()
    {
        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterialShader = spriteRenderer.material.shader;
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        spriteRenderer.material.shader = originalMaterialShader;
    }

    public override void CreateFeedback()
    {
        if (!spriteRenderer.material.HasProperty("_MakeSolidColor"))
            spriteRenderer.material.shader = flashMaterial.shader;

        spriteRenderer.material.SetInt("_MakeSolidColor", 1);
        StartCoroutine(WaitBeforeChangingBack());
    }

    private IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSecondsRealtime(flashTime);
        if (spriteRenderer.material.HasProperty("_MakeSolidColor"))
            spriteRenderer.material.SetInt("_MakeSolidColor", 0);
        else
            spriteRenderer.material.shader = originalMaterialShader;
    }
}