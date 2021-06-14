using UnityEngine;

public class OnSwipe : MonoBehaviour
{
    public ConfigScript Config;
    public int PointsForCut;
    public Health.HP HeartOnSwipe;
    public bool HaveHalves;
    public GameObject Half0;
    public GameObject Half1;

    private Vector2 PreviousPosition;
    private float PreviousTime;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Sprite FruitSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            float Radius = transform.localScale.x / FruitSprite.pixelsPerUnit * FruitSprite.textureRect.size.x / 2;

            Vector2 CurrentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float Speed = Vector2.Distance(CurrentMousePosition, PreviousPosition) / (Time.time - PreviousTime);

            bool near = Vector2.Distance(transform.position, CurrentMousePosition) <= Radius;
            bool fast = Speed >= Config.MinSpeed;

            if (near && fast)
            {
                CuttingFruit();
            }

            PreviousPosition = CurrentMousePosition;
            PreviousTime = Time.time;
        }
    }

    void CuttingFruit()
    {
        GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += PointsForCut;
        GameObject.Find("Hearts").transform.GetComponent<Health>().Check(HeartOnSwipe);

        if (HaveHalves)
        {
            MakeHalf(Half0, Config.DeviationHalfByX);
            MakeHalf(Half1, -Config.DeviationHalfByX);
        }

        Destroy(gameObject);
    }

    void MakeHalf(GameObject Half, float RatioX)
    {
        GameObject FirstHalf = Instantiate(Half, transform.position, Quaternion.identity);
        Fruit CurrentFruit = gameObject.GetComponent<Fruit>();
        Vector2 Direction = new Vector2(CurrentFruit.Direction.x * RatioX, 0);

        FirstHalf.GetComponent<Half>().Bottom = CurrentFruit.Bottom;
        FirstHalf.GetComponent<Half>().Direction = Direction;
        FirstHalf.GetComponent<Half>().LifeTime = CurrentFruit.LifeTime;
    }
}
