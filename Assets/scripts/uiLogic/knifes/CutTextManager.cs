using UnityEngine;

public class CutTextManager : MonoBehaviour
{
    public CanvasForText TextPref;

    private void OnEnable()
    {
        EventManager.OnScoreChange += SendText;
    }

    public void SendText(int Num, Vector2 Position)
    {
        if (Num == 0) return;

        Instantiate(TextPref, Position, Quaternion.identity, transform).Init(Num);
    }

    private void OnDestroy()
    {
        EventManager.OnScoreChange -= SendText;
    }
}
