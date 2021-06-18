using UnityEngine;

public class Pusher : MonoBehaviour
{
    public MainConfig Config;

    public void PushNewFruit(Transform transform)
    {
        FruitLogic NewFruit = Instantiate(RandomFruit(), RandomStartPosition(), Quaternion.identity);
        NewFruit.transform.SetParent(transform);
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
