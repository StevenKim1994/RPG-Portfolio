using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject Managers;

    GameObject SceneMgr;

    private void Start()
    {
        SceneMgr = Managers.GetComponent<LoadManagersScript>().Get_Managers(0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "User")
        {
            SceneMgr.GetComponent<SceneManagerScript>().EnterCamp();
        }




    }
}
