using UnityEngine;

public class WASD : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position += Direction() * speed * Time.fixedDeltaTime;
    }


    Vector3 Direction()
    {
        float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        return new Vector3(h, 0, 0);
    }

    //OnCollisionEnter2D is called by Unity's physics engine when a collision starts/occurs on a frame
    //Unity gives us a Collision2D dataType we can use to find out more about the collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Entered with: " + other.gameObject.name);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Collision ongoing with: " + other.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision ended with: " + other.gameObject.name);
    }
}
