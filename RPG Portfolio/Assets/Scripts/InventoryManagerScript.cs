using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManagerScript : MonoBehaviour
{
  
   
    [SerializeField]
    GameObject Inventory;
    [SerializeField]
    GameObject InvenName;
    
    private void Start()
    {
      
      
    }
    public void ExitInventory()
    {
        Debug.Log("Inventory Close");
        Inventory.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
    }

    public void SetTitleName(string _in)
    {
        InvenName.GetComponent<Text>().text = _in+ "의 인벤토리";
    }
    
    
}
