using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBossItemBoxScript : MonoBehaviour
{
    ManagerSingleton MGR = new ManagerSingleton();
    UISingleton UI = new UISingleton();
    GameObject Canvas;
    void Start()
    {
        Canvas = UI.Get_Instance().transform.GetChild(7).gameObject;
    }

    private void OnMouseDown()
    {
        Canvas.SetActive(true);
        Canvas.transform.GetComponent<RootingScript>().SetItem();
    }


    private void OnMouseEnter()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().RootCursor();
    }

    private void OnMouseExit()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().DefaultCursor();
    }
}
