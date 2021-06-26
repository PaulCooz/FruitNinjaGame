using lib;
using UnityEngine;

public class FruitLogic : FlyingObject
{
    [System.NonSerialized]
    public FruitObject Fruit;

    public void Init(FruitObject Fruit)
    {
        this.Fruit = Fruit;
    }

    private void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenterByX, Config.DeviationFromCenterByX);
        Vector2 Mid = View.GetPosition(Config.MidX + DeviationByX, Config.MidY);
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        float Diameter = View.GetSpriteSize(gameObject.transform.localScale, Fruit.FruitSprite.sprite).y;

        LifeTime = 0;
        Direction = (Mid - startPosition).normalized * Config.Force;
        MinY = View.GetPosition(0, 0).y - Diameter;

        transform.position -= new Vector3(0, Diameter, 0);
    }

    public override void RemoveObject()
    {
        EventManager.HealthChange(Fruit.HeartOnFall);

        Destroy(gameObject);
    }

    public virtual void Cutted()
    {
        Instantiate(Fruit.Particles, transform.position, Quaternion.identity);

        EventManager.ScoreChange(Fruit.PointsForCut, transform.position);
        EventManager.HealthChange(Fruit.HeartOnSwipe);

        if (Fruit.HaveHalves)
        {
            MakeHalf(Fruit.Half0, Config.DeviationHalfByX);
            MakeHalf(Fruit.Half1, -Config.DeviationHalfByX);
        }

        Destroy(gameObject);
    }

    protected void MakeHalf(HalfLogic Half, float RatioX)
    {
        HalfLogic NewHalf = Instantiate(Half, transform.position, Quaternion.identity);
        NewHalf.Init(this.MinY, new Vector2(this.Direction.x * RatioX, 0), this.LifeTime);
    }
}
