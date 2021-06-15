using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static bool isGameOver;
    public delegate void Do();
    public static event Do OnGameOverEvent;
    public static event Do OnSartGameEvent;

    private void Awake()
    {
        isGameOver = false;
    }

    public static void GameOver()
    {
        isGameOver = true;

        OnGameOverEvent();
    }
    
    public static void StartGame()
    {
        isGameOver = false;

        OnSartGameEvent();
    }
}
