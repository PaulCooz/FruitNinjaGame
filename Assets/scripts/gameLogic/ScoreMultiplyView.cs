using UnityEngine;

public class ScoreMultiplyView : MonoBehaviour
{
    private bool IsShowing;
    
    public ScoreMultiplyLogic ScoreMultiply;
    public Animator ScoreAnimator;
    
    private void Awake()
    {
        EventManager.OnScoreMultiplyEvent += Show;
        IsShowing = false;
    }

    private void Show()
    {
        ScoreMultiply.gameObject.SetActive(true);
        ScoreAnimator.SetTrigger("Fadeout");
        IsShowing = true;
    }

    private void Update()
    {
        if (!EventManager.IsScoreMultiplying() && IsShowing)
        {
            IsShowing = false;
            ScoreAnimator.SetTrigger("Fadein");
        }
    }

    private void OnDestroy()
    {
        EventManager.OnScoreMultiplyEvent -= Show;
    }
}
