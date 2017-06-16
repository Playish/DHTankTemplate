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

    // Is called before Start
    private void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        playishInput = GetComponent<PlayishInput>();
    }

    // Is only called at the start of the game
    void Start()
    {
        jumpTimerReset = jumpTimer;
        jumpTimer = 0f; // Makes sure the player can jump at the start of the game
	}
	
	// Update is called once per frame
	void Update()
    {
        jumpTimer -= Time.deltaTime;

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