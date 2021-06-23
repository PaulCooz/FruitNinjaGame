using UnityEngine;

public class CutTextManager : MonoBehaviour
{
    public CutText TextPref;

    private void OnEnable()
    {
        EventManager.OnScoreChange += SendText;
    }

    public void SendText(int Num, Vector2 Position)
    {
        if (Num == 0) return;

        CutText NewText = Instantiate(TextPref, Position, Quaternion.identity, transform);
        NewText.Init(Num);
    }

    private void OnDestroy()
    {
        EventManager.OnScoreChange -= SendText;
    }
}
