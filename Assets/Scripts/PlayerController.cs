using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    public float jumpForce;
    public float walkForce;
    bool canJump;
    bool lastMovedRight;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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