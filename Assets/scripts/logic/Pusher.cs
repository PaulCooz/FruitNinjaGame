using UnityEngine;

public class Pusher : MonoBehaviour
{
    private float TimeToNextPush;
    private int CurrentQuantity;

    public ConfigScript Config;

    private void Start()
    {
        TimeToNextPush = 1;
        CurrentQuantity = 1;
    }

    private void Update()
    {
        if (EventManager.isGameOver) return;

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

    private void PushNewFruit()
    {
        GameObject NewFruit = Instantiate(RandomFruit(), RandomStartPosition(), Quaternion.identity);
        NewFruit.transform.SetParent(transform);
    }

    private GameObject RandomFruit()
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

    private Vector2 RandomStartPosition()
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

        float StartX = Config.PushLine[RandomIndex].StartX;
        float StartY = Config.PushLine[RandomIndex].StartY;
        float EndX = Config.PushLine[RandomIndex].EndX;
        float EndY = Config.PushLine[RandomIndex].EndY;

        Vector2 PushLineStart = View.GetPosition(StartX, StartY);
        Vector2 PushLineEnd = View.GetPosition(EndX, EndY);
        float Ratio = Random.Range(0.0f, 1.0f);

        return PushLineStart + Ratio * (PushLineEnd - PushLineStart);
    }
}
