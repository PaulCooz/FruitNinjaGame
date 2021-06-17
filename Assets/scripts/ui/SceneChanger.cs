using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator AnimatorController;

    private void OnEnable()
    {
        PlayAnimation("Fadeout");
    }

    public void PlayAnimation(string TriggerName)
    {
        AnimatorController.SetTrigger(TriggerName);
    }

    public void OnAnimationDone(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }
}
