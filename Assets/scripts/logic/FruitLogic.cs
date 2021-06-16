using UnityEngine;

public class FruitLogic : FlyingObject
{
    private Health HealthManager;
    private CurrentScoreText TextUpdater;

    public FruitConfig FruitParameters;

    public void SetHealthManager(Health HealthManager)
    {
        this.HealthManager = HealthManager;
    }
    
    public void SetTextUpdater(CurrentScoreText TextUpdater)
    {
        this.TextUpdater = TextUpdater;
    }

    private void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenterByX, Config.DeviationFromCenterByX);
        Vector2 Mid = View.GetPosition(0.5f + DeviationByX, 0.6f);
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
        TextUpdater.Score += FruitParameters.PointsForCut;
        HealthManager.Check(FruitParameters.HeartOnSwipe);

        if (FruitParameters.HaveHalves)
        {
            MakeHalf(FruitParameters.Half0, Config.DeviationHalfByX);
            MakeHalf(FruitParameters.Half1, -Config.DeviationHalfByX);
        }

        Destroy(gameObject);
    }

    private void MakeHalf(GameObject Half, float RatioX)
    {
        GameObject NewHalf = Instantiate(Half, transform.position, Quaternion.identity);
        Vector2 Direction = new Vector2(this.Direction.x * RatioX, 0);

        NewHalf.SendMessage("SetDirection", Direction);
        NewHalf.SendMessage("SetMinY", this.MinY);
        NewHalf.SendMessage("SetLifeTime", this.LifeTime);
    }
}
