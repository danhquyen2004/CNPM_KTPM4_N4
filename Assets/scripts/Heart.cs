using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //if(Input.GetKeyDown(KeyCode.M))
            //{
                HealthController.d_health++;
                Destroy(gameObject);
            //}
        }
    }
}
