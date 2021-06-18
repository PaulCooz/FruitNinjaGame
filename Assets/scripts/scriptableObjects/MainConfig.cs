using UnityEngine;

[CreateAssetMenu(fileName = "Main config file", menuName = "Make main config")]
public class MainConfig : ScriptableObject
{
    [Header("\tHEARTS")]
    public GameObject HeartPref;
    public int MaxHP = 5;
    public int StartHP = 3;

    [Header("\tKNIFE")]
    public GameObject CutLine;
    [Range(0, 10)]
    public float LifeTime;

    [Header("\tPUSHER")]
    public ObjectAndChance<FruitLogic>[] FruitToPush;
    public ObjectAndChance<TwoDots>[] PushLine;
    public float TimeBetweenPacks;
    public float TimeBetweenFruit;
    public int MaxPack;

    [Header("\tFRUIT")]
    [Range(0, 1)]
    public float DeviationFromCenterByX = 0.1f;
    public float Force = 200;
    public float BombMultiplier = 0.5f;
    public float TimeSpeed = 3;
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
    public static T GetRandomData<T>(this ObjectAndChance<T>[] ArrayOfObjects)
    {
        T Result = ArrayOfObjects[0].Object;

        int SumOfChances = 0;
        foreach(var Element in ArrayOfObjects)
        {
            SumOfChances += Element.Chance;
        }

        int CurrentChance = Random.Range(1, SumOfChances + 1);
        foreach(var Element in ArrayOfObjects)
        {
            CurrentChance -= Element.Chance;

            if (CurrentChance <= 0)
            {
                Result = Element.Object;
                break;
            }
        }

        return Result;
    }
}