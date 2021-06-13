using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    public void ChangeScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void HideGameObject(GameObject Object)
    {
        Object.SetActive(false);
    }
}
