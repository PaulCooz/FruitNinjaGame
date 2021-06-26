using UnityEngine;

public class CanvasForText : MonoBehaviour
{
    public CutText text;
    public float DestroyTime;

    public void Init(int ToPrint)
    {
        text.Init(ToPrint);
        
        Destroy(gameObject, DestroyTime);
    }
}