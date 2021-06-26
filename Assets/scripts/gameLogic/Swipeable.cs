using UnityEngine;

public class Swipeable : MonoBehaviour
{
    private Vector2 PreviousPosition;

    public MainConfig Config;
    public FruitLogic ThisFruit;

    private void Update()
    {
        if (EventManager.isGameOver) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 CurrentMousePosition = View.ToWorldPoint(Input.mousePosition);
            float Speed = Vector2.Distance(CurrentMousePosition, PreviousPosition) / Time.deltaTime;
            float Radius = View.GetSpriteSize(gameObject.transform.localScale, ThisFruit.Fruit.FruitSprite.sprite).x / 2;

            bool near = Vector2.Distance(transform.position, CurrentMousePosition) <= Radius;
            bool fast = Speed >= Config.MinSpeed;

            if (near && fast)
            {
                ThisFruit.Cutted();

                MakeCutLine(CurrentMousePosition);
            }

            PreviousPosition = CurrentMousePosition;
        }
    }

    private void MakeCutLine(Vector2 CurrentMousePosition)
    {
        Vector2 CurrentPosition = transform.position;
        float Angle = AngleFromVector(CurrentMousePosition - CurrentPosition);

        Instantiate(Config.cutLine, transform.position, Quaternion.identity).Init(Angle);
    }
        
    private float AngleFromVector(Vector2 V)
    {
        return Mathf.Atan(V.y / V.x) * (180 / Mathf.PI);
    }
}
