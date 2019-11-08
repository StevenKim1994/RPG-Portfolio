using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Persistence;

public class Inventory : MonoBehaviour
{
    float distance = 10f;
  
    
    private ManagerSingleton MGR;
    public void OnMouseDrag()
    {
        Debug.Log("Draging");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.gameObject.transform.position = objPosition;
    }

    void Start()
    {
        MGR = new ManagerSingleton();
        GoldSet();
    }

    public void GoldSet()
    {
        this.transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>().GetGold().ToString();
    }

}
