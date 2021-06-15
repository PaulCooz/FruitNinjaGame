using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool Touching;
    private Vector2 PreviousDot;

    public ConfigScript Config;    

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
        GameObject Line = Instantiate(Config.CutLine, StartDot, Quaternion.identity);

        Line.GetComponent<LineRenderer>().SetPosition(0, StartDot);
        Line.GetComponent<LineRenderer>().SetPosition(1, EndDot);
        Line.transform.SetParent(transform);

        Destroy(Line, Config.LifeTime);
    }
}
