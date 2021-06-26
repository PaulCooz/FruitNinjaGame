using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int BestScore;
    private int Score;

    private void Awake()
    {
        EventManager.OnSartGameEvent += SetStartScore;
        EventManager.OnScoreChange += AddToScore;
    }

    private void Start()
    {
        SetStartScore();
    }

    private void SetStartScore()
    {
        BestScore = BestScoreManager.GetBest();
        Score = 0;
    }

    private void AddToScore(int Change, Vector2 InPosition)
    {
        Score += Change;

        if (Score > BestScore)
        {
            BestScore = Score;
            BestScoreManager.SetBestScore(BestScore);
        }
    }

    public int GetScore()
    {
        return Score;
    }
    
    public int GetBestScore()
    {
        return BestScoreManager.GetBest();
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent -= SetStartScore;
        EventManager.OnScoreChange -= AddToScore;
    }
}