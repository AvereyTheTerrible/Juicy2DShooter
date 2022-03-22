using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [field: SerializeField]
    public AgentAnimationManager AnimationManager { get; set; }

    [field: SerializeField]
    public SOMovementData MovementData { get; set; }

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    private float currentSpeed;

    private Vector2 movementDirection;

    protected bool isKnockedBack = false;

    private void Awake()
    {
        if (!rigidBody)
            rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            movementDirection = movementInput.normalized;
        }

        currentSpeed = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
            currentSpeed += MovementData.acceleration * Time.deltaTime;
        else
            currentSpeed -= MovementData.deceleration * Time.deltaTime;

        return Mathf.Clamp(currentSpeed, 0, MovementData.maxSpeed);
    }


    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentSpeed);
        if (!isKnockedBack)
            rigidBody.velocity = currentSpeed * movementDirection.normalized;
        
    }

    public void StopImmediately()
    {
        currentSpeed = 0;
        rigidBody.velocity = Vector2.zero;
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        if (!isKnockedBack)
        {
            isKnockedBack = true;
            StartCoroutine(KnockBackCoroutine(direction, power, duration));
        }
    }

    public void StopAllMovement()
    {
        rigidBody.velocity = Vector2.zero;
        currentSpeed = 0;
    }

    public void ResetKnockBack()
    {
        StopCoroutine("KnockBackCoroutine");
        ResetKnockBackParameters();
    }

    private IEnumerator KnockBackCoroutine(Vector2 direction, float power, float duration)
    {
        rigidBody.AddForce(direction.normalized * power, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(duration);
        ResetKnockBackParameters();
    }

    private void ResetKnockBackParameters()
    {
        currentSpeed = 0;
        rigidBody.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
