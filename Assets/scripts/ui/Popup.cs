using UnityEngine;

public class Popup : MonoBehaviour
{
    private void Awake()
    {
        EventManager.OnGameOverEvent += Show;
        EventManager.OnSartGameEvent += Hide;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventManager.OnGameOverEvent -= Show;
        EventManager.OnSartGameEvent -= Hide;
    }
}
