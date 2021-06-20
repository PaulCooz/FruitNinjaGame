using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static float TimeFromStart;
    private static float PreviousCutTime;
    private static int Combo;

    public static bool isGameOver;
    public static event Action OnGameOverEvent;
    public static event Action OnSartGameEvent;
    public static event Action<Vector2> OnBombExplosionEvent;
    public static event Action<HealthManager.HP> OnHealthChange;
    public static event Action<int, Vector2> OnScoreChange;

    public static float MinComboTime = 0.5f;
    public static int MaxCombo = 5;

    private void OnEnable()
    {
        isGameOver = false;
        TimeFromStart = 0;
        Combo = 2;
        PreviousCutTime = -MinComboTime;
    }

    public static void Explosion(Vector2 Position)
    {
        OnBombExplosionEvent?.Invoke(Position);
    }

    public static void HealthChange(HealthManager.HP Change)
    {
        OnHealthChange?.Invoke(Change);
    }

    public static void ScoreChange(int Change, Vector2 InPosition)
    {
        if (TimeFromStart - PreviousCutTime < MinComboTime)
        {
            Change *= Combo;
            Combo = Mathf.Min(Combo + 1, MaxCombo);
        }
        else
        {
            Combo = 2;
        }
        PreviousCutTime = TimeFromStart;

        OnScoreChange?.Invoke(Change, InPosition);
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

    private void Update()
    {
        TimeFromStart += Time.deltaTime;
    }
}
