using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBossItemBoxScript : MonoBehaviour
{
    ManagerSingleton MGR = new ManagerSingleton();
    [SerializeField] GameObject ItemCanvas;
    void Start()
    {
        ItemCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        ItemCanvas.SetActive(true);
    }

    public void Exitbtn()
    {
        ItemCanvas.SetActive(false);
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
