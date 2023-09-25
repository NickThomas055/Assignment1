using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;

    [SerializeField] private Life baseLife;
    [SerializeField] private Life playerLife;
    void Awake()
    {
       
        if(instance == null){
            instance = this;
        } else {
            print(" Manager already exists");
        }
        
    }
    void Start(){
        
        playerLife.OnDeath.AddListener(OnPlayerOrBaseDied);
        baseLife.OnDeath.AddListener(OnPlayerOrBaseDied);
        EnemyManager.instance.OnChanged.AddListener(checkWinCondition);
        WaveManager.instance.OnChanged.AddListener(checkWinCondition);
        
    }

    // Update is called once per frame

    private void OnPlayerOrBaseDied(){
        print("You Lose and your score is: "+ ScoreManager.instance.score);
        SceneManager.LoadScene("Lose");
    }
    void checkWinCondition(){
        if(WaveManager.instance.waves.Count <= 0 && EnemyManager.instance.enemies.Count <= 0){
            print("You Win and your score is: "+ ScoreManager.instance.score);
            SceneManager.LoadScene("Win");
        }
    }
}
