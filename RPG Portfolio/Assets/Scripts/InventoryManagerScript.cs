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
    [SerializeField]
    GameObject Tooltip;
    [SerializeField]
    GameObject Bank;

    [SerializeField] private GameObject Root;


    private int Gold;


    private void Start()
    {
        Tooltip.SetActive(false);
        Gold = 10000;

    }
    public void ExitInventory()
    {
        Debug.Log("Inventory Close");
        Inventory.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
        Inventory.transform.GetComponent<Inventory>().GoldSet();


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

    public GameObject GetInven()
    {
        return Inventory;
    }

    public void OpenBank()
    {
        Bank.SetActive(true);
    }

    public void CloseBank()
    {
        Bank.SetActive(false);
    }
}
