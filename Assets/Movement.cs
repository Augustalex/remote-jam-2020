using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    void Awake()
    {
Debug.Log("AWAKE!");
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log("HERERERE");
        var motion = ctx.ReadValue<Vector2>();
        Debug.Log(motion);
        transform.position += new Vector3(motion.x, 0, motion.y);
    }
}
