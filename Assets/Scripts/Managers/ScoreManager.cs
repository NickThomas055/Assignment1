using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        } else {
            print(" Manager already exists");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
