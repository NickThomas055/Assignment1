using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy forwards
        //GetComponent<Rigidbody>().position += transform.forward * Time.deltaTime * 0.5f;
        
    }
    private void OnDestroy()
    {
        EnemyManager.instance.RemoveEnemy(this);
        Destroy(Instantiate(Resources.Load("KillEffect"), transform.position, Quaternion.identity),0.5f);
    }

    
}
