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

    void Update() // Called every frame
    {
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
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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
}
