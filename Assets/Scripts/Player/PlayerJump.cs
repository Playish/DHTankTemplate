using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;

    bool canJump = false;

    Rigidbody2D rb;

    PlayishInput playishInput;

    Player player;

    public float jumpTimer = 3f;

    float jumpTimerReset;

    private void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        playishInput = GetComponent<PlayishInput>();
    }

    // Use this for initialization
    void Start()
    {
        jumpTimerReset = jumpTimer;
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        jumpTimer -= Time.fixedDeltaTime;

		if(playishInput.buttona)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpTimer <= 0f)
        {
            Jump();
        }
	}

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        jumpTimer = jumpTimerReset;
    }
}