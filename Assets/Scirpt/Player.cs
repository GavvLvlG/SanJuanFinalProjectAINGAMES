using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float paddleSpeed = 10f;

    [SerializeField]
    float topBound = 560;

    [SerializeField]
    float bottomBound = 40;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // move paddle up
            float newY = transform.position.y + (paddleSpeed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, newY);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // move paddle down
            float newY = transform.position.y + (-paddleSpeed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, newY);
        }

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
