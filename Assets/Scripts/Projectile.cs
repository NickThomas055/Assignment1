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
}
