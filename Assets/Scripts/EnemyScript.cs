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
}
