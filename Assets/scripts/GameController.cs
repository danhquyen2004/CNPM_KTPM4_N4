using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public static bool isWin;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject win;
    private void Start()
    {
        Time.timeScale = 1;
        isWin = false;
        gameOver = GameObject.FindWithTag("GameOver");
        pause = GameObject.FindWithTag("Pause");
        win = GameObject.FindWithTag("Win");
        gameOver.SetActive(false);
        pause.SetActive(false);
        win.SetActive(false);
    }
    private void FixedUpdate()
    {
        EndGame();
        PauseGame();
        if (UI_Controller.isResume)
        {
            ResumeGame();
            UI_Controller.isResume = false;
        }
        WinGame();
    }
    private void EndGame()
    {
        if (!player.GetComponent<PlayerController>().IsDead) return;
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    private void PauseGame()
    {
        if (!UI_Controller.isPause) return;
        //Time.timeScale = 0;
        PlayerController.speed = 0;
        pause.SetActive(true);
    }
    private void ResumeGame()
    {
        pause.SetActive(false);
        //Time.timeScale = 1;
        PlayerController.speed = 6;
    }
    private void WinGame()
    {
        if (!isWin) return;
        PlayerController.speed = 0;
        win.SetActive(true);
    }
}
