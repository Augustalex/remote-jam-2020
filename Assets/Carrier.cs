﻿using UnityEngine;
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

    private void OnTriggerStay(Collider other)
    {
        var carrier = other.GetComponentInParent<Carrier>();
        var chance = other.CompareTag("Player") || Random.value < .15f;
        if (carrier && carrier.Infected && chance)
        {
            Infected = true;
        }
    }
}