using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static bool isGameOver;
    public static event Action OnGameOverEvent;
    public static event Action OnSartGameEvent;
    public static event Action<Vector2> OnBombExplosionEvent;

    private void Start()
    {
        isGameOver = false;
    }

    public static void Explosion(Vector2 Position)
    {
        OnBombExplosionEvent?.Invoke(Position);
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
