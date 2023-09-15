using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject fireballPrefab;
    public GameObject specialFireballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        print(transform.position);
        print("speed");
        print(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //when the pllayer presses left mouse button, the player shoots a fireball, when he presses the right mouse button, he shoots a special fireball
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("fireball");
            GameObject fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
            transform.GetComponent<Animator>().Play("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
            GameObject fireball = Instantiate(specialFireballPrefab, transform.position, transform.rotation);
            transform.GetComponent<Animator>().Play("Clicked");
        }
    //play idle animation when player is not moving


        
        
        
    }
}
