using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 2f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string jumpAxis;

    private AudioSource audioSource;

    private bool isGrounded;

    private void Start()
    {
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.gameRunning) return;
        float horizontalInput = Input.GetAxis(horizontalAxis);
        MovePlayer(horizontalInput);
    }

    private void Update()
    {
        if (!GameManager.Instance.gameRunning) return;
        isGrounded = CheckIsGrounded();
        if (isGrounded && Input.GetButtonDown(jumpAxis))
        {
            Jump();
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void MovePlayer(float horizontalInput)
    {
        rb2d.velocity = new Vector2(horizontalInput * moveSpeed, rb2d.velocity.y);
        animator.SetFloat("Speed", Math.Abs(rb2d.velocity.x));
        if(rb2d.velocity.x < 0f)
            spriteRenderer.flipX = true;
        if (rb2d.velocity.x > 0f)
            spriteRenderer.flipX = false;
    }

    private bool CheckIsGrounded()
    {

        if (Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump()
    {
        audioSource.Play();
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!GameManager.Instance.gameRunning) return;
        if (collider.gameObject.CompareTag("DeadZone"))
        {
            transform.position = playerRespawnPoint.position;
        }else if (collider.gameObject.CompareTag("Spike"))
        {
            transform.position = playerRespawnPoint.position;
        }
    }
}
