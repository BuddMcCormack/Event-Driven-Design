using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{

    // This EventSystem calls subscribed listeners (door and button)
    // and passes data through without having the subscribed listeners be aware of each other.
    // Basically mitigating dependancies and making everything easier to work with from a design perspective.

    //Defined the event system so that 'event Action' may be called, pass in an int for unique door IDs.
    public static EventSystem current;

    private void Awake()
    {
        current = this;
    }

    // On collision with the door trigger matching the door id, open the door.
    public event Action <int> onDoorTriggerCollide;
    public void DoorTriggerCollide(int id)
    {
        if (onDoorTriggerCollide != null)
        {

            onDoorTriggerCollide(id);
        }

    }

    // On collision exit, close the door which matches the id of the 
    public event Action < int > onDoorTriggerExit;
    public void DoorTriggerExit(int id)
    {
        if (onDoorTriggerExit != null)
        {

            onDoorTriggerExit(id);
        }

    }
}

