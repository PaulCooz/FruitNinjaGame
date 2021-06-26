using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static float TimeFromStart;
    private static float PreviousCutTime;
    private static int Combo;
    private static int MaxCombo;
    private static float MinComboTime;
    [System.NonSerialized]
    public static float FreezeTime;
    private static float MaxFreezeTime;
    
    public static bool isGameOver;
    public static event Action OnGameOverEvent;
    public static event Action OnStartGameEvent;
    public static event Action<Vector2, bool> OnExplosionEvent;
    public static event Action<HealthManager.HP> OnHealthChange;
    public static event Action<int, Vector2> OnScoreChange;

    public MainConfig Config;
    
    private void OnEnable()
    {
        isGameOver = false;
        TimeFromStart = 0;
        Combo = 2;
        MinComboTime = Config.MinComboTime;
        PreviousCutTime = -MinComboTime;
        FreezeTime = 0.0f;
        MaxCombo = Config.MaxCombo;
        MaxFreezeTime = Config.MaxFreezeTime;
    }

    private void Update()
    {
        if (FreezeTime > 0)
        {
            FreezeTime -= Time.deltaTime;    
        }
        TimeFromStart += Time.deltaTime;
    }

    public static void Explosion(Vector2 Position, bool IsBomb)
    {
        OnExplosionEvent?.Invoke(Position, IsBomb);
    }

    public static void Freezing()
    {
        FreezeTime = MaxFreezeTime;
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
        OnStartGameEvent?.Invoke();
    }
}
