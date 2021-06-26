using UnityEngine;

public class View : MonoBehaviour
{
    public static Vector2 GetSpriteSize(Vector3 Scale, Sprite Image)
    {
        float ByX = Scale.x / Image.pixelsPerUnit * Image.textureRect.size.x;
        float ByY = Scale.y / Image.pixelsPerUnit * Image.textureRect.size.y;

        return new Vector2(ByX, ByY);
    }

    public static Vector2 GetPosition(float x, float y)
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(x, y));
    }

    public static Vector2 ToWorldPoint(Vector2 Position)
    {
        return Camera.main.ScreenToWorldPoint(Position);
    }
}
