using UnityEngine;

public class Animatable : MonoBehaviour
{
    private float RotateSpeed;
    private float ScaleSpeed;

    public MainConfig Config;

    private void Start()
    {
        RotateSpeed = Config.RotateSpeed;
        ScaleSpeed = Config.ScaleSpeed;

        if (ReverseWithChance(50))
        {
            RotateSpeed = -RotateSpeed;
        }
        if (ReverseWithChance(50))
        {
            ScaleSpeed = 1 / ScaleSpeed;
        }
    }

    private bool ReverseWithChance(int Chance)
    {
        return Random.Range(0, 100) + 1 <= Chance;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime, Space.World);
        transform.localScale += Vector3.one * ScaleSpeed * Time.deltaTime;
    }
}
