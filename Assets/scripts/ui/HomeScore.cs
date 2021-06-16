public class HomeScore : ScoreText
{
    private string TextView;

    private void Awake()
    {
        TextView = TextField.text;
    }

    private void OnEnable()
    {
        TextField.text = string.Format(TextView, GetBestScore());
    }
}
