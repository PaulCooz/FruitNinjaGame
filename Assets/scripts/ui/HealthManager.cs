using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public enum HP
    {
        Add, Remove, Nothing
    }

    public MainConfig Config;
    public Stack<HeartViewer> Hearts = new Stack<HeartViewer>();

    private void Awake()
    {
        EventManager.OnSartGameEvent += AddHearts;
        EventManager.OnHealthChange += Check;
    }

    private void OnEnable()
    {
        AddHearts();
    }

    public void AddHearts()
    {
        for (int i = 0; i < Config.StartHP; i++)
        {
            AddHeart();
        }
    }

    public void AddHeart()
    {
        if (Hearts.Count >= Config.MaxHP || EventManager.isGameOver) return;

        Hearts.Push(Instantiate(Config.HeartPref, transform));
    }

    public void RemoveHeart()
    {
        if (Hearts.Count > 0)
        {
            Hearts.Pop().PopHeart();
        }

        if (Hearts.Count <= 0)
        {
            EventManager.GameOver();
        }
    }

    public void Check(HP Heart)
    {
        switch(Heart)
        {
        case HP.Add:
            AddHeart();
            break;

        case HP.Remove:
            RemoveHeart();
            break;
        }
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent -= AddHearts;
        EventManager.OnHealthChange -= Check;
    }
}