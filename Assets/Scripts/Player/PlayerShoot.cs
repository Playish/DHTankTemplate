using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayishInput playishInput;

    public GameObject projectile;
    public Transform projectileSpawn;

    public GameObject shootEffect;

    public float projectileSpeed;

    public float fireRate = 1f;
    float fireRateReset;

    // Is called before Start
    private void Awake()
    {
        playishInput = GetComponent<PlayishInput>();
    }

    // Is only called at the start of the game
    void Start()
    {
        fireRateReset = fireRate;
        fireRate = 0f; // Makes sure the player can shoot at the start of the game
	}
	
	// Update is called once per frame
	void Update()
    {
        fireRate -= Time.deltaTime;

		if(Input.GetKey(KeyCode.F) && fireRate <= 0f)
        {
            FireProjectile();

            if(shootEffect != null)
            {
                SpawnShootEffect();
            }

            fireRate = fireRateReset;
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

    void SpawnShootEffect()
    {
        GameObject shot = (GameObject)Instantiate(shootEffect);
        Vector3 spawnPos = new Vector3(projectileSpawn.position.x, projectileSpawn.position.y, projectileSpawn.position.z);
        shot.transform.position = spawnPos;
        shot.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
                                                      transform.localEulerAngles.y,
                                                      transform.localEulerAngles.z);
    }
}