using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float secondsToDestroy = 0f; // Set this to something greater than zero in the inspector


    // Update is called once per frame
    void Update()
    {
        secondsToDestroy -= Time.deltaTime;

        // When the timer reaches zero or below we destroy the gameobject this component is attached to. 
        if (secondsToDestroy <= 0f)
        {
            Destroy(gameObject);
        }
    }
}