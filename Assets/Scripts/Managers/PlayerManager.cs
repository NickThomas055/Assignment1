using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerManager instance;
    void Awake()
    {
        if(instance == null){
            instance = this;
        } else {
            print(" Manager already exists");

    }}

    // Update is called once per frame
    void Update()
    {
        
    }
}
