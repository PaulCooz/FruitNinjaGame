using UnityEngine;

public class Swipeable : MonoBehaviour
{
    private Vector2 PreviousPosition;

    public MainConfig Config;
    public FruitLogic Fruit;
    public CutLine LinePref;

    private void Update()
    {
        if (EventManager.isGameOver) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 CurrentMousePosition = View.ToWorldPoint(Input.mousePosition);
            float Speed = Vector2.Distance(CurrentMousePosition, PreviousPosition) / Time.deltaTime;
            float Radius = View.GetSpriteSize(gameObject.transform.localScale, Fruit.FruitParameters.FruitImage).x / 2;

            bool near = Vector2.Distance(transform.position, CurrentMousePosition) <= Radius;
            bool fast = Speed >= Config.MinSpeed;

            if (near && fast)
            {
                Fruit.Cutted();

                Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
                float Angle = AngleFromVector(CurrentMousePosition - CurrentPosition);
                Instantiate(LinePref, transform.position, Quaternion.identity).Init(Angle - 90);
            }

            PreviousPosition = CurrentMousePosition;
        }
    }

    private float AngleFromVector(Vector2 V)
    {
        return Mathf.Atan(V.y / V.x) * (180 / Mathf.PI);
    }
}
