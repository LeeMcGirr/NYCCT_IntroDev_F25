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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        grounded = false;
        destroyedCount = 0;
    }

    // Update is called once per frame
    void Update()
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

    //Fixed Update is called once per physics step
    void FixedUpdate()
    {

        //let's start with a simple WASD controller
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        myRB.AddForce(velocity);

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
