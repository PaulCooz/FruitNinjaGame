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
        EventManager.OnSartGameEvent += SetStartData;
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
            TimeToNextPush = Config.TimeBetweenPacks;
            CurrentQuantity = Random.Range(2, Mathf.Min(QuantityOfPacks / Config.SlowdownOfComplexity, Config.MaxPack) + 1);
        }
        TimeToNextPush -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent -= SetStartData;
    }
}
