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
        WaveManager.instance.waves.Add(this);
        InvokeRepeating("Spawn", 0, 1);
        Invoke("EndSpawner", 10);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void EndSpawner(){
        WaveManager.instance.waves.Remove(this);
        Destroy(this.gameObject);
    }

    void Spawn(){
        // Generate a random position within a certain range of the spawner
        Vector3 position = new Vector3(transform.position.x + Random.Range(-3 , 3), transform.position.y, transform.position.z + Random.Range(-3, 3));

        

        // Spawn an enemy at that position
        GameObject enemy = Instantiate(enemyPrefab, position, transform.rotation);
        Destroy(enemy, 100);
    }
}
