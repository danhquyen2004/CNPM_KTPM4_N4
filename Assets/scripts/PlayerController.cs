using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float speed;
    private float direction;
    public static float jumpForce;
    [SerializeField] private int countJump = 0;

    private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    [SerializeField] private bool isDead;
    public bool IsDead { get { return isDead; } }
    private bool isJumping;

    private void Awake()
    {
        //direction = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isDead = false;
        isJumping = false;

        jumpForce = 10; // default jumpforce
        speed = 5; // default speed
    }
    private void Update()
    {
        Moving();
        Jumping();
    }
    private void Moving()
    {
        direction = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x += direction * speed * Time.deltaTime;
        transform.position = position;

        if(direction != 0 ) 
        {
            if (direction < 0) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);
            if (isJumping) return;
            animator.SetBool("isRun", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isJump", false);
        }
        else
        {
            if (isJumping) return;
            animator.SetBool("isRun", false);
            animator.SetBool("isIdle", true);
            animator.SetBool("isJump", false);
        }

    }
    private void Jumping()
    {
        if (countJump >= 2) return;
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        isJumping = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        countJump++;

        animator.SetBool("isJump", true);
        animator.SetBool("isRun", false);
        animator.SetBool("isIdle", false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            countJump = 0;
            isJumping = false;
            animator.SetBool("isJump", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isIdle", true);
        }
        if (collision.collider.CompareTag("Trap"))
        {
            isDead = true;
        }
    }


}
