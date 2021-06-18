using UnityEngine;

public class BombLogic : FruitLogic
{
    public new void Cutted()
    {
        Instantiate(FruitParameters.Particles, transform.position, Quaternion.identity);

        EventManager.HealthChange(FruitParameters.HeartOnSwipe);
        EventManager.Explosion(transform.position);

        Destroy(gameObject);
    }
}
