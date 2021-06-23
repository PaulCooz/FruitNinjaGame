using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    private bool Touching;
    private Vector2 PreviousDot;

    public MainConfig Config;

    private void Start()
    {
        Touching = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 CurrentDot = View.ToWorldPoint(Input.mousePosition);

            PreviousDot = CurrentDot;
            Touching = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Touching = false;
        }

        if (Touching)
        {
            Vector2 CurrentDot = View.ToWorldPoint(Input.mousePosition);

            MakeNewLine(PreviousDot, CurrentDot);
            PreviousDot = CurrentDot;
        }
    }

    private void MakeNewLine(Vector2 StartDot, Vector2 EndDot)
    {
        KnifeViewer Line = Instantiate(Config.CutLine, StartDot, Quaternion.identity, transform);
        Line.Init(StartDot, EndDot);

        Destroy(Line.gameObject, Config.LifeTime);
    }
}