using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Health.HP HeartOnFall = Health.HP.Remove;
    public float Gravity = -100.0f;
    public float Speed = 2;

    private Vector2 Bottom;
    private Vector2 Direction;
    private float LifeTime;
    private bool CanDelete;

    void Start()
    {
        Vector2 Mid = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        Bottom = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        Direction = Mid - startPosition;

        LifeTime = 0;

        CanDelete = false;
    }

    void OnBecameVisible()
    {
        CanDelete = true;
    }

    void Update()
    {
        float DeltaTime = Time.deltaTime * Speed;
        Vector3 Move = new Vector3(Direction.x, Direction.y + Gravity * LifeTime, 0);

        transform.Translate(Move * DeltaTime);
        LifeTime += DeltaTime;

        if (transform.position.y < Bottom.y && CanDelete)
        {
            RemoveFruit();
        }
    }

    void RemoveFruit()
    {
        GameObject.Find("Hearts").transform.GetComponent<Health>().Check(HeartOnFall);

        Destroy(gameObject);
    }
}
