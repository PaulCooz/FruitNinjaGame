using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private float OverTime;

    [System.NonSerialized]
    public float MinY;
    [System.NonSerialized]
    public Vector2 Direction;
    [System.NonSerialized]
    public float LifeTime;

    public float Speed = 1;
    public MainConfig Config;

    private void Awake()
    {
        EventManager.OnBombExplosionEvent += BombExplosion;
    }

    private void Update()
    {
        float DeltaTime = Time.deltaTime * Config.TimeSpeed * Speed * SpeedUP();
        Vector3 Move = new Vector3(Direction.x, Direction.y + Config.Gravity * LifeTime, 0);

        transform.Translate(Move * DeltaTime, Space.World);
        LifeTime += DeltaTime;

        if (transform.position.y < MinY)
        {
            RemoveObject();
        }
    }

    private float SpeedUP()
    {
        if (EventManager.isGameOver)
        {
            OverTime += Time.deltaTime;
            return Mathf.Max(1, OverTime * Config.TimeSpeedIncrease);
        }
        else
        {
            OverTime = 0;
        }

        return 1;
    }

    public virtual void RemoveObject()
    {
        Destroy(gameObject);
    }

    private void BombExplosion(Vector2 BombPosition)
    {
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        if (CurrentPosition == BombPosition) return;

        Vector2 Difference = CurrentPosition - BombPosition;
        Vector2 Impulse = Difference / Difference.sqrMagnitude * Config.Force;

        Direction += Impulse * Config.BombMultiplier;
    }

    private void OnDestroy()
    {
        EventManager.OnBombExplosionEvent -= BombExplosion;
    }
}
