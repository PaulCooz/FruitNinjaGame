using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private readonly string BestScoreKey = "BestScore";
    private string CurrentScoreText = "score: ";
    private string BestScoreText = "<size=50>best: </size>";
    private int CurrentScore;
    private int BestScore;

    void Start()
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

            if (BestScore == CurrentScore)
            {
                GetComponent<Text>().text = CurrentScoreText + CurrentScore;
            }
            else
            {
                GetComponent<Text>().text = CurrentScoreText + CurrentScore + "\n" +
                                            BestScoreText + BestScore;
            }
        }
    }

    int LoadScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    void SaveScore(int CurrentBest)
    {
        PlayerPrefs.SetInt(BestScoreKey, CurrentBest);
        PlayerPrefs.Save();
    }
}
