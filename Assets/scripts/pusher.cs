using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public GameObject FruitToPush;
    public float SpawnLengthInProcent;
    private Vector2 PushLineStart;
    private Vector2 PushLineEnd;
    private float PushTime = 0;

    private void Start()
    {
        PushLineStart = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        PushLineEnd = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
    }

    void Update()
    {
        PushTime -= Time.deltaTime;
        if (PushTime <= 0)
        {
            PushTime = 5;
            PushNewFruit();
        }
    }

    void PushNewFruit()
    {
        float ReduceZone = ((100 - SpawnLengthInProcent) / 2) / 100;
        float ratio = Random.Range(0 + ReduceZone, 1 - ReduceZone);

        Vector2 startPosition = PushLineStart + ratio * (PushLineEnd - PushLineStart);

        Instantiate(FruitToPush, startPosition, Quaternion.identity);
    }
}
