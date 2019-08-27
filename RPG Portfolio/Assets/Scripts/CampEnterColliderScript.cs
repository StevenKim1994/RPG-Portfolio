using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject Managers;

    GameObject SceneMgr;

    private GameObject GameMgr;
    private void Start()
    {
        SceneMgr = Managers.GetComponent<LoadManagersScript>().Get_Managers(0);
        GameMgr = Managers.GetComponent<LoadManagersScript>().Get_Managers(6);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameMgr.GetComponent<GameManagerScript>().Set_OldScene(SceneManager.GetActiveScene().ToString());
           
            SceneMgr.GetComponent<SceneManagerScript>().EnterCamp();
        }




    }
}
