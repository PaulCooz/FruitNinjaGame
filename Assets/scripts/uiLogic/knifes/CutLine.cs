using UnityEngine;

public class CutLine : MonoBehaviour
{
    public void Init(float Angle)
    {
        gameObject.transform.Rotate(new Vector3(0, 0, Angle));
    }

    public void DestroyLine()
    {
        Destroy(gameObject);
    }
}
