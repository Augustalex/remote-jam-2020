using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class TryAgainButton : MonoBehaviour
{
    private static readonly Vector2 HiddenPosition = new Vector2(-9999f, -9999f);
    private Vector2 _originalPosition;

    void Awake()
    {
        _originalPosition = transform.position;
        transform.position = HiddenPosition;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Hide()
    {
        transform.position = HiddenPosition;
    }
    
    public void Show()
    {
        transform.position = _originalPosition;
    }
}
