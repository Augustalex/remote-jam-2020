using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private double _time = 0;
    private Text _text;

    // Update is called once per frame
    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        var gameOverWatcher = GameObject.FindGameObjectWithTag("GameOverWatcher").GetComponent<GameOverTextEditor>();
        if (gameOverWatcher.GameIsOver())
        {
            _text.text = "You survived for " + Math.Truncate(_time) + " seconds";
        }
        else
        {
            _time += Time.deltaTime;
            _text.text = "You've survived for " + Math.Truncate(_time) + " seconds";
        }
    }
}