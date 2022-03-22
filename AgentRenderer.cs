using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [field: SerializeField]
    public UnityEvent<int> OnBackwardMovement { get; set; }
    [field: SerializeField]
    public UnityEvent OnDieFinish { get; set; }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void FaceDirection(Vector2 pointerInput)
    {
        var direction = (Vector3)pointerInput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);
        if (result.z > 0)
            spriteRenderer.flipX = true;
        else if (result.z < 0)
            spriteRenderer.flipX = false;
    }
    
    public void InvokeDieFinish()
    {
        OnDieFinish?.Invoke();
    }

    public void CheckMovementDirection(Vector2 movementVector)
    {
        float angle = 0;
        if (spriteRenderer.flipX)
            angle = Vector2.Angle(-transform.right, movementVector);
        else
            angle = Vector2.Angle(transform.right, movementVector);
        if (angle > 90)
            OnBackwardMovement?.Invoke(-1);
        else
            OnBackwardMovement?.Invoke(1);
    }
}
