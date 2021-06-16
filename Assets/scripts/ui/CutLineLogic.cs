using UnityEngine;

public class CutLineLogic : MonoBehaviour
{
    public LineRenderer LineRendererField;

    public void SetFirstPosition(Vector2 Dot)
    {
        LineRendererField.SetPosition(0, Dot);
    }
    
    public void SetSecondPosition(Vector2 Dot)
    {
        LineRendererField.SetPosition(1, Dot);
    }
}
