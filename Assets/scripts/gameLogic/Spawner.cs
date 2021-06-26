using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float TimeToNextPush;
    private int CurrentQuantity;
    private int QuantityOfPacks;

    public MainConfig Config;
    public Pusher Gun;

    private void Awake()
    {
        EventManager.OnStartGameEvent += SetStartData;
    }

    private void Start()
    {
        SetStartData();
    }

    public void SetStartData()
    {
        TimeToNextPush = 2;
        CurrentQuantity = 1;
        QuantityOfPacks = 0;
    }

    private void Update()
    {
        if (EventManager.isGameOver) return;

        if (TimeToNextPush <= 0)
        {
            Gun.PushNewPack(transform, CurrentQuantity);
            QuantityOfPacks++;

            int CurrentComplexity = QuantityOfPacks / Config.SlowdownOfComplexity;

            TimeToNextPush = Config.TimeBetweenPacks / Mathf.Max(1, Mathf.Min(CurrentComplexity, Config.MaxDivisor));
            CurrentQuantity = Random.Range(2, Mathf.Min(CurrentComplexity, Config.MaxPack) + 1);
        }
        TimeToNextPush -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        EventManager.OnStartGameEvent -= SetStartData;
    }
}
