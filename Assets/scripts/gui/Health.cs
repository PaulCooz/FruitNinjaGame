using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public enum HP
    {
        Add, Remove, Nothing
    }

    public GameObject HeartPref;
    public int MaxHP = 5;
    public int StartHP = 3;
    public Stack<GameObject> Hearts = new Stack<GameObject>();

    private void Start()
    {
        for (int i = 0; i < StartHP; i++)
        {
            AddHeart();
        }
    }

    public void AddHeart()
    {
        if (Hearts.Count >= MaxHP) return;

        Hearts.Push(Instantiate(HeartPref, transform));
    }

    public void RemoveHeart()
    {
        if (Hearts.Count <= 0)
        {
            print("game over!");
        }
        else
        {
            Destroy(Hearts.Pop());
        }
    }

    public void Check(HP Heart)
    {
        if (Heart == HP.Add)
        {
            AddHeart();
        }
        else if (Heart == HP.Remove)
        {
            RemoveHeart();
        }
    }
}
