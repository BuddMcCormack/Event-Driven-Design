using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Define a rigidbody to use, and a standard speed,
    // as well as define the player input to be referenced.
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float Speed = 5.0f;
    private Vector3 playerInput;

    void Update()
    {
        GetInput();
        Looking();
       
    }

    private void FixedUpdate()
    {
        Move();
    }

    // References the player input for movement.
    void GetInput()
    {

        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

    }


    // Makes it so the player will continue moving in the direction they are facing
    // instead of being locked back to the original position of 0.
    void Looking()
    {
        if (playerInput != Vector3.zero)
        {

            var relativeDistance = (transform.position + playerInput - transform.position);
            var rotation = Quaternion.LookRotation(relativeDistance, Vector3.up);
            transform.rotation = rotation;
        }

    }

    // Moves the player forward.
    void Move()
    {

        rb.MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);

    }

}
