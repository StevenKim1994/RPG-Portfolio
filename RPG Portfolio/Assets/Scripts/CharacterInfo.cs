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
}
