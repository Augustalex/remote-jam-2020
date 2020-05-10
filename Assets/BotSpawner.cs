using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class BotSpawner : MonoBehaviour
{
    public GameObject BotTemplate;
    private GameConfig _gameConfig;
    private int _spawnCount = 0;

    async void Awake()
    {
        _gameConfig = GameObject.FindGameObjectWithTag("GameConfig").GetComponent<GameConfig>();

        Invoke("Spawn", NextDelay());
    }

    private void Spawn()
    {
        Instantiate(BotTemplate, transform.position, transform.rotation);
        _spawnCount++;
        if (_spawnCount <= _gameConfig.difficultyLevel)
        {
            Invoke("Spawn", NextDelay());
        }
    }

    public float NextDelay()
    {
        return Random.value * 5f;
    } 
}