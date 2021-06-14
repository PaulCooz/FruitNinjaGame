using UnityEngine;
using UnityEngine.UI;

public class HomeScore : MonoBehaviour
{
    private string LastScoreText = "best score: ";

    private void OnEnable()
    {
        int CurrentScore = PlayerPrefs.GetInt("BestScore", 0);

        gameObject.GetComponent<Text>().text = LastScoreText + CurrentScore;
    }
}
