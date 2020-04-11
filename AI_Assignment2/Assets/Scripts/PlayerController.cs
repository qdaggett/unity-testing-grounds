using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quinn Daggett - 100618734   
// 2020-01-29

public class PlayerController : MonoBehaviour {

    private Vector3 movementVector;
    private float playerSpeed = 6.0f; // Change to make player faster/slower
	
	// Update is called once per frame
	void Update () 
    {
        // Updating movement vector based on WASD input
		if(Input.GetKey(KeyCode.W))
        {
            movementVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementVector += -transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector += -transform.right;
        }

        // E to use doors
        if(Input.GetKeyDown(KeyCode.E))
        {
            HandleUse();
        }

        HandleMovement();

        // Quit button
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Function for handling player movement
    void HandleMovement()
    {
        movementVector = movementVector * playerSpeed * Time.deltaTime;

        transform.position += movementVector; // Modifying transform directly as Translate is broken when using .forward and .right
    }

    // Function for handling using doors
    void HandleUse()
    {
        RaycastHit useRay; // Store hit information here
            
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out useRay, 2.0f)) // Fire ray in front of player
        {
            if(useRay.collider.CompareTag("Door")) // If the ray hits a door
            {
                useRay.collider.gameObject.GetComponent<Door>().UseDoor(); // Call use function in door script
            }
        }

    }
}
