using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 position;
    [SerializeField] private float y;
    [SerializeField] private float z;
    private void Update()
    {
        if (player == null) return;
        Follow();
    }
    private void Follow()
    {
        position = player.transform.position;
        position = new Vector3(position.x, position.y + 2, z);
        transform.position = position;
    }
}
