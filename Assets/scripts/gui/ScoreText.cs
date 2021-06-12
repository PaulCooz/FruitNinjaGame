using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public string CurrentText = "score: ";
    public string BestText = "best: ";

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
                GetComponent<Text>().text = CurrentText + CurrentScore;
            }
            else
            {
                GetComponent<Text>().text = CurrentText + CurrentScore + "\n" +
                                            BestText + BestScore;
            }
        }
    }
}
