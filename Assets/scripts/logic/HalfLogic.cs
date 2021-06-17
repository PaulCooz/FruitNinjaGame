using UnityEngine;

public class HalfLogic : FlyingObject
{
    public void Init(float MinY, Vector2 Direction, float LifeTime)
    {
        this.MinY = MinY;
        this.Direction = Direction;
        this.LifeTime = LifeTime;
    }
}
