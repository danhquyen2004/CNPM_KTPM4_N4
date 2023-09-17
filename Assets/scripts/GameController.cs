using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        EndGame();
    }
    private void EndGame()
    {
        if(player.GetComponent<PlayerController>().IsDead)
            Time.timeScale = 0;
    }
}
