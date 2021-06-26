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
        EventManager.OnExplosionEvent += Explosion;
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

    private void Explosion(Vector2 Position, bool IsBomb)
    {
        Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
        if (CurrentPosition == Position) return;

        Vector2 Difference = (CurrentPosition - Position) * (IsBomb ? 1 : -1);
        Vector2 Impulse = Difference / Difference.sqrMagnitude * Config.Force;

        Direction += Impulse * Config.ExplosionMultiplier;
    }
    
    private void OnDestroy()
    {
        EventManager.OnExplosionEvent -= Explosion;
    }
}
