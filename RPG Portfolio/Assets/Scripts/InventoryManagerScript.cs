using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerScript : MonoBehaviour
{
    [SerializeField]
    GameObject Inventory;
    public void ExitInventory()
    {
        Debug.Log("Inventory Close");
        Inventory.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
    }
}
