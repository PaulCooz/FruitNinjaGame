using UnityEngine;

public class HeartViewer : MonoBehaviour
{
    public Animator HeartAnimator;

    private void Start()
    {
        HeartAnimator.SetTrigger("AddHeart");
    }

    public void PopHeart()
    {
        HeartAnimator.SetTrigger("RemoveHeart");
    }

    public void RemoveHeart()
    {
        Destroy(gameObject);
    }
}
