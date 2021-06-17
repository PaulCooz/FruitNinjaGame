public class LastScore : ScoreText
{
    private string TextView;

    public CurrentScoreText CurrentScoreField;

    private void Awake()
    {
        TextView = TextField.text;
        EventManager.OnGameOverEvent += UpdateText;
    }

    public void UpdateText()
    {
        TextField.text = string.Format(TextView, CurrentScoreField.Score);
    }
}
