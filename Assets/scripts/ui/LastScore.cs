using UnityEngine;
using UnityEngine.UI;

public class LastScore : MonoBehaviour
{
    private string LastScoreText = "your score: ";

    private void OnEnable()
    {
        int CurrentScore = GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score;

        gameObject.GetComponent<Text>().text = LastScoreText + CurrentScore;
    }
}
