using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float Gravity = -100.0f;
    private Vector2 Mid;
    private Vector2 Bottom;
    private Vector2 Direction;
    private float LifeTime;
    private bool CanDelete;

    void Start()
    {
        Mid = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        Bottom = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        Direction = Mid - startPosition;

        LifeTime = 0;

        CanDelete = false;
    }
    void OnBecameInvisible()
    {
        CanDelete = true;
    }

    void Update()
    {
        Vector3 move = new Vector3(Direction.x, Direction.y + Gravity * LifeTime, 0);
        transform.Translate(move * Time.deltaTime);
        LifeTime += Time.deltaTime;

        if (transform.position.y < Bottom.y && CanDelete)
        {
            Destroy(gameObject);
        }
    }
}
