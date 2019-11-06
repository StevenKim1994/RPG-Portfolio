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

    [SerializeField] private GameObject Root;


    private int Gold;

    
    private void Start()
    {
        Gold = 0;

    }
    public void ExitInventory()
    {
        Debug.Log("Inventory Close");
        Inventory.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);

        //골드 현상황 변경하는 Delegate 함수 추가하기 ... 19.11.06
    }

    public void SetTitleName(string _in)
    {
        InvenName.GetComponent<Text>().text = _in+ "의 인벤토리";
    }

    public void OpenRoot()
    {
        Root.gameObject.SetActive(true);
    }

    public void ExitRoot()
    {
        Root.gameObject.SetActive(false);
    }

    public void SetGold(int _in)
    {
        this.Gold = _in;
    }

    public int GetGold()
    {
        return this.Gold;
    }

}
