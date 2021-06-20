using UnityEngine;

[CreateAssetMenu(fileName = "Main config file", menuName = "Make main config")]
public class MainConfig : ScriptableObject
{
    [Header("\tANIMATIONS")]
    public float RotateSpeed;
    public float ScaleSpeed;

    [Header("\tHEARTS")]
    public HeartViewer HeartPref;
    public int MaxHP = 5;
    public int StartHP = 3;

    [Header("\tKNIFE")]
    public KnifeLogic CutLine;
    [Range(0, 10)]
    public float LifeTime;

    [Header("\tPUSHER")]
    public ushort SlowdownOfComplexity = 10;
    public ushort MaxDivisor = 2;
    public ObjectAndChance<FruitLogic>[] FruitToPush;
    public ObjectAndChance<TwoDots>[] PushLine;
    public float TimeBetweenPacks;
    public float TimeBetweenFruit;
    public int MaxPack;
    [Range(0, 1)]
    public float MidX = 0.5f;
    [Range(0, 1)]
    public float MidY = 0.6f;

    [Header("\tFRUIT")]
    [Range(0, 1)]
    public float DeviationFromCenterByX = 0.1f;
    public float Force = 200;
    public float BombMultiplier = 0.5f;
    public float TimeSpeed = 1;
    public float TimeSpeedIncrease = 10;
    public float DeviationHalfByX = 0.5f;
    public float Gravity = -100.0f;

    [Header("\tSWIPE")]
    [Range(0, 10000)]
    public float MinSpeed = 500;
}


[System.Serializable]
public struct TwoDots
{
    [Range(0, 1)]
    public float StartX;
    [Range(0, 1)]
    public float StartY;
    [Range(0, 1)]
    public float EndX;
    [Range(0, 1)]
    public float EndY;
}

[System.Serializable]
public struct ObjectAndChance<T>
{
    [SerializeField]
    public T Object;
    [SerializeField]
    public ushort Chance;
}

[System.Serializable]
public static class ExtensionMethods
{
    public static int GetRandomIndex<T>(this ObjectAndChance<T>[] ArrayOfObjects)
    {
        int SumOfChances = 0;
        for (int i = 0; i < ArrayOfObjects.Length; i++)
        {
            SumOfChances += ArrayOfObjects[i].Chance;
        }

        int CurrentChance = Random.Range(1, SumOfChances + 1);
        int Result = 0;
        for(int i = 0; i < ArrayOfObjects.Length; i++)
        {
            CurrentChance -= ArrayOfObjects[i].Chance;

            if (CurrentChance <= 0)
            {
                Result = i;
                break;
            }
        }

        return Result;
    }
}