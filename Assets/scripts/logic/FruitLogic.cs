using UnityEngine;

public class FruitLogic : FlyingObject
{
    [System.NonSerialized]
    public Health HealthManager;
    private CurrentScoreText TextUpdater;
    private const float MidX = 0.5f;
    private const float MidY = 0.6f;

    public FruitConfig FruitParameters;

    public void Init(Health HealthManager, CurrentScoreText TextUpdater)
    {
        this.HealthManager = HealthManager;
        this.TextUpdater = TextUpdater;
    }

    private void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenterByX, Config.DeviationFromCenterByX);
        Vector2 Mid = View.GetPosition(MidX + DeviationByX, MidY);
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        float Diameter = View.GetSpriteSize(gameObject.transform.localScale, FruitParameters.FruitImage).y;

        LifeTime = 0;
        Direction = (Mid - startPosition).normalized * Config.Force;
        MinY = View.GetPosition(0, 0).y - Diameter;

        transform.position -= new Vector3(0, Diameter, 0);
    }

    public override void RemoveObject()
    {
        HealthManager.Check(FruitParameters.HeartOnFall);

        Destroy(gameObject);
    }

    public void Cutted()
    {
        Instantiate(FruitParameters.Particles, transform.position, Quaternion.identity);

        TextUpdater.Score += FruitParameters.PointsForCut;
        HealthManager.Check(FruitParameters.HeartOnSwipe);

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
