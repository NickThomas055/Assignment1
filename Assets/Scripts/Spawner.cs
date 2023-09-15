using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the spawner object
// It is responsible for spawning enemies at random locations
// within a certain range

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    void Start()
    {
        InvokeRepeating("Spawn", 0, 1);
        Invoke("CancelInvoke", 10);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void Spawn(){
        // Generate a random position within a certain range of the spawner
        Vector3 position = new Vector3(transform.position.x + Random.Range(-3 , 3), transform.position.y, transform.position.z + Random.Range(-3, 3));

        

        // Spawn an enemy at that position
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        Destroy(enemy, 5);
    }
}
