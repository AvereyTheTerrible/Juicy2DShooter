using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    [SerializeField]
    private Camera mainCamera;

    private bool fireButtonPressed = false;

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }
    private void Awake()
    {
        if (!mainCamera)
            mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (!fireButtonPressed)
            {
                fireButtonPressed = true;
                OnFireButtonPressed?.Invoke();
            }
        }


        else
        {
            if (fireButtonPressed)
            {
                fireButtonPressed = false;
                OnFireButtonReleased?.Invoke();
            }

        }

    }

    private void GetPointerInput()
    {
        Vector3 pointerPos = Input.mousePosition;
        pointerPos.z = mainCamera.nearClipPlane;
        var pointerPositionInWorldSpace = mainCamera.ScreenToWorldPoint(pointerPos);
        OnPointerPositionChange?.Invoke(pointerPositionInWorldSpace);
    }

    private void GetMovementInput()
    {
        OnMovementKeyPressed?.Invoke(
            new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")));
    }
}
