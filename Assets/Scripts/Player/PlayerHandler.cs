using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler instance;

    public int alivePlayers;
    public int deadPlayers = 0;

    public bool revive = false;

    float startOverTimer = 2;
    

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        
	}
	
	// Update is called once per frame
	void Update()
    {
		if(deadPlayers == alivePlayers - alivePlayers + 1)
        {
            startOverTimer -= Time.deltaTime;

            if(startOverTimer <= 0f)
            {
                revive = true;
                startOverTimer = 2;
            }
        }

        if(deadPlayers == 0)
        {
            revive = false;
        }
	}
}
