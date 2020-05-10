using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class BotSpawner : MonoBehaviour
{
    public GameObject BotTemplate;
    private GameConfig _gameConfig;


    // Start is called before the first frame update
    void Awake()
    {
        _gameConfig = GameObject.FindGameObjectWithTag("GameConfig").GetComponent<GameConfig>();

        for (var i = 0; i < _gameConfig.difficultyLevel; i++)
        {
            Instantiate(BotTemplate, transform.position, transform.rotation);
        }
    }
}
