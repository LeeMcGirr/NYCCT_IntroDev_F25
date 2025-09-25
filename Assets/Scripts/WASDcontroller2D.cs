using UnityEngine;

public class WASDcontroller2D : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 20f;
    public float dashForce = 60f;
    public Rigidbody2D myRB;

    public bool jumped = false;
    public bool dashed = false;
    public bool grounded = false;
    public int destroyedCount = 0;

    public float startTimer = 3f;


    [Header("player FX")]
    public GameObject TrailLeft;
    public GameObject TrailRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        TrailLeft = transform.Find("TrailLeft").gameObject;
        TrailRight = transform.Find("TrailRight").gameObject;
        grounded = false;
        destroyedCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer > 0)
        {
            //code here that runs before the game starts
        }

        if (startTimer < 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) && grounded)
            {
                jumped = true;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                dashed = true;
            }
        }
    }

    //Fixed Update is called once per physics step
    void FixedUpdate()
    {

        startTimer -= Time.fixedDeltaTime;
        //let's start with a simple WASD controller
        Vector3 velocity = Vector3.zero;

        if (startTimer > 0)
        {
            myRB.gravityScale = 0;
        }

        if (startTimer < 0)
        {
            myRB.gravityScale = .6f;
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -speed;
                TrailRight.SetActive(true);
            }
            else {
                TrailRight.SetActive(false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = speed;
                TrailLeft.SetActive(true);
            }
            else {
                TrailLeft.SetActive(false);
            }


            myRB.AddForce(velocity);

            //scale the player based off the current velocity of the player
            float xVel = Mathf.Abs(myRB.linearVelocity.x)-1;
            float yVel = Mathf.Abs(myRB.linearVelocity.y)-1;
            Vector3 currentVel = new Vector3(xVel, yVel, 1);
            currentVel = Vector3.ClampMagnitude(currentVel, 20);
            Debug.Log(currentVel);
            transform.localScale = (Vector3.one + (currentVel/20f))*.6f;

            //when player presses space, jump
            if (jumped)
            {
                Jump();
                jumped = false;
            }

            if (dashed)
            {
                DownDash();
                dashed = false;
            }
        }
    }


    //OnCollisionEnter2D is called by Unity's physics engine when a collision starts/occurs on a frame
    //Unity gives us a Collision2D dataType we can use to find out more about the collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Entered with: " + other.gameObject.name);

        if (other.gameObject.tag == "Destructible")
        {
            Destroy(other.gameObject);
            destroyedCount += 1;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject);
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Stopped Colliding with: " + collision.gameObject);
        grounded = false;
    }

    //you can write your own custom functions to execute specific actions or tasks
    void Jump()
    {
            myRB.AddForce(Vector3.up * jumpForce);
    }

    void DownDash()
    {
        myRB.AddForce(Vector3.down * dashForce);
    }


}
