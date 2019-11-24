// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    ManagerSingleton MGR = new ManagerSingleton();

    public void Retrying()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Scene).transform.GetComponent<SceneManagerScript>().EnterStartChurch();
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(100f);
    }
}
