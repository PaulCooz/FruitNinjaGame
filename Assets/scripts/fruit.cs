using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    Vector2 direction;
    float lifeTime;

    public float gravity = -1.0f;

    void Start()
    {
        direction = -transform.position / 1.5f;
        lifeTime = 0;
    }

    void Update()
    {
        Vector3 move = new Vector3(direction.x, direction.y + gravity * lifeTime, 0);
        transform.position += move * Time.deltaTime;

        lifeTime += Time.deltaTime;

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
