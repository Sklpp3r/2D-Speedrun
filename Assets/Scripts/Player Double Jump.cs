using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public int maxJumps = 2; // İki kez zıplamak için

    private int remainingJumps;

    private void Start()
    {
        remainingJumps = maxJumps;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && remainingJumps > 0)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(rb.velocity.x, 0f); // Yatay hızı koru, sadece dikey hızı ayarla
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        remainingJumps--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas ettiğimizde tekrar zıplama hakkını yenile
        if (collision.gameObject.CompareTag("Ground"))
        {
            remainingJumps = maxJumps;
        }
    }
}