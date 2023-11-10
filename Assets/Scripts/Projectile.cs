using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the fireball prefab
// It is responsible for moving the fireball forward
// and destroying it after a certain amount of time

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
            other.GetComponent<Life>().life -= 1;
            Destroy(gameObject);
            Destroy(Instantiate(Resources.Load("ImpactEffect"), transform.position, Quaternion.identity),0.5f);
        }
    }
}
