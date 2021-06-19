using UnityEngine;

public class UiManager : MonoBehaviour
{
    public CutText TextPref;

    public void SendText(int Num, Vector3 Position)
    {
        if (Num == 0) return;

        CutText NewText = Instantiate(TextPref, Position, Quaternion.identity, transform);
        NewText.Init(Num);
    }
}
