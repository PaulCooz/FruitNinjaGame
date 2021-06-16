using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private readonly string BestScoreKey = "BestScore";

    public Text TextField;

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void SetBestScore(int NewBest)
    {
        PlayerPrefs.SetInt(BestScoreKey, NewBest);
        PlayerPrefs.Save();
    }


}
