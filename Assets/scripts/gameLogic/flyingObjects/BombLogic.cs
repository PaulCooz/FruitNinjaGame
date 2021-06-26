using UnityEngine;

public class BombLogic : FruitLogic
{
    public override void Cutted()
    {
        Instantiate(Fruit.Particles, transform.position, Quaternion.identity);

        EventManager.ScoreChange(Fruit.PointsForCut, transform.position);
        EventManager.HealthChange(Fruit.HeartOnSwipe);
        EventManager.Explosion(transform.position, true);

        Destroy(gameObject);
    }
}
