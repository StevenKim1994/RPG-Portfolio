// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{
    private static ManagerSingleton managerinstance = null;

    public ManagerSingleton Get_instance()
    {
        
        return managerinstance;
    }

    void Awake()
    {
        if (Get_instance())
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        managerinstance = this;
    }
   
}
