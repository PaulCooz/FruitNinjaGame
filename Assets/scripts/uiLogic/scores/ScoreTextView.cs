using UnityEngine;
using UnityEngine.UI;

public class ScoreTextView : MonoBehaviour
{
    private string TextView;
    private int PreviousScore;
    private int PreviousBestScore;

    public Text textField;
    public ScoreManager scores;
    public MainConfig Config;

    private void OnEnable()
    {
        PreviousScore = 0;
        PreviousBestScore = scores.GetBestScore() * Config.StartScoreAtBest / 100;

        TextView = textField.text;
        textField.text = string.Format(TextView, 0, PreviousBestScore);
    }

    void Update()
    {
        if (PreviousScore < scores.GetScore())
        {
            textField.text = string.Format(TextView, ++PreviousScore, scores.GetBestScore());
        }
        if (PreviousBestScore < scores.GetBestScore())
        {
            textField.text = string.Format(TextView, scores.GetScore(), ++PreviousBestScore);
        }
    }
}
