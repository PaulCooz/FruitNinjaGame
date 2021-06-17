using UnityEngine;

public class Popup : MonoBehaviour
{
    private bool isEnableNow;

    public Animator AnimatorController;

    private void Awake()
    {
        EventManager.OnGameOverEvent += Show;
        EventManager.OnSartGameEvent += Hide;
    }

    private void Start()
    {
        AnimatorController.SetTrigger("FastHide");
        isEnableNow = false;
    }

    public void Show()
    {
        if (!isEnableNow)
        {
            EnableObject();
            AnimatorController.SetTrigger("FadeinPopup");
            isEnableNow = true;
        }
    }

    public void Hide()
    {
        AnimatorController.SetTrigger("FadeoutPopup");
        isEnableNow = false;
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
    
    public void EnableObject()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.OnGameOverEvent -= Show;
        EventManager.OnSartGameEvent -= Hide;
    }
}
