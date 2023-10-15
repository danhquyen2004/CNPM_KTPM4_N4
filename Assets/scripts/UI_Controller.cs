using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public static bool isPause;
    public static bool isResume;
    private void Start()
    {
        isPause = false;
        isResume = false;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void RePlay()
    {
        string CurrentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentScene);
    }
    public void Pause()
    {
        isPause = true;
    }
    public void Resume()
    {
        isPause = false;
        isResume = true;
    }
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
    public void Level4()
    {
        SceneManager.LoadScene(5);
    }
}
