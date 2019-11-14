using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buffbar : MonoBehaviour
{
    [SerializeField]
    GameObject[] Buff = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Buff[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
