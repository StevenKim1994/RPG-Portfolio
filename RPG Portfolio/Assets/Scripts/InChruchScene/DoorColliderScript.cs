using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderScript : MonoBehaviour
{
    [SerializeField] private GameObject SceneMgr;
    // Start is called before the first frame update
    void Start()
    {
        SceneMgr = GameObject.Find("SceneManager");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            SceneMgr.GetComponent<SceneManagerScript>().EnterCamp();
    }
}
