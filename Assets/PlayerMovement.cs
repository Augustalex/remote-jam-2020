using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerMovement : MonoBehaviour
{
    private const float MovementSpeed = 26;
    private Vector2 _direction;

    [SerializeField] private InputAction movePlayer;
    
    void Awake()
    {
        movePlayer.performed += Move;
        movePlayer.canceled += _ => _direction = Vector2.zero;
    }

    private void OnEnable()
    {
        movePlayer.Enable();
    }

    private void OnDisable()
    {
        movePlayer.Disable();
    }

    private void FixedUpdate()
    {
        var rigidbody = GetComponentInChildren<Rigidbody>();
        var forceVector = new Vector3(_direction.x * MovementSpeed * Time.deltaTime, 0, _direction.y * MovementSpeed * Time.deltaTime);
        rigidbody.AddForce(forceVector, ForceMode.VelocityChange);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<Vector2>();
    }
}
