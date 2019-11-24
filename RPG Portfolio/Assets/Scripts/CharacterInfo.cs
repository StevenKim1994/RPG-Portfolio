// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] GameObject CharacterInfoCanvas;
    [SerializeField] Text nicknametext;
    [SerializeField] Text jobtext;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject armor;
    [SerializeField] GameObject statbox;


    ManagerSingleton MGR = new ManagerSingleton();

    public void UpdateData() // 정보창 열떄 마다 호출해야댐
    {
       nicknametext.text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Name();
        jobtext.text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Job();

        if(armor.transform.GetComponent<Item>().image != null)
            armor.transform.GetComponent<Image>().sprite = armor.transform.GetComponent<Item>().image;

        statbox.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Damage().ToString();
        statbox.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Armor().ToString();
        statbox.transform.GetChild(2).transform.GetChild(0).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP().ToString();
        statbox.transform.GetChild(3).transform.GetChild(0).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP().ToString();
    }

    public void ExitBtn()
    {
        CharacterInfoCanvas.SetActive(false);
    }

    public void OpenBtn()
    {
        CharacterInfoCanvas.SetActive(true);
        UpdateData();
    }

    public void clickwepaon(int _num)
    {
        if(weapon.transform.GetComponent<Item>().data == null)
        {
            if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num).kind == 2)// 아이템의 종류가 2 (무기류) 이라면
            {
                weapon.transform.GetComponent<Item>().set_data(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num));
                weapon.transform.GetComponent<Image>().sprite = armor.transform.GetComponent<Item>().image;

                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Del_Block(_num);
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Reflsh();

            }
        }

        else
        {
            if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num).kind == 2)// 아이템의 종류가 2 (무기류) 이라면
            {
                Item temp = weapon.gameObject.transform.GetComponent<Item>().get_data();
                weapon.transform.GetComponent<Item>().set_data(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num));
                weapon.transform.GetComponent<Image>().sprite = weapon.transform.GetComponent<Item>().image;
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Del_Block(_num);
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Set_Block(temp);
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Reflsh();

            }
        }
        statbox.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Armor().ToString() + "(+" + armor.transform.GetComponent<Item>().get_data().damage + ")";
    }

    public void clickarmor(int _num)
    {
        if (armor.transform.GetComponent<Item>().data== null)
        {

            if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num).kind == 1)// 아이템의 종류가 1 (방어구) 이라면
            {
                armor.transform.GetComponent<Item>().set_data(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num));
                armor.transform.GetComponent<Image>().sprite = armor.transform.GetComponent<Item>().image;

                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Del_Block(_num);
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Reflsh();

            }
        }

        else
        {

            if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num).kind == 1)// 아이템의 종류가 1 (방어구) 이라면
            {
                Item temp = armor.gameObject.transform.GetComponent<Item>().get_data();
               armor.transform.GetComponent<Item>().set_data(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(_num));
                armor.transform.GetComponent<Image>().sprite = armor.transform.GetComponent<Item>().image;
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Del_Block(_num);
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Set_Block(temp);
                MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Reflsh();
            }
        }
        statbox.transform.GetChild(1).transform.GetChild(0).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Armor().ToString() + "(+" + armor.transform.GetComponent<Item>().get_data().armor + ")";
    }

}
