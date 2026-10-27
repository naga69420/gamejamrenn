using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(1 * speed, rb.linearVelocity.y);
    }
}
