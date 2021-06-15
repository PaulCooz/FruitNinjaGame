using UnityEngine;

public class HalfLogic : FlyingObject
{
    public void SetMinY(float MinY)
    {
        this.MinY = MinY;
    }

    public void SetDirection(Vector2 Direction)
    {
        this.Direction = Direction;
    }

    public void SetLifeTime(float LifeTime)
    {
        this.LifeTime = LifeTime;
    }
}
