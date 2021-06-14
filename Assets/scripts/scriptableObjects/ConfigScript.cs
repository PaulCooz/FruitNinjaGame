using UnityEngine;

[CreateAssetMenu(fileName = "Config file", menuName = "Make config")]
public class ConfigScript : ScriptableObject
{
    [System.Serializable]
    public struct PushFruit
    {
        public GameObject PushingObject;
        public ushort Chance;
    }

    [System.Serializable]
    public struct Line
    {
        [Range(0, 1)]
        public float StartX;
        [Range(0, 1)]
        public float StartY;
        [Range(0, 1)]
        public float EndX;
        [Range(0, 1)]
        public float EndY;

        public ushort Chance;
    }

    [Header("\tHEARTS")]
    public GameObject HeartPref;
    public int MaxHP = 5;
    public int StartHP = 3;

    [Header("\tKNIFE")]
    public GameObject CutLine;
    [Range(0, 10)]
    public float LifeTime;

    [Header("\tPUSHER")]
    public PushFruit[] FruitToPush = new PushFruit[0];
    public Line[] PushLine = new Line[0];
    public float TimeBetweenPacks;
    public float TimeBetweenFruit;
    public int MaxPack;

    [Header("\tFRUIT")]
    [Range(0, 1)]
    public float DeviationFromCenter = 0.1f;
    public float Speed = 2;
    public float HalfSpeed = 4;
    public float DeviationHalfByX = 0.5f;
    public float Gravity = -100.0f;

    [Header("\tSWIPE")]
    [Range(0, 1000)]
    public float MinSpeed = 500;
}
