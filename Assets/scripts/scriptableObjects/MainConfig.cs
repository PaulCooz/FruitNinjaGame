using System.Collections.Generic;
using lib;
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
    public KnifeViewer knifeViewer;
    public CutLine cutLine;
    [Range(0, 10)]
    public float LifeTime;

    [Header("\tPUSHER")]
    public ushort SlowdownOfComplexity = 10;
    public ushort MaxDivisor = 2;
    public ObjectAndChance<FruitObject>[] FruitToPush;
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
    public float SpeedOfTime = 1;
    public float TimeSpeedIncrease = 10;
    public float DeviationHalfByX = 0.5f;
    public float Gravity = -100.0f;
    public int MaxCombo = 5;
    public float MinComboTime = 0.5f;
    
    [Header("\tBONUSES")]
    public float ExplosionMultiplier = 10000;
    public float FreezeMultiplier = 2;
    public float MaxFreezeTime = 4;

    [Header("\tSWIPE")]
    [Range(0, 10000)]
    public float MinSpeed = 500;
}