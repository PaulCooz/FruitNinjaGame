using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public MainConfig Config;
    public FruitLogic Heart;
    public HealthManager Health;

    public void PushNewPack(Transform SpawnTransform, int Count)
    {
        var InThisPack = new Dictionary<FruitLogic, int>(Count);

        for (int i = 0; i < Count; i++)
        {
            var ToPush = RandomFruit();

            if (ToPush.Fruit == Heart && Health.Hearts.Count == Config.MaxHP)
            {
                continue;
            }

            if (!InThisPack.ContainsKey(ToPush.Fruit)) InThisPack.Add(ToPush.Fruit, 0);
            if (InThisPack[ToPush.Fruit] < ToPush.MaxInPack)
            {
                StartCoroutine(InstantiateFruit(ToPush, SpawnTransform, i));
                InThisPack[ToPush.Fruit]++;
            }
        }
    }

    IEnumerator InstantiateFruit(FruitObject Object, Transform SpawnTransform, int TimeMultiplier)
    {
        yield return new WaitForSeconds(Config.TimeBetweenFruit * TimeMultiplier);

        var NewFruit = Instantiate(Object.Fruit, RandomStartPosition(), Quaternion.identity, SpawnTransform);
        NewFruit.Init(Object);
     }

    private FruitObject RandomFruit()
    {
        return Config.FruitToPush.GetRandomObject();
    }

    private Vector2 RandomStartPosition()
    {
        var RandomLine = Config.PushLine.GetRandomObject();
        Vector2 PushLineStart = View.GetPosition(RandomLine.StartX, RandomLine.StartY);
        Vector2 PushLineEnd = View.GetPosition(RandomLine.EndX, RandomLine.EndY);
        float Ratio = Random.Range(0.0f, 1.0f);

        return PushLineStart + Ratio * (PushLineEnd - PushLineStart);
    }
}
