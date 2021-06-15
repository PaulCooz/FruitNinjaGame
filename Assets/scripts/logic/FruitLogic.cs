using UnityEngine;

public class FruitLogic : FlyingObject
{
    public Health.HP HeartOnFall = Health.HP.Remove;

    private void Start()
    {
        float DeviationByX = Random.Range(-Config.DeviationFromCenterByX, Config.DeviationFromCenterByX);
        Vector2 Mid = View.GetPosition(0.5f + DeviationByX, 0.6f);
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        float Diameter = View.GetSpriteSize(gameObject).y;

        LifeTime = 0;
        Direction = (Mid - startPosition).normalized * Config.Force;
        MinY = View.GetPosition(0, 0).y - Diameter;

        transform.position -= new Vector3(0, Diameter, 0);
    }

    public override void RemoveObject()
    {
        GameObject.Find("Hearts").transform.GetComponent<Health>().Check(HeartOnFall);

        Destroy(gameObject);
    }
}
