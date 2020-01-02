// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionNPCMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject itemblock_prefeb;
    [SerializeField] private GameObject itemblock;
    [SerializeField] private GameObject itemblock_parents;
    [SerializeField] Sprite MPIMAGE;
    [SerializeField] Sprite HPIMAGE;
    [SerializeField] GameObject WarnningGOLD;

    private GameObject input_temp;
    private List<Item> ItemList = new List<Item>();
    int value;
    int kind; // 0 이면 무기 1 이면 방어구 3 HP물약 4 MP물약
    float increase; // Item 클래스 생성자에는 물약의 회복량은 데미지로 들어감.
    string desc;
    ManagerSingleton MGR;
    UISingleton UI;

    void Start()
    {
        MGR = new ManagerSingleton();
        UI = new UISingleton();

        List<Dictionary<string, object>> data = CSVReaderScript.Read("potion_table");

        if (itemblock_parents != null)
        {
            for (var i = 0; i < data.Count; i++)
            {
                if (data[i]["Name"] != null)
                {

                    input_temp = Instantiate(itemblock_prefeb, itemblock_parents.transform);
                    input_temp.transform.GetChild(1).GetComponent<Text>().text =
                        data[i]["Name"].ToString() + "\n 가치 :" + data[i]["Value"].ToString();
                    input_temp.transform.GetChild(2).GetComponent<Text>().text =
                        "종류: " + data[i]["Kind"].ToString() + "\n" + "회복량: " + data[i]["Increase"].ToString();

                    if (data[i]["Kind"].ToString() == "HP")
                    {
                        input_temp.transform.GetChild(0).GetComponent<Image>().sprite = HPIMAGE;
                        kind = 3;
                        value = int.Parse(data[i]["Value"].ToString());
                        increase = float.Parse(data[i]["Increase"].ToString());
                        desc = data[i]["Description"].ToString();
                        Item temp = new Item(HPIMAGE, true, kind, "HP포션", value, increase, 0, 0, 1, desc);
                        ItemList.Add(temp);
                    }
                    else if (data[i]["Kind"].ToString() == "MP")
                    {
                        input_temp.transform.GetChild(0).GetComponent<Image>().sprite = MPIMAGE;
                        kind = 4;
                        value = int.Parse(data[i]["Value"].ToString());
                        increase = float.Parse(data[i]["Increase"].ToString());
                        desc = data[i]["Description"].ToString();
                        Item temp = new Item(HPIMAGE, true, kind, "MP포션", value, increase, 0, 0, 1, desc);
                        ItemList.Add(temp);
                    }
                }
            }
        }

    }

    public void ExtBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void BuyItem()
    {
        string tmp = this.gameObject.transform.GetChild(1).GetComponent<Text>().text;

        if (tmp == "회복의 물약\n 가치 :1")
        {
            if (MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetGold() >= 1)
            {
                Debug.Log("HP물약 구입");
                MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().SetGold(MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetGold() - 1); //골드 1 깍음

                MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_HPPo(MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_HPPo() + 1);
                MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().HPPoSet();
            }
            else
            {
                StartCoroutine(NoGold());

                // 경고창 띄우기
            }
        }
        else if (tmp == "마력의 물약\n 가치 :1")
        {
            if (MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetGold() >= 1)
            {
                Debug.Log("MP물약 구입");
                MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().SetGold(MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetGold() - 1); //골드 1 깍음

                MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_MPPo(MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_MPPo() + 1);
                MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().MPPoSet();
            }
            else
            {
                StartCoroutine(NoGold());
            }
        }

    }
    IEnumerator NoGold()
    {
        WarnningGOLD.SetActive(true);
        // UI on

        yield return new WaitForSeconds(1f);

        //  UI off
        WarnningGOLD.SetActive(false);
        yield break;
    }
}
