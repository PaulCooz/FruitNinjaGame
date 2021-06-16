
public class CurrentScoreText : ScoreText
{
    private int CurrentScore;
    private int BestScore;
    private string TextView;

    private void Awake()
    {
        TextView = TextField.text;
    }

    private void Start()
    {
        EventManager.OnSartGameEvent += SetStartScore;
        SetStartScore();
    }

    private void SetStartScore()
    {
        CurrentScore = 0;
        BestScore = GetBestScore();

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
                SetBestScore(BestScore);
            }

            TextField.text = string.Format(TextView, CurrentScore, BestScore);
        }
    }

    private void OnDestroy()
    {
        EventManager.OnSartGameEvent -= SetStartScore;
    }
}
