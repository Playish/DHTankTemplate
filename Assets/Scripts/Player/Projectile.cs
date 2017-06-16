using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    public GameObject impactEffect;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

        if(health != null)
        {
            health.TakeDamage(damage);
        }

        if(impactEffect != null)
        {
            SpawnImpact();
        }

        Destroy(this.gameObject);
    }

    void SpawnImpact()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        effect.transform.position = spawnPos;
        effect.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}