using UnityEngine;

public class PopupManager : MonoBehaviour
{
    private bool isEnableNow;

    public Animator AnimatorController;

    private void Awake()
    {   
        EventManager.OnSartGameEvent += Hide;
        EventManager.OnGameOverEvent += Show;
    }

    private void Start()
    {
        DisableObject();
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
