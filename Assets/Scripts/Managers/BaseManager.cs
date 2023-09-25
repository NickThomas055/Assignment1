using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public static BaseManager instance;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if(BaseManager.instance == null){
            BaseManager.instance = this;
        } else {
            print(" Manager already exists");
        }
    }

  private void OnTriggerEnter(Collider other)
  {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        GetComponent<Life>().life -= 25;
  }
}
