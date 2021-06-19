using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static bool isGameOver;
    public static event Action OnGameOverEvent;
    public static event Action OnSartGameEvent;
    public static event Action<Vector2> OnBombExplosionEvent;
    public static event Action<HealthManager.HP> OnHealthChange;
    public static event Action<int> OnScoreChange;

    private void OnEnable()
    {
        isGameOver = false;
    }

    public static void Explosion(Vector2 Position)
    {
        OnBombExplosionEvent?.Invoke(Position);
    }

    public static void HealthChange(HealthManager.HP Change)
    {
        OnHealthChange?.Invoke(Change);
    }

    public static void ScoreChange(int Change)
    {
        OnScoreChange?.Invoke(Change);
    }

    public static void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        OnGameOverEvent?.Invoke();
    }
    
    public static void StartGame()
    {
        if (!isGameOver) return;

        isGameOver = false;
        OnSartGameEvent?.Invoke();
    }
}
