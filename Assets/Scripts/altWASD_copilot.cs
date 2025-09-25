using UnityEngine;

public class altWASD_copilot : MonoBehaviour
{
    public float speed = 10f;
    // ...existing code...
    private Rigidbody2D rb;
    // ...existing code...

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    // ...existing code...
    }

    void Update()
    {
    // ...existing code...
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        transform.position += move;
    }



    // ...existing code...
}