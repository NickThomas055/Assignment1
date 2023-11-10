using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    public float jumpHeight = 5.0f;

    void Update()
    {
        Walk();
        Jump();
        //when the player lands, Instantiate the DustEffect
        


    }

    void Walk()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        if (movement == Vector3.zero )
        {
           
            //play animation
            if(transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                transform.GetComponent<Animator>().Play("Idle_A");

            
        }
        else
        {
           if(transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle_A"))
                transform.GetComponent<Animator>().Play("Walk");
        }
        // Normalize the movement vector to prevent faster diagonal movement
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Move the object
        
        transform.GetComponent<Rigidbody>().AddRelativeForce(movement * speed * Time.deltaTime);
    }
    void Jump(){
        //while the player is jumping, no other animation can play

        //check if the user is holding spacebar
        if(Input.GetKey(KeyCode.Space)){
            //if the downwards velocity is greater than 0, the player is falling, so he can't jump and will fall slower
            if (transform.GetComponent<Rigidbody>().velocity.y < 0)
            {
                print("falling");
                transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
                //only play animation if the player is not already falling
                if(!transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fly"))
                    transform.gameObject.GetComponent<Animator>().Play("Fly");
            }
            //if the player is not falling, he can jump
            else if(transform.GetComponent<Rigidbody>().velocity.y == 0)
            {
                print("jumping");
                Destroy(Instantiate(Resources.Load("DustEffect"), transform.position, Quaternion.identity),0.5f);
                transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                transform.gameObject.GetComponent<Animator>().Play("Jump");
            }
        
        }
        

    }
}
