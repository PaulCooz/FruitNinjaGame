using UnityEngine;
using UnityEngine.UI;

public class HomeScoreManager : MonoBehaviour
{
    private string TextView;

    public Text TextField;

    private void Awake()
    {
        TextView = TextField.text;
    }

    private void OnEnable()
    {
        TextField.text = string.Format(TextView, BestScoreManager.GetBest());
    }
}
