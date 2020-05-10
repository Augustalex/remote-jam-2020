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
    [SerializeField] private InputAction jump;

    private bool _jumping;
    private bool _jumped;
    private float _timeInAir;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        movePlayer.performed += Move;
        movePlayer.canceled += _ => _direction = Vector2.zero;

        jump.performed += _ => Jump();
    }

    private void OnEnable()
    {
        movePlayer.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        movePlayer.Disable();
        jump.Disable();
    }

    private void FixedUpdate()
    {
        if (_jumping)
        {
            if (_jumped)
            {
                _timeInAir += Time.deltaTime;
                if (_timeInAir > 1f)
                {
                    // GroundRigidbody();
                    _timeInAir = 0;
                    _jumping = false;
                    _jumped = false;
                }
            }
            else
            {
                _jumped = true;
                _rigidbody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
            }
        }
        else
        {
            var forceVector = new Vector3(_direction.x * MovementSpeed * Time.deltaTime, 0,
                _direction.y * MovementSpeed * Time.deltaTime);
            _rigidbody.AddForce(forceVector, ForceMode.VelocityChange);

        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<Vector2>();
    }

    public void Jump()
    {
        Debug.Log("JUMP!");
        FreeLateralMovement(); 
        _jumping = true;
    }

    private void GroundRigidbody()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY 
                                 | RigidbodyConstraints.FreezeRotation;
        
        var position = transform.position;
        transform.position = new Vector3(position.x, 0, position.z);
    }
    
    private void FreeLateralMovement()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}