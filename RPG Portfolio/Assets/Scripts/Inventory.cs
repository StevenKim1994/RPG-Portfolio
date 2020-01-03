// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] Block = new GameObject[6]; // 0 1 부터 맨위칸
    private List<Item> InvenItem = new List<Item>();
    private Sprite temp;
    private ManagerSingleton MGR;
    int count = 6; // 가방에 남은 공간

    void Start()
    {
        MGR = new ManagerSingleton();
        GoldSet();
        temp = Block[0].GetComponent<Image>().sprite;
    }

    public void GoldSet()
    {
        this.transform.GetChild(8).transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>().GetGold().ToString();
    }

    public void Set_Block(Item input)
    {



            if (InvenItem.Count < 6)
            {
                InvenItem.Add(input);
                count = count - InvenItem.Count;

             for(int i =0; i<6; i++)
             {
                Block[i].transform.GetComponent<Image>().sprite = temp; // 사라진거 있을수 있으니 먼저 모든 이미지 비어있는 이미지로.
             }

             for(int i =0; i<InvenItem.Count; i++)
            {
                Block[i].transform.GetComponent<Image>().sprite = InvenItem[i].image; // 다시 불러오기
            }
            }


            else // 가방이 가득찼을 경우
            {
                Debug.Log("Inventory is Full");

            }


    }

    public int Get_InventorySpace()
    {
        return InvenItem.Count;
    }
    public Item Get_Block(int num)
    {
    
            return InvenItem[num];

    }

    public int InventoryCount()
    {
        return count;
    }

    public void Del_Block(int num)
    {
        InvenItem.RemoveAt(num);


    }


    public void Reflsh()
    {
        for (int i = 0; i < InvenItem.Count; i++)
        {
            Debug.Log(InvenItem[i].name);
        }
        for (int i = 0; i < 6; i++)
        {
            Block[i].transform.GetComponent<Image>().sprite = temp; // 사라진거 있을수 있으니 먼저 모든 이미지 비어있는 이미지로.
        }

        for (int i = 0; i < InvenItem.Count; i++)
        {
            Block[i].transform.GetComponent<Image>().sprite = InvenItem[i].image; // 다시 불러오기
        }
    }



}
