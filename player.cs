using UnityEngine;
using UnityEngine.SceneManagement; // Ditambahkan agar bisa pindah scene ke Main Menu

public class player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;

    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horiz * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Logika mengambil koin
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        // Logika menabrak musuh
        if (other.CompareTag("Enemy"))
        {
            // Mengurangi nyawa kelinci di HealthManager
            HealthManager.health--;

            Debug.Log("Aduh! Kelinci kena musuh. Sisa nyawa: " + HealthManager.health);

            // Jika nyawa habis, langsung pindah ke scene MainMenu
            if (HealthManager.health <= 0)
            {
                Debug.Log("Game Over! Kembali ke Main Menu.");
                SceneManager.LoadScene("Main Menu"); // Membuka scene bernama MainMenu
            }
        }
    }
}