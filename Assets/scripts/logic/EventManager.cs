using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static bool isGameOver;
    public static event Action OnGameOverEvent;
    public static event Action OnSartGameEvent;

    private void Awake()
    {
        isGameOver = false;
    }

    public static void GameOver()
    {
        isGameOver = true;

        OnGameOverEvent?.Invoke();
    }
    
    public static void StartGame()
    {
        isGameOver = false;

        OnSartGameEvent?.Invoke();
    }
}
