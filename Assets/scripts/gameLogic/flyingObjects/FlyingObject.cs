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

    [SerializeField]
    private float Speed = 1;
    public MainConfig Config;

    private void Awake()
    {
        EventManager.OnExplosionEvent += Explosion;

        OverTime = 0;
    }

    private void Update()
    {
        float DeltaTime = Time.deltaTime * Config.SpeedOfTime * Speed * EventSpeed();
        Vector3 Move = new Vector3(Direction.x, Direction.y + Config.Gravity * LifeTime, 0);

        transform.Translate(Move * DeltaTime, Space.World);
        LifeTime += DeltaTime;

        if (transform.position.y < MinY)
        {
            RemoveObject();
        }
    }

    private float EventSpeed()
    {
        float Result = 1.0f;
        
        if (EventManager.FreezeTime > 0)
        {
            Result *= Mathf.Max(1.0f / Config.FreezeMultiplier,  Config.MaxFreezeTime / (Config.MaxFreezeTime + EventManager.FreezeTime));
        }
        
        if (EventManager.isGameOver)
        {
            OverTime += Time.deltaTime;
            Result *= Mathf.Max(1, OverTime * Config.TimeSpeedIncrease);
        }
        else
        {
            OverTime = 0;
        }

        return Result;
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
        Vector2 Impulse = Difference * Config.ExplosionMultiplier / Difference.sqrMagnitude;

        if (Impulse.magnitude > Config.Force) Impulse = Impulse.normalized * Config.Force;

        Direction += Impulse;
    }

    private void OnDestroy()
    {
        EventManager.OnExplosionEvent -= Explosion;
    }
}
