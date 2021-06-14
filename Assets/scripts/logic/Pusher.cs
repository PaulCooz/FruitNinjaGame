using UnityEngine;

public class Pusher : MonoBehaviour
{
    public ConfigScript Config;

    private float TimeToNextPush;
    private int CurrentQuantity;

    private void Start()
    {
        TimeToNextPush = 0;
        CurrentQuantity = 1;
    }

    void Update()
    {
        if (TimeToNextPush <= 0)
        {
            if (CurrentQuantity > 0)
            {
                TimeToNextPush = Config.TimeBetweenFruit;
                CurrentQuantity--;

                PushNewFruit();
            }
            else
            {
                TimeToNextPush = Config.TimeBetweenPacks;
                CurrentQuantity = Random.Range(2, Config.MaxPack + 1);
            }
        }
        TimeToNextPush -= Time.deltaTime;
    }

    void PushNewFruit()
    {
        GameObject NewFruit = Instantiate(RandomFruit(), RandomStartPosition(), Quaternion.identity);
        NewFruit.transform.SetParent(transform);
    }

    GameObject RandomFruit()
    {
        int SumOfChanges = 0;
        for (int i = 0; i < Config.FruitToPush.Length; i++)
        {
            SumOfChanges += Config.FruitToPush[i].Chance;
        }

        int CurrentChance = Random.Range(1, SumOfChanges + 1);
        int RandomIndex = 0;
        for (int i = 0; i < Config.FruitToPush.Length; i++)
        {
            CurrentChance -= Config.FruitToPush[i].Chance;

            if (CurrentChance <= 0)
            {
                RandomIndex = i;
                break;
            }
        }

        return Config.FruitToPush[RandomIndex].PushingObject;
    }

    Vector2 RandomStartPosition()
    {
        int SumOfChanges = 0;
        for (int i = 0; i < Config.PushLine.Length; i++)
        {
            SumOfChanges += Config.PushLine[i].Chance;
        }

        int CurrentChance = Random.Range(1, SumOfChanges + 1);
        int RandomIndex = 0;
        for (int i = 0; i < Config.PushLine.Length; i++)
        {
            CurrentChance -= Config.PushLine[i].Chance;

            if (CurrentChance <= 0)
            {
                RandomIndex = i;
                break;
            }
        }

        Vector2 PushLineStart = GetPosition(Config.PushLine[RandomIndex].StartX, Config.PushLine[RandomIndex].StartY);
        Vector2 PushLineEnd = GetPosition(Config.PushLine[RandomIndex].EndX, Config.PushLine[RandomIndex].EndY);
        float Ratio = Random.Range(0.0f, 1.0f);

        return PushLineStart + Ratio * (PushLineEnd - PushLineStart);
    }

    Vector2 GetPosition(float x, float y)
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(x, y));
    }
}
