using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLeftRight : MonoBehaviour
{
    public bool debugMode = false;

    public float movementSpeed;

    public float maxSpeed;

    public float currentSpeed;

    Rigidbody2D rb;

    PlayishInput playishInput;

    Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playishInput = GetComponent<PlayishInput>();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        currentSpeed = rb.velocity.magnitude;

        if(currentSpeed < maxSpeed)
        {
            PlayishMovement();
        }

        if(debugMode)
        {
            if(currentSpeed < maxSpeed)
            {
                KeyboardMovement();
            }
        }
	}

    // Is called when player collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    // Is called when player stops colliding with something
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    void PlayishMovement()
    {
        if (playishInput.playerDeviceId != "")
        {
            // Adds force horizontally when using the joystick
            if (playishInput.joystick.x != 0f)
            {
                rb.AddForce(transform.right * (movementSpeed * playishInput.joystick.x) * Time.fixedDeltaTime);
            }
        }
    }

    void KeyboardMovement()
    {
        if(Input.GetAxis("Horizontal") != 0f)
        {
            float direction = Input.GetAxis("Horizontal");
            rb.AddForce(transform.right * movementSpeed * Time.fixedDeltaTime);

            if(direction > 0f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if(direction < 0f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}