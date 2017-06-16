using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    Player player;

    SpriteRenderer rend;

    public Color damagedColor;

    Color originalColor;

    float damagedTimer = 1f;

    bool canChangeColor;
    bool isDamaged;

    private void Awake()
    {
        player = GetComponent<Player>();
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
    }

    // Use this for initialization
    void Start ()
    {
		
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
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
        isDamaged = true;
        canChangeColor = true;
    }

    void KillPlayer()
    {

    }
}