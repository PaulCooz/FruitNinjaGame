using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float MinY;
    public Vector2 Direction;
    public float LifeTime;

    public ConfigScript Config;

    private void Update()
    {
        float DeltaTime = Time.deltaTime * Config.TimeSpeed;
        Vector3 Move = new Vector3(Direction.x, Direction.y + Config.Gravity * LifeTime, 0);

        transform.Translate(Move * DeltaTime);
        LifeTime += DeltaTime;

        if (transform.position.y < MinY)
        {
            RemoveObject();
        }
    }

    public virtual void RemoveObject()
    {
        Destroy(gameObject);
    }
}
