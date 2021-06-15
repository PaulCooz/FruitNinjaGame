using UnityEngine;

public class Fruit : MonoBehaviour
{
    public ConfigScript Config;
    public Health.HP HeartOnFall = Health.HP.Remove;
    public Vector2 Direction;
    public float MinY;
    public float LifeTime;

    private void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenterByX, Config.DeviationFromCenterByX);
        Vector2 Mid = View.GetPosition(0.5f + DeviationByX, 0.6f);
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        float Diameter = View.GetSpriteSize(gameObject).y;

        LifeTime = 0;
        Direction = Mid - startPosition;
        MinY = View.GetPosition(0, 0).y - Diameter;

        transform.position -= new Vector3(0, Diameter, 0);
    }

    private void Update()
    {
        float DeltaTime = Time.deltaTime * Config.Speed;
        Vector3 Move = new Vector3(Direction.x, Direction.y + Config.Gravity * LifeTime, 0);

        transform.Translate(Move * DeltaTime);
        LifeTime += DeltaTime;

        if (transform.position.y < MinY)
        {
            RemoveFruit();
        }
    }

    private void RemoveFruit()
    {
        GameObject.Find("Hearts").transform.GetComponent<Health>().Check(HeartOnFall);

        Destroy(gameObject);
    }
}
