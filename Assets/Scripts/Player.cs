using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerInput playerInput;
    [Header("Movement Variables")]
    public float speed;
    public float jumpForce;
    public Vector2 moveInput;
    public int faceDirec = 1;
    [Header("Check Variables")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Update() // Called every frame
    {
        CheckGrounded();
        Flip();
    }

    void FixedUpdate()
    {
        float targetSpeed = moveInput.x * speed;
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Flip()
    {
        if (moveInput.x > 0.1f)
        {
            faceDirec = 1;
        } else if (moveInput.x < -0.1f)
        {
            faceDirec = -1;
        }
        transform.localScale = new Vector3(faceDirec, 1, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
