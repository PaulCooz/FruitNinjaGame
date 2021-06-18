using UnityEngine;    
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int BestScore;
    private string TextView;
    private int Score;

    public Text TextField;
    public Animator TextAnimator;

    private void Awake()
    {
        EventManager.OnSartGameEvent += SetStartScore;
        EventManager.OnScoreChange += AddToScore;
    }

    private void Start()
    {
        TextView = TextField.text;
        SetStartScore();
    }

    private void SetStartScore()
    {
        BestScore = BestScoreManager.GetBest();
        Score = 0;
        TextField.text = string.Format(TextView, Score, BestScore);
    }

    public void AddToScore(int Change)
    {
        Score += Change;

        if (Score > BestScore)
        {
            BestScoreManager.SetBestScore(Score);
        }

        TextAnimator.SetTrigger("TextAnimate");
        TextField.text = string.Format(TextView, Score, BestScore);
    }

    public int GetScore()
    {
        return Score;
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent -= SetStartScore;
        EventManager.OnScoreChange -= AddToScore;
    }
}
