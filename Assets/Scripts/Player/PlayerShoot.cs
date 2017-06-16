using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayishInput playishInput;

    public GameObject projectile;
    public Transform projectileSpawn;

    public float projectileSpeed;

    private void Awake()
    {
        playishInput = GetComponent<PlayishInput>();
    }

    void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.F))
        {
            FireProjectile();
        }
	}

    void FireProjectile()
    {
        GameObject shot = (GameObject)Instantiate(projectile);
        Vector3 spawnPos = new Vector3(projectileSpawn.position.x, projectileSpawn.position.y, projectileSpawn.position.z);
        shot.transform.position = spawnPos;
        shot.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                      transform.localEulerAngles.y,
                                                      transform.localEulerAngles.z);

        Rigidbody2D projectileRb = shot.GetComponent<Rigidbody2D>();

        projectileRb.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
    }
}