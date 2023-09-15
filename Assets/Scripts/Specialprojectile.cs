using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialprojectile : Projectile
{
    // Start is called before the first frame update
   

    public float amplitude;
    public float frequency;
    // Update is called once per frame
    void Update()
    {
        //projectile follows a sin wave
        transform.Translate(Mathf.Sin(Time.time * frequency)* amplitude * Time.deltaTime,0, speed * Time.deltaTime);
        
    }
}
