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

        jumpForce = 11; // default jumpforce
        speed = 6; // default speed
    }
    private void Update()
    {
        Moving();
        Jumping();
    }
    private void Moving()
    {
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (direction != 0)
        {
            if (direction < 0) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);
            if (isJumping) return;
            animator.SetBool("isRun", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isHurt", false);
        }
        else
        {
            if (isJumping) return;
            animator.SetBool("isRun", false);
            animator.SetBool("isIdle", true);
            animator.SetBool("isJump", false);
            animator.SetBool("isHurt", false);
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
        animator.SetBool("isHurt", false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Dead"))
        {
            isDead = true;
        }
        countJump = 0;
        isJumping = false;
        animator.SetBool("isJump", false);
        animator.SetBool("isRun", false);
        animator.SetBool("isIdle", true);
        animator.SetBool("isHurt", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            HealthController.d_health--;
            animator.SetBool("isJump", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isHurt", true);
            if (HealthController.d_health <= 0)
            {
                isDead = true;
            }
        }
        if (collision.CompareTag("Finish"))
        {
            GameController.isWin = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            if (!Input.GetKeyDown(KeyCode.M)) return;
            if (HealthController.d_health >= 3) return;
            HealthController.d_health++;
            Destroy(collision.gameObject);
        }
    }

}
