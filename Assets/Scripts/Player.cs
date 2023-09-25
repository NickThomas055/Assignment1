using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject projectilePrefab;
    public GameObject specialprojectilePrefab;

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
        //when the pllayer presses left mouse button, the player shoots a projectile, when he presses the right mouse button, he shoots a special projectile
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("projectile");
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            transform.GetComponent<Animator>().Play("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
            GameObject projectile = Instantiate(specialprojectilePrefab, transform.position, transform.rotation);
            transform.GetComponent<Animator>().Play("Clicked");
        }
    //play idle animation when player is not moving
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                GetComponent<Life>().life -= 1;
            }
        }

        
        
        
    }
}
