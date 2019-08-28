using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorNPCMenuScript : MonoBehaviour
{
    GameObject Player;

    private ManagerSingleton MGR = new ManagerSingleton();

    delegate string LoadJob();

    private LoadJob l_j;

    void Awake()
    {
        l_j = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Job;
    }
    void Start()
    { 
             Player = GameObject.Find("Player("+ l_j() +")(Clone)");
            this.gameObject.SetActive(false);
    }
        
    public void ExitBtn()
    {
        this.gameObject.SetActive(false);
    }
    
}
