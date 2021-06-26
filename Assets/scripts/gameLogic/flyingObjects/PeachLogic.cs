using UnityEngine;

public class PeachLogic : FruitLogic
{
    public override void Cutted()
    {
        Instantiate(Fruit.Particles, transform.position, Quaternion.identity);

        EventManager.ScoreChange(Fruit.PointsForCut, transform.position);
        EventManager.HealthChange(Fruit.HeartOnSwipe);
        EventManager.Freezing();

        if (Fruit.HaveHalves)
        {
            MakeHalf(Fruit.Half0, Config.DeviationHalfByX);
            MakeHalf(Fruit.Half1, -Config.DeviationHalfByX);
        }

        Destroy(gameObject);
    }
}