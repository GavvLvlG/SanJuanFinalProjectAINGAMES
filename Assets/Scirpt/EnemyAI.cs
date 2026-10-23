using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    float paddleSpeed = 5;

    [SerializeField]
    float topBound = 560;

    [SerializeField]
    float bottomBound = 40;

    private Ball ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballPrefab = GameObject.FindAnyObjectByType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballPrefab == null)
        {
            ballPrefab = GameObject.FindAnyObjectByType<Ball>();
        }

        if (ballPrefab != null)
        {
            float ballCenterY = ballPrefab.GetComponent<SpriteRenderer>().bounds.center.y;
            float centerY = GetComponent<SpriteRenderer>().bounds.center.y;

            // attempt to follow the ball Y position
            if (centerY < ballCenterY)
            {
                float newYPos = transform.position.y + (paddleSpeed * Time.deltaTime);
                transform.position = new Vector2(transform.position.x, newYPos);
            }

            if (centerY > ballCenterY)
            {
                float newYPos = transform.position.y - (paddleSpeed * Time.deltaTime);
                transform.position = new Vector2(transform.position.x, newYPos);
            }
        }
        // prevent AI paddle from leaving top and bottom of the screen
        if (transform.position.y > topBound)
        {
            transform.position = new Vector2(transform.position.x, topBound);
        }
        else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector2(transform.position.x, bottomBound);
        }
    }
}
