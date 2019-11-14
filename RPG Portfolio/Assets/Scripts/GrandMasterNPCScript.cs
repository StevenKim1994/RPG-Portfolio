using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandMasterNPCScript: MonoBehaviour
{
    ManagerSingleton MGR = new ManagerSingleton();
    void OnMouseDown()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).gameObject.transform.GetComponent<InventoryManagerScript>().OpenBank();

    }
}
