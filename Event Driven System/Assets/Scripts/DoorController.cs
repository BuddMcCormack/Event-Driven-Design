using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Serialize field so that any type of custom door object may be defined.
    // created a public int for each door's custom ID.
    [SerializeField] GameObject Door;
    public int id;

    // Subscribed entity calling the event system
    // If the player collides with a trigger add the door open function.
    // If the player exits the trigger they were colliding with, add the door close function.
    private void Start()
    {
        EventSystem.current.onDoorTriggerCollide += onDoorOpen;
        EventSystem.current.onDoorTriggerExit += onDoorClose;
    }
    
    // Door with custom ID given a new Vector3 position added to their position.
    // Allowing triggers to open the door with the corresponding ID.
    private void onDoorOpen(int id)
    {
        if (id == this.id)
        {
            Door.transform.position += new Vector3(0, 4, 0);
        }

       
    }

    // Door with custom ID given a new Vector3 position added to their position.
    // Allowing triggers to close the door with the corresponding ID.
    private void onDoorClose(int id)
    {
        if (id == this.id)
        {
            Door.transform.position += new Vector3(0, -4, 0);
        }


    }

}
