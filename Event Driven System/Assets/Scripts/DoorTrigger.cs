using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    // Define an int for custom trigger ID's
    public int id;

    // If anything collides with the trigger, open the door.
    private void OnTriggerEnter(Collider other)
    {
        EventSystem.current.DoorTriggerCollide(id);
    }

    // If the thing which triggered the door to open exits the trigger, close the door.
    private void OnTriggerExit(Collider other)
    {
        EventSystem.current.DoorTriggerExit(id);
    }
}
