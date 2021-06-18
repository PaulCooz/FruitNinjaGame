using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float TimeToNextPush;
    private int CurrentQuantity;

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

                Gun.PushNewFruit(transform);
            }
            else
            {
                TimeToNextPush = Config.TimeBetweenPacks;
                CurrentQuantity = Random.Range(2, Config.MaxPack + 1);
            }
        }
        TimeToNextPush -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent += SetStartData;
    }
}
