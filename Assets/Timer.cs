using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private double _startTime = Time.time;
    private Text _text;

    // Update is called once per frame
    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "You've survived for " + Math.Truncate(Time.time - _startTime) + " seconds";
    }
}
