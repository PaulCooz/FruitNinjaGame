using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private readonly string BestScoreKey = "BestScore";
    private string CurrentScoreText = "score: ";
    private string BestScoreText = "<size=50>best: </size>";
    private int CurrentScore;
    private int BestScore;

    private void Start()
    {
        EventManager.OnSartGameEvent += SetStartScore;
        SetStartScore();
    }

    private void SetStartScore()
    {
        CurrentScore = 0;
        BestScore = LoadScore();

        Score = CurrentScore;
    }

    public int Score
    {
        get
        {
            return CurrentScore;
        }
        set
        {
            CurrentScore = value;
            
            if (BestScore < CurrentScore)
            {
                BestScore = CurrentScore;
                SaveScore(BestScore);
            }

            GetComponent<Text>().text = CurrentScoreText + CurrentScore;
            if (BestScore != CurrentScore)
            {
                GetComponent<Text>().text += "\n" + BestScoreText + BestScore;
            }
        }
    }

    private int LoadScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void SaveScore(int CurrentBest)
    {
        PlayerPrefs.SetInt(BestScoreKey, CurrentBest);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent -= SetStartScore;
    }
}
