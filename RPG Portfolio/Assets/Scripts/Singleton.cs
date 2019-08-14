using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton Instance;
    public static Singleton GetInstance()
    {
        if(!Instance)
        {
            Instance = (Singleton)GameObject.FindObjectOfType(typeof(Singleton));
            
            if(!Instance)
            {
                Debug.Log("싱글톤에러");
            }
          
        }
        return Instance;
    }
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
