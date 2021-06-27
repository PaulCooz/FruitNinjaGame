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
    private static float MaxScoreMultiplyTime;
    private static float ScoreMultiplyTime;
    private static int ScoreMultiply;
    
    public static bool isGameOver;
    public static event Action OnGameOverEvent;
    public static event Action OnStartGameEvent;
    public static event Action OnScoreMultiplyEvent;
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
        MaxScoreMultiplyTime = Config.MaxScoreMultiplyTime;
        ScoreMultiply = Config.ScoreMultiply;
    }

    private void Update()
    {
        if (FreezeTime > 0)
        {
            FreezeTime -= Time.deltaTime;    
        }
        if (ScoreMultiplyTime > 0)
        {
            ScoreMultiplyTime -= Time.deltaTime;
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

    public static void ScoreMultiplying()
    {
        OnScoreMultiplyEvent?.Invoke();
        ScoreMultiplyTime = MaxScoreMultiplyTime;
    }

    public static void HealthChange(HealthManager.HP Change)
    {
        OnHealthChange?.Invoke(Change);
    }

    public static void ScoreChange(int Change, Vector2 InPosition)
    {
        if (ScoreMultiplyTime > 0)
        {
            Change *= ScoreMultiply;
        }
        
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

    public static bool IsScoreMultiplying()
    {
        return ScoreMultiplyTime > 0;
    }
    
    public static void StartGame()
    {
        if (!isGameOver) return;

        isGameOver = false;
        OnStartGameEvent?.Invoke();
    }
}
