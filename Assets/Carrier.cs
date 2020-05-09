using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Carrier : MonoBehaviour
{
    public bool Infected = false;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        if (Infected)
        {
           _renderer.materials[0].color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var carrier = other.GetComponentInParent<Carrier>();
        if (carrier && carrier.Infected)
        {
            Infected = true;
        }
    }
}
