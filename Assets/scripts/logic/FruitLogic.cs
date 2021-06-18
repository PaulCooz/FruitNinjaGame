using UnityEngine;

public class FruitLogic : FlyingObject
{
    public FruitConfig FruitParameters;

    private void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenterByX, Config.DeviationFromCenterByX);
        Vector2 Mid = View.GetPosition(Config.MidX + DeviationByX, Config.MidY);
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        float Diameter = View.GetSpriteSize(gameObject.transform.localScale, FruitParameters.FruitImage).y;

        LifeTime = 0;
        Direction = (Mid - startPosition).normalized * Config.Force;
        MinY = View.GetPosition(0, 0).y - Diameter;

        transform.position -= new Vector3(0, Diameter, 0);
    }

    public override void RemoveObject()
    {
        EventManager.HealthChange(FruitParameters.HeartOnFall);

        Destroy(gameObject);
    }

    public void Cutted()
    {
        Instantiate(FruitParameters.Particles, transform.position, Quaternion.identity);

        EventManager.ScoreChange(FruitParameters.PointsForCut);
        EventManager.HealthChange(FruitParameters.HeartOnSwipe);

        if (FruitParameters.HaveHalves)
        {
            MakeHalf(FruitParameters.Half0, Config.DeviationHalfByX);
            MakeHalf(FruitParameters.Half1, -Config.DeviationHalfByX);
        }

        Destroy(gameObject);
    }

    private void MakeHalf(HalfLogic Half, float RatioX)
    {
        HalfLogic NewHalf = Instantiate(Half, transform.position, Quaternion.identity);
        NewHalf.Init(this.MinY, new Vector2(this.Direction.x * RatioX, 0), this.LifeTime);
    }
}
