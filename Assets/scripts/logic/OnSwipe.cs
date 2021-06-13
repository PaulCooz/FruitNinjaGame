using UnityEngine;

public class OnSwipe : MonoBehaviour
{
    public ConfigScript Config;
    public int PointsForCut = 1;
    public Health.HP HeartOnSwipe = Health.HP.Nothing;

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

        Destroy(gameObject);
    }
}
