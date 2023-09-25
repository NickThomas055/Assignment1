using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static WaveManager instance;
    public List<Spawner> waves ;
    public UnityEvent OnChanged;    
    private void Awake()
    {
        if(WaveManager.instance == null){
            WaveManager.instance = this;
        } else {
            print(" Manager already exists");
        }
    }
    public void RemoveWave(Spawner wave){
        waves.Remove(wave);
        OnChanged.Invoke();
    }
    public void AddWave(Spawner wave){
        waves.Add(wave);
        OnChanged.Invoke();
    }
    // Update is called once per frame
   
}
