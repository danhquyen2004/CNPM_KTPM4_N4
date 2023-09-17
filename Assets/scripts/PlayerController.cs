using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float direction;
    public float jumpForce;
    [SerializeField] private int countJump = 0;

    private Rigidbody2D rb;
    private BoxCollider2D col;

    [SerializeField] private Vector2 sizeSlide = new Vector2(0.6f,1.0f);
    private Vector2 sizeBox;

    private Animator animator;

    private bool isDead;
    public bool IsDead { get { return isDead; } }

    private void Awake()
    {
        direction = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sizeBox = col.size;
        isDead = false;
    }
    private void Update()
    {
        Moving();
        Jumping();
        Slide();
    }
    private void Moving()
    {
        Vector2 position = transform.position;
        position.x += direction * speed * Time.deltaTime;
        transform.position = position;
    }
    private void Jumping()
    {
        if (countJump >= 2) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        countJump++;

        animator.SetBool("isJump", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            countJump = 0;
            animator.SetBool("isJump", false);
        }
        if (collision.collider.CompareTag("Trap"))
        {
            isDead = true;
        }
    }
    private void Slide()
    {
        if(col == null) return;
        if(Input.GetKey(KeyCode.S))
        {
            col.size = sizeSlide;
            animator.SetBool("isSlide", true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            col.size = sizeBox;
            animator.SetBool("isSlide", false);
        }
    }    


}
