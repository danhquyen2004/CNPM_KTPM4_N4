using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pause;
    private void Start()
    {
        Time.timeScale = 1;
        gameOver = GameObject.FindWithTag("GameOver");
        pause = GameObject.FindWithTag("Pause");
        gameOver.SetActive(false);
        pause.SetActive(false);
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
        Debug.Log(UI_Controller.isResume);
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
        PlayerController.speed = 5;
    }
}
