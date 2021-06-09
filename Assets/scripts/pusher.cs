using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pusher : MonoBehaviour
{
    public Vector4[] pushLines = new Vector4[0];
    public GameObject fruitToPush;
    float pushTime = 0;

    void Update()
    {
        pushTime -= Time.deltaTime;
        if (pushTime <= 0)
        {
            pushTime = 5;
            for (int i = 0; i < pushLines.Length; i++)
            {
                pushNewFruit(i);
            }
        }
    }

    void pushNewFruit(int indexOfLine)
    {
        Vector2 pushLineStart = new Vector2(pushLines[indexOfLine].x, pushLines[indexOfLine].y);
        Vector2 pushLineEnd = new Vector2(pushLines[indexOfLine].z, pushLines[indexOfLine].w);

        float ratio = Random.Range(0.0f, 1.0f);
        Vector2 startPosition = pushLineStart + ratio * (pushLineEnd - pushLineStart);

        Instantiate(fruitToPush, startPosition, Quaternion.identity);
    }
}
