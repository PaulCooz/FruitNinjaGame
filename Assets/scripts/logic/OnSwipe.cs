using UnityEngine;

public class OnSwipe : MonoBehaviour
{
    private Vector2 PreviousPosition;
    private float PreviousTime;

    public ConfigScript Config;
    public int PointsForCut;
    public Health.HP HeartOnSwipe;
    public bool HaveHalves;
    public GameObject Half0;
    public GameObject Half1;

    private void Update()
    {
        if (EventManager.isGameOver) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 CurrentMousePosition = View.ToWorldPoint(Input.mousePosition);
            float Speed = Vector2.Distance(CurrentMousePosition, PreviousPosition) / (Time.time - PreviousTime);
            float Radius = View.GetSpriteSize(gameObject).x / 2;

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

    private void CuttingFruit()
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

    private void MakeHalf(GameObject Half, float RatioX)
    {
        GameObject FirstHalf = Instantiate(Half, transform.position, Quaternion.identity);
        Fruit CurrentFruit = gameObject.GetComponent<Fruit>();
        Vector2 Direction = new Vector2(CurrentFruit.Direction.x * RatioX, 0);

        FirstHalf.GetComponent<Half>().MinY = CurrentFruit.MinY;
        FirstHalf.GetComponent<Half>().Direction = Direction;
        FirstHalf.GetComponent<Half>().LifeTime = CurrentFruit.LifeTime;
    }
}
