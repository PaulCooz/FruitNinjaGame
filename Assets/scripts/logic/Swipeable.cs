using System;
using UnityEngine;

public class Swipeable : MonoBehaviour
{
    private Vector2 PreviousPosition;

    public MainConfig Config;
    public FruitConfig FruitParameters;

    private void Update()
    {
        if (EventManager.isGameOver) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 CurrentMousePosition = View.ToWorldPoint(Input.mousePosition);
            float Speed = Vector2.Distance(CurrentMousePosition, PreviousPosition) / Time.deltaTime;
            float Radius = View.GetSpriteSize(gameObject.transform.localScale, FruitParameters.FruitImage).x / 2;

            bool near = Vector2.Distance(transform.position, CurrentMousePosition) <= Radius;
            bool fast = Speed >= Config.MinSpeed;

            if (near && fast)
            {
                gameObject.SendMessage("Cutted");
            }

            PreviousPosition = CurrentMousePosition;
        }
    }
}
