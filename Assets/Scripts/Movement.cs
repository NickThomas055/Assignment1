using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        if (movement == Vector3.zero )
        {
            print("idle");
            //play animation
            if(transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                transform.GetComponent<Animator>().Play("Idle_A");

            
        }
        else
        {
            print("moving");
            transform.GetComponent<Animator>().Play("Walk");
        }
        // Normalize the movement vector to prevent faster diagonal movement
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Move the object
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
