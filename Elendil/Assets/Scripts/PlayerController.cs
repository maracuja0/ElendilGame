using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private float vertical;
    private float horizontal;

    public FixedJoystick joystick;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        Vector2 move = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(direction * speed * Time.deltaTime, Force); 
        Vector2 position = rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }
}
