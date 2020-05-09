using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerOrder = 0;
    
    private const float MovementSpeed = 6;
    private PlayerInputActions _inputActions;
    private Vector2 _direction;
    void Awake()
    {
        Debug.Log("AWAKE!");
        _inputActions = new PlayerInputActions();
        _inputActions.Player.Movement.performed += Move;
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_direction.x * MovementSpeed * Time.deltaTime, 0, _direction.y * MovementSpeed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log("MOVE");
        _direction = ctx.ReadValue<Vector2>();
    }
}
