using UnityEngine;

public class DestroyOnSwipe : MonoBehaviour
{
    [Range(0, 10000)] public float MinSpeed = 0;

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

            if (Vector2.Distance(transform.position, CurrentMousePosition) <= Radius && Speed >= MinSpeed)
            {
                Destroy(gameObject);
            }

            PreviousPosition = CurrentMousePosition;
            PreviousTime = Time.time;
        }
    }
}
