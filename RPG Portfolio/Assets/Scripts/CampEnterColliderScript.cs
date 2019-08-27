using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampEnterColliderScript : MonoBehaviour
{
    delegate void EnterCamp();

    private EnterCamp entercamp;
    private ManagerSingleton MGR = new ManagerSingleton();
    private void Start()
    {
        entercamp = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Scene).GetComponent<SceneManagerScript>().EnterCamp;
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           

            entercamp();
        }




    }
}
