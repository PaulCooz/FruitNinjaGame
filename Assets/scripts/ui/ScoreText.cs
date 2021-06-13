using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private string CurrentScoreText = "score: ";
    private string BestScoreText = "<size=50>best: </size>";
    private int CurrentScore;
    private int BestScore;

    void Start()
    {
        CurrentScore = 0;
        BestScore = 10;

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
}
