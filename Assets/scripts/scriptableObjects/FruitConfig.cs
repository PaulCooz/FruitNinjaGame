using UnityEngine;

[CreateAssetMenu(fileName = "Fruit config file", menuName = "Make fruit config")]
public class FruitConfig : ScriptableObject
{
    [Header("\tHEARTS")]
    public Health.HP HeartOnFall;
    public Health.HP HeartOnSwipe;

    [Header("\tCUT")]
    public int PointsForCut;
    public bool HaveHalves;
    public HalfLogic Half0;
    public HalfLogic Half1;
    public GameObject Particles;

    [Header("\tSPRITE")]
    public Sprite FruitImage;

}
