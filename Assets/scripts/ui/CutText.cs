using UnityEngine;
using UnityEngine.UI;

public class CutText : MonoBehaviour
{
    public Text TextField;
    public int DestroyTime = 2;

    public void Init(int Num)
    {
        TextField.text = string.Format(TextField.text, Num);
        Destroy(gameObject, DestroyTime);
    }
}
