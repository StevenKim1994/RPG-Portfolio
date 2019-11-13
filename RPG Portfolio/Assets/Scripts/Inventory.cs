using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Persistence;


public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] Block = new GameObject[6]; // 0 1 부터 맨위칸
    private Item[] invenitem = new Item[6];
    
    private ManagerSingleton MGR;
    int count = 6; // 가방에 남은 공간
  
    void Start()
    {
        MGR = new ManagerSingleton();
        GoldSet();
    }

    public void GoldSet()
    {
        this.transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>().GetGold().ToString();
    }

    public void Set_Block(int num, Item input)
    {
        if (count > 0)
        {
            Block[num].GetComponent<Image>().sprite = input.image; // 인벤토리 아이템칸 아이콘 변경
            invenitem[6 - count] = input; // 해당 아이템 스크립트 내 저장


        }

        else // 가방이 가득찼을 경우
        {
            Debug.Log("Inventory is Full");

        }
        

    }

    public Item Get_Block(int num)
    {
        return invenitem[num];
    }

   



}
