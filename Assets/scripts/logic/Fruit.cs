using UnityEngine;

public class Fruit : MonoBehaviour
{
    public ConfigScript Config;
    public Health.HP HeartOnFall = Health.HP.Remove;
    public Vector2 Bottom;
    public Vector2 Direction;
    public float LifeTime;
    public bool CanDelete;

    void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenter, Config.DeviationFromCenter);
        float DeviationByY = Random.Range(-Config.DeviationFromCenter, Config.DeviationFromCenter);
        Vector2 Mid = GetPosition(0.5f + DeviationByX, 0.5f + DeviationByY);
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);

        Direction = Mid - startPosition;
        Bottom = GetPosition(0, 0);
        LifeTime = 0;
        CanDelete = false;
    }

    void OnBecameVisible()
    {
        CanDelete = true;
    }

    void Update()
    {
        float DeltaTime = Time.deltaTime * Config.Speed;
        Vector3 Move = new Vector3(Direction.x, Direction.y + Config.Gravity * LifeTime, 0);

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

    Vector2 GetPosition(float x, float y)
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(x, y));
    }
}
