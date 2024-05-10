using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 1f;

    private bool isGrounded;

    private void Start()
    {
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        MovePlayer(horizontalInput);
    }

    private void Update()
    {
        isGrounded = CheckIsGrounded();
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void MovePlayer(float horizontalInput)
    {
        rb2d.velocity = new Vector2(horizontalInput * moveSpeed, rb2d.velocity.y);
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
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }
}
