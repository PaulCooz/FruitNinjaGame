using UnityEngine;

public class Pusher : MonoBehaviour
{
    private float TimeToNextPush;
    private int CurrentQuantity;

    public MainConfig Config;
    public Health HealthManager;
    public CurrentScoreText TextUpdater;

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
        FruitLogic NewFruit = Instantiate(RandomFruit(), RandomStartPosition(), Quaternion.identity);

        NewFruit.transform.SetParent(transform);
        NewFruit.Init(HealthManager, TextUpdater);
    }

    private FruitLogic RandomFruit()
    { 
        return Config.FruitToPush.GetRandomData();
    }

    private Vector2 RandomStartPosition()
    {
        var RandomLine = Config.PushLine.GetRandomData();
        Vector2 PushLineStart = View.GetPosition(RandomLine.StartX, RandomLine.StartY);
        Vector2 PushLineEnd = View.GetPosition(RandomLine.EndX, RandomLine.EndY);
        float Ratio = Random.Range(0.0f, 1.0f);

        return PushLineStart + Ratio * (PushLineEnd - PushLineStart);
    }
}
