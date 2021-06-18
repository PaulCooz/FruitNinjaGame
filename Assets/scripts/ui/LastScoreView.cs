using UnityEngine;
using UnityEngine.UI;

public class LastScoreView : MonoBehaviour
{
    private string TextView;

    public Text TextField;
    public ScoreManager CurrentScoreField;

    private void Awake()
    {
        EventManager.OnGameOverEvent += UpdateText;
    }

    private void Start()
    {
        TextView = TextField.text;
    }

    public void UpdateText()
    {
        TextField.text = string.Format(TextView, CurrentScoreField.GetScore());
    }

    private void OnDestroy()
    {
        EventManager.OnGameOverEvent -= UpdateText;
    }
}
