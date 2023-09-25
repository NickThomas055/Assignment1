using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyManager instance;
    public List<GameObject> enemies = new List<GameObject>();
    public UnityEvent OnChanged;
    void Awake()
    {
        if(instance == null){
            instance = this;
        } else {
            print(" Manager already exists");
        }
    }

    // Update is called once per frame
    public void AddEnemy(Enemy enemy){
        enemies.Add(enemy.gameObject);
        OnChanged.Invoke();
    }
    public void RemoveEnemy(Enemy enemy){
        enemies.Remove(enemy.gameObject);
        OnChanged.Invoke();
    }
}
