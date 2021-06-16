using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public enum HP
    {
        Add, Remove, Nothing
    }

    public MainConfig Config;
    public Stack<GameObject> Hearts = new Stack<GameObject>();

    private void Start()
    {
        EventManager.OnSartGameEvent += AddHearts;
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
            Destroy(Hearts.Pop());
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
    }
}