using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;
    // Start is called before the first frame update
    private void GivePoints(){
        ScoreManager.instance.score += amount;
    }
    private void Awake()
    {
        var life = GetComponent<Life>();
        life.OnDeath.AddListener(GivePoints);
    }
}
