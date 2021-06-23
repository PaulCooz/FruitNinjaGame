using UnityEngine;

public class BombLogic : FruitLogic
{
    public override void Cutted()
    {
        Instantiate(Fruit.Particles, transform.position, Quaternion.identity);

        EventManager.HealthChange(Fruit.HeartOnSwipe);
        EventManager.Explosion(transform.position);

        Destroy(gameObject);
    }
}
