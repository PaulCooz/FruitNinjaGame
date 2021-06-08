using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pusher : MonoBehaviour
{
    public static Vector3 gravity = new Vector3(0, -1.0f, 0);

    public class fruit
    {
        public GameObject obj;
        public Vector3 direction;
        public float lifeTime;
        public float speed;

        public void move(float deltaTime)
        {
            obj.transform.position += (direction + gravity * lifeTime) * speed * deltaTime;
            lifeTime += deltaTime * speed;
        }

        public fruit(GameObject obj, Vector3 direction, float speed)
        {
            this.obj = obj;
            this.direction = direction;
            this.speed = speed;
            lifeTime = 0;
        }
    }
    public List<fruit> bucket = new List<fruit>();
    public Vector4[] pushLines = new Vector4[1];
    public GameObject fruitToPush;
    float pushTime = 0;

    void Update()
    {
        for(int i = 0; i < bucket.Count; i++)
        {
            bucket[i].move(Time.deltaTime);
        }

        pushTime -= Time.deltaTime;
        if (pushTime <= 0)
        {
            pushTime = 2;
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
        Vector3 direction = new Vector3(startPosition.y, -startPosition.x, 0);
        direction = 2 * direction.normalized;
        float speed = 2;

        fruit current = new fruit(Instantiate(fruitToPush, startPosition, Quaternion.identity), direction, speed);
        bucket.Add(current);
    }
}
