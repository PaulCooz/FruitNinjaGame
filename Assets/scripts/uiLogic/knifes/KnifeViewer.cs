using UnityEngine;

public class KnifeViewer : MonoBehaviour
{
    public LineRenderer LineRendererField;

    public void Init(Vector2 FirstPosition, Vector2 SecondPosition)
    {
        LineRendererField.SetPosition(0, FirstPosition);
        LineRendererField.SetPosition(1, SecondPosition);
    }
}
