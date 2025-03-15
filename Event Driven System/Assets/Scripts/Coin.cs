using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Define a new event from our event system which defines what happens when a coin is collected.
    public static event Action onCollected;
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time, 0);
    }

    // If anything collides with a coin, pickup the coin.
    private void OnTriggerEnter(Collider other)
    {
        onCollected?.Invoke();
        Destroy(gameObject);
    }
}
