using UnityEngine;

public class Knife : MonoBehaviour
{
    [Range(0, 60)] 
    public float LifeTime;
    public GameObject CutLine;

    private bool Touching;
    private Vector2 PreviousDot;

    private void Start()
    {
        Touching = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 CurrentDot = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            PreviousDot = CurrentDot;
            Touching = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Touching = false;
        }

        if (Touching)
        {
            Vector2 CurrentDot = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            MakeNewLine(PreviousDot, CurrentDot);
            PreviousDot = CurrentDot;
        }
    }

    void MakeNewLine(Vector2 StartDot, Vector2 EndDot)
    {
        GameObject Line = Instantiate(CutLine, StartDot, Quaternion.identity);

        Line.GetComponent<LineRenderer>().SetPosition(0, StartDot);
        Line.GetComponent<LineRenderer>().SetPosition(1, EndDot);
        Line.transform.SetParent(transform);

        Destroy(Line, LifeTime);
    }
}
