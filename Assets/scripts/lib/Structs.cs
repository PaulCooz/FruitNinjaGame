using UnityEngine;

namespace lib
{
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
    public struct FruitObject
    {
        public FruitLogic Fruit;
        public HealthManager.HP HeartOnFall;
        public HealthManager.HP HeartOnSwipe;
        public int PointsForCut;
        public bool HaveHalves;
        public HalfLogic Half0;
        public HalfLogic Half1;
        public GameObject Particles;
        public SpriteRenderer FruitSprite;
        public int MaxInPack;
    }

    [System.Serializable]
    public struct ObjectAndChance<T>
    {
        [SerializeField]
        public T Object;
        [SerializeField]
        public ushort Chance;
    }
}