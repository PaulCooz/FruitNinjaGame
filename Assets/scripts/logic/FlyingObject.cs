using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    [System.NonSerialized]
    public float MinY;
    [System.NonSerialized]
    public Vector2 Direction;
    [System.NonSerialized]
    public float LifeTime;

    public MainConfig Config;

    private void OnEnable()
    {
        EventManager.OnBombExplosionEvent += BombExplosion;
    }

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

    public void BombExplosion(Vector2 BombPosition)
    {
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 Impulse = (CurrentPosition - BombPosition).normalized * Config.Force * Config.BombMultiplier;

        Direction += Impulse;

    }

    private void OnDestroy()
    {
        EventManager.OnBombExplosionEvent -= BombExplosion;
    }
}
