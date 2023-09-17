using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
