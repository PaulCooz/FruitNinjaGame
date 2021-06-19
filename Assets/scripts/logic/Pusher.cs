using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public MainConfig Config;
    public FruitLogic Heart;
    public HealthManager Health;
    public UiManager Ui;

    public void PushNewPack(Transform SpawnTransform, int Count)
    {
        Dictionary<int, int> InThisPack = new Dictionary<int, int>(Count);

        for (int i = 0; i < Count; i++)
        {
            int ToPush = RandomFruit();

            if (Config.FruitToPush[ToPush].Object == Heart && Health.Hearts.Count == Config.MaxHP)
            {
                continue;
            }

            if (!InThisPack.ContainsKey(ToPush)) InThisPack.Add(ToPush, 0);
            if (InThisPack[ToPush] < Config.FruitToPush[ToPush].Object.FruitParameters.MaxInPack)
            {
                StartCoroutine(InstantiateFruit(ToPush, SpawnTransform, i));
                InThisPack[ToPush]++;
            }
        }
    }

    IEnumerator InstantiateFruit(int Index, Transform SpawnTransform, int TimeMultiplier)
    {
        yield return new WaitForSeconds(Config.TimeBetweenFruit * TimeMultiplier);

        FruitLogic NewFruit = Instantiate(Config.FruitToPush[Index].Object, RandomStartPosition(), Quaternion.identity);
        NewFruit.transform.SetParent(SpawnTransform);
        NewFruit.Init(Ui);
     }

    private int RandomFruit()
    {
        return Config.FruitToPush.GetRandomIndex();
    }

    private Vector2 RandomStartPosition()
    {
        var RandomLine = Config.PushLine[Config.PushLine.GetRandomIndex()].Object;
        Vector2 PushLineStart = View.GetPosition(RandomLine.StartX, RandomLine.StartY);
        Vector2 PushLineEnd = View.GetPosition(RandomLine.EndX, RandomLine.EndY);
        float Ratio = Random.Range(0.0f, 1.0f);

        return PushLineStart + Ratio * (PushLineEnd - PushLineStart);
    }
}
