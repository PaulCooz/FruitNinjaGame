using UnityEngine;

public class Half : MonoBehaviour
{
    public ConfigScript Config;
    [System.NonSerialized]
    public float MinY;
    [System.NonSerialized]
    public Vector2 Direction;
    [System.NonSerialized]
    public float LifeTime;

    void Update()
    {
        float DeltaTime = Time.deltaTime * Config.HalfSpeed;
        Vector3 Move = new Vector3(Direction.x, Direction.y + Config.Gravity * LifeTime, 0);

        transform.Translate(Move * DeltaTime);
        LifeTime += DeltaTime;

        if (transform.position.y < MinY)
        {
            Destroy(gameObject);
        }
    }
}
