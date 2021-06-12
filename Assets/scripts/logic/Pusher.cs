using UnityEngine;

public class Pusher : MonoBehaviour
{
    public GameObject[] FruitToPush = new GameObject[0];
    [Range(0, 100)]
    public float SpawnLengthInProcent;

    private Vector2 PushLineStart;
    private Vector2 PushLineEnd;
    private float PushTime;
    private int CurrentQuantity;

    private void Start()
    {
        PushLineStart = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        PushLineEnd = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));

        PushTime = 0;
        CurrentQuantity = 1;
    }

    void Update()
    {
        if (PushTime <= 0)
        {
            if (CurrentQuantity > 0)
            {
                PushTime = Random.Range(0.3f, 0.5f);
                CurrentQuantity--;

                PushNewFruit();
            }
            else
            {
                PushTime = Random.Range(2.0f, 4.0f);
                CurrentQuantity = Random.Range(2, 5);
            }
        }
        PushTime -= Time.deltaTime;
    }

    void PushNewFruit()
    {
        float ReduceZone = (100 - SpawnLengthInProcent) / 2 / 100;
        float Ratio = Random.Range(0 + ReduceZone, 1 - ReduceZone);
        Vector2 StartPosition = PushLineStart + Ratio * (PushLineEnd - PushLineStart);

        GameObject NewFruit = Instantiate(FruitToPush[RandomFruit()], StartPosition, Quaternion.identity);
        NewFruit.transform.SetParent(transform);
    }

    int RandomFruit()
    {
        int RandomIndex = Random.Range(0, FruitToPush.Length);

        print("Push " + FruitToPush[RandomIndex].name);

        return RandomIndex;
    }
}
