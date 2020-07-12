using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 7f;
    [SerializeField] float yVelocity = 12f;
    [SerializeField] float randomFactor = 0.4f;

    // state
    Vector2 positionDifference;
    bool lockedBall;

    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        lockedBall = true;
        positionDifference = transform.position - paddle1.transform.position;
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // the locking of position will keep updating as long as the boolean lockedBall is true
        if (lockedBall == true)
        {
            LockPosition();

            LaunchTheBall();
        }
        


    }

    private void LaunchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // when the mouse is clicked, the ball will stop being locked.
            lockedBall = false;
            myRigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
        }

    }

    private void LockPosition()
    {
        // First we get the position of the paddle, then to calculate the new
        // position of Ball, we add the initial difference to the new paddle position.
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + positionDifference;


    }


    //Play collision sound when the ball collides with an object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 stopBoringLoop = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (lockedBall == false)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody2D.velocity += stopBoringLoop;
        }
    }
}
