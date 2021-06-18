using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    private static string BestScoreKey = "BestScore";

    public static int GetBest()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public static void SetBestScore(int NewBest)
    {
        PlayerPrefs.SetInt(BestScoreKey, NewBest);
        PlayerPrefs.Save();
    }
}
