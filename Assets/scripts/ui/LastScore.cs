public class LastScore : ScoreText
{
    private string TextView;

    public CurrentScoreText CurrentScoreField;

    private void Awake()
    {
        TextView = TextField.text;
    }

    private void OnEnable()
    {
        TextField.text = string.Format(TextView, CurrentScoreField.Score);
    }
}
