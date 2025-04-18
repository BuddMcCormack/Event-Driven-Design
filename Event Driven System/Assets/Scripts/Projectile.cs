using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // If the projectile collides with the player, another projectile or the enemy, do nothing.
    // Otherwise if the projectile collides with anything else, destroy it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
         
        }

        if (other.CompareTag("Enemy"))
        {

        }

        if (!other.CompareTag("Player")
            && !other.CompareTag("Enemy")
            && !other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
