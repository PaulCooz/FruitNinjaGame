using UnityEngine;

public class Animatable : MonoBehaviour
{
    private float RotateAngle;
    private float Rescale;

    void Update()
    {
        transform.Rotate(Vector3.forward / 1f, Space.World);
    }
}
