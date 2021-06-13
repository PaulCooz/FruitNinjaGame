using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public enum HP
    {
        Add, Remove, Nothing
    }

    public ConfigScript Config;
    public GameObject Popup;
    public Stack<GameObject> Hearts = new Stack<GameObject>();

    private void Start()
    {
        for (int i = 0; i < Config.StartHP; i++)
        {
            AddHeart();
        }
    }

    public void AddHeart()
    {
        if (Hearts.Count >= Config.MaxHP) return;

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
            Popup.SetActive(true);
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
