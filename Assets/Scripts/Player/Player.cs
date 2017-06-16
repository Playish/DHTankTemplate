using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerHandler handler;

    SpriteRenderer rend;
    Collider2D col2D;

    Vector3 originalSpawn;

    PlayerHealth health;

    bool isDead = false;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        col2D = GetComponent<Collider2D>();
        health = GetComponent<PlayerHealth>();
    }

    // Use this for initialization
    void Start ()
    {
        handler = PlayerHandler.instance; // Gets reference to the PlayerHandler in the scene
        originalSpawn = transform.position;
	}
}