using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float damage;

    public float explosionRadius = 3f;
    public float explosionPower = 5f;

    public GameObject mineExplosionEffect;

    bool isTriggered = false;

    // Is only called at the start of the game
    void Start()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            if(health != null)
            {
                health.TakeDamage(damage);
            }

            if(mineExplosionEffect != null)
            {
                SpawnExplosionEffect();
            }

            Destroy(this.gameObject);
        }
    }

    void SpawnExplosionEffect()
    {
        GameObject shot = (GameObject)Instantiate(mineExplosionEffect);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        shot.transform.position = spawnPos;
        shot.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}