using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    float healthReset;

    Player player;
    PlayerHandler handler;

    SpriteRenderer rend;
    Collider2D col2D;

    Vector3 originalSpawn;

    public Color damagedColor;

    Color originalColor;

    float damagedTimer = 1f;

    bool canChangeColor;
    bool isDamaged;

    bool playerIsKilled = false;
    bool playerIsRevived = true;

    private void Awake()
    {
        player = GetComponent<Player>();
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;

        rend = GetComponent<SpriteRenderer>();
        col2D = GetComponent<Collider2D>();
    }

    // Use this for initialization
    void Start ()
    {
        healthReset = health;
        handler = PlayerHandler.instance;
        handler.alivePlayers += 1;
        originalSpawn = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
		if(isDamaged)
        {
            damagedTimer -= Time.fixedDeltaTime;

            if(canChangeColor)
            {
                rend.color = damagedColor;
                canChangeColor = false;
            }

            if (damagedTimer <= 0f)
            {
                rend.color = originalColor;
                damagedTimer = 1f;
                canChangeColor = true;
                isDamaged = false;
            }
        }

        if (health <= 0f && !playerIsKilled)
        {
            KillPlayer();
            playerIsKilled = true;
            playerIsRevived = false;
        }

        if (handler.revive && !playerIsRevived)
        {
            RevivePlayer();
            playerIsKilled = false;
            playerIsRevived = true;
        }

        if(handler.revive)
        {
            transform.position = originalSpawn;
        }
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
        isDamaged = true;
        canChangeColor = true;
    }

    void KillPlayer()
    {
        rend.enabled = false;
        col2D.enabled = false;
        handler.deadPlayers += 1;
    }

    void RevivePlayer()
    {
        rend.enabled = true;
        col2D.enabled = true;
        handler.deadPlayers -= 1;
        health = healthReset;

        transform.position = originalSpawn;
    }
}