using UnityEngine;

public class MagnetLogic : FruitLogic
{
    public override void Cutted()
    {
        Instantiate(Fruit.Particles, transform.position, Quaternion.identity);

        EventManager.ScoreChange(Fruit.PointsForCut, transform.position);
        EventManager.HealthChange(Fruit.HeartOnSwipe);
        EventManager.Explosion(transform.position, false);

        Destroy(gameObject);
    }
}