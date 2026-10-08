using UnityEngine;
public class PlayerController : Singleton<PlayerController>
{
    Rigidbody2D _rb;
    public float jumpForce;
    public float walkForce;
    bool canJump;
    bool lastMovedRight;
    [SerializeField] int playerHealth;
    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                canJump = false;
            }
        }
    }

    public void TakeHealth(int dmg)
    {
        playerHealth -= dmg;
        if (playerHealth <= 0)
        {
            Lose();
        }
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            lastMovedRight = false;
            _rb.AddForce(new Vector2(-walkForce, 0), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            lastMovedRight = true;
            _rb.AddForce(new Vector2(walkForce, 0), ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
}