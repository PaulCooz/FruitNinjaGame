using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplyLogic : MonoBehaviour
{
    private string StartText;
    
    public MainConfig Config;
    public Text ScoreMultiplyText;

    private void Awake()
    {
        StartText = ScoreMultiplyText.text;
    }

    private void OnEnable()
    {
        ScoreMultiplyText.text = string.Format(StartText, Config.ScoreMultiply);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
