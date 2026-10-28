using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerInput playerInput;
    [Header("Movement Variables")]
    public float speed;
    public float jumpForce;
    public float jumpCutMultiplier = 0.5f;
    public float normalGravity;
    public float fallGravity;
    public float jumpGravity;
    
    public Vector2 moveInput;
    public int faceDirec = 1;
    [Header("Check Variables")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Start()
    {
        rb.gravityScale = normalGravity;
    }

    void Update() // Called every frame
    {
        ApplyVariableGravity();
        CheckGrounded();
        Flip();
    }

    void FixedUpdate()
    {
        float targetSpeed = moveInput.x * speed;
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);
    }

    void ApplyVariableGravity()
    {
        if (rb.linearVelocity.y < -0.1) // for falling
        {
            rb.gravityScale = fallGravity;
        } 
        else if (rb.linearVelocity.y > 0.1) // for rising
        {
            rb.gravityScale = jumpGravity;
        } 
        else
        {
            rb.gravityScale = normalGravity;
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
        else
        {
            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * jumpCutMultiplier);
            }
        }
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
