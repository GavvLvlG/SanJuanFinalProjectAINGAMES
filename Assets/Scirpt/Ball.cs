using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float yForceRange = 100;

    [SerializeField]
    private float speedX = 0;

    [SerializeField]
    private float speedY = 0;

    [SerializeField]
    float leftBound = 0;

    [SerializeField]
    float rightBound = 800;


    private Rigidbody2D ballRb;


    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(speedX, speedY);

        ballRb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        ballRb = GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(speedX, speedY);

        ballRb.AddForce(force);

        if (transform.position.x < leftBound)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x > rightBound)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float yForce = Random.Range(-yForceRange, yForceRange);
        Vector2 force = new Vector2(0, yForce);
        ballRb.AddForce(force);
        speedX = speedX * -1;
    }
}
