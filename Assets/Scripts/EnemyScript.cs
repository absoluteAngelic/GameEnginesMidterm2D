using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float movementSpeed;
    float movementDistance;
    bool walkingLeft;
    Vector3 startingPosition;
    Vector3 endingPosition;
    public Transform endingPositionTransform;
    public float oneDirectionMoveTime;
    float movementCursor;
    bool countingUp;
    public int damage;

    void Start()
    {
        startingPosition = this.transform.position;
        endingPosition = endingPositionTransform.position;
    }

    void Update()
    {
        if (movementCursor <= 0)
        {
            countingUp = true;
        }
        else if (movementCursor >= oneDirectionMoveTime)
        {
            countingUp = false;
        }

        if (countingUp)
        {
            movementCursor += Time.deltaTime;
        }
        else
        {
            movementCursor -= Time.deltaTime;
        }

        float lerpedCursor = Mathf.InverseLerp(0, oneDirectionMoveTime, movementCursor);

        this.transform.position = new Vector3(Mathf.Lerp(startingPosition.x, endingPosition.x, lerpedCursor), Mathf.Lerp(startingPosition.y, endingPosition.y, lerpedCursor), Mathf.Lerp(startingPosition.z, endingPosition.z, lerpedCursor));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.TakeHealth(damage);
        }
    }
}
