using UnityEngine;

[CreateAssetMenu(fileName = "Config file", menuName = "Make config")]
public class ConfigScript : ScriptableObject
{
    [Header("\tHEARTS")]
    public GameObject HeartPref;
    public int MaxHP = 5;
    public int StartHP = 3;

    [Header("\tPUSHER")]
    public GameObject[] FruitToPush = new GameObject[0];
    [Range(0, 100)]
    public float SpawnLengthInProcent;

    [Header("\tKNIFE")]
    public GameObject CutLine;
    [Range(0, 10)]
    public float LifeTime;

    [Header("\tFRUIT")]
    public float Gravity = -100.0f;

    [Header("\tSWIPE")]
    [Range(0, 1000)]
    public float MinSpeed = 500;
}
