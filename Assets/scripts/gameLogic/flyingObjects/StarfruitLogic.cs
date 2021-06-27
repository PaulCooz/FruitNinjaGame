using UnityEngine;

public class StarfruitLogic : FruitLogic
{
    public override void Cutted()
    {
        Instantiate(Fruit.Particles, transform.position, Quaternion.identity);

        EventManager.ScoreChange(Fruit.PointsForCut, transform.position);
        EventManager.HealthChange(Fruit.HeartOnSwipe);
        EventManager.ScoreMultiplying();

        if (Fruit.HaveHalves)
        {
            MakeHalf(Fruit.Half0, Config.DeviationHalfByX);
            MakeHalf(Fruit.Half1, -Config.DeviationHalfByX);
        }

        Destroy(gameObject);
    }
}
