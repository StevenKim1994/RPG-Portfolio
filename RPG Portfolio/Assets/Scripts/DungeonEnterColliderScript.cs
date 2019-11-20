using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;

    [SerializeField]
    GameObject DungeonSelecter;

    private GameObject[] Managers;
    private GameObject[] UI;
    ManagerSingleton MGR = new ManagerSingleton();

    [SerializeField] GameObject[] Dbt = new GameObject[3];


    private void Start()
    {
        Managers = GameObject.FindGameObjectsWithTag("Manager");
        UI = GameObject.FindGameObjectsWithTag("UI");


        SceneMgr = GameObject.Find("SceneManager");
        DungeonSelecter = GameObject.Find("DungeonSelecter");

        if(DungeonSelecter != null)
         DungeonSelecter.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Dbt[0].transform.GetChild(0).transform.GetComponent<Text>().text = "진입가능";
            DungeonSelecter.SetActive(true); // 여기서 부터 GameManager에서 각던전 클리어정보 보고 버튼 활성화 하는 기능 추가하기. 일어나면 여기부터!!! 19.11.09
            if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Game).transform.GetComponent<GameManagerScript>().Get_FirstClearInfo() == false)
            {
                Dbt[1].transform.GetChild(0).transform.GetComponent<Text>().text = "진입불가";
                Dbt[1].transform.GetComponent<Button>().interactable = false;
            }
            else
            {
                Dbt[1].transform.GetChild(0).transform.GetComponent<Text>().text = "진입가능";
                Dbt[1].transform.GetComponent<Button>().interactable = true;
            }

            if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Game).transform.GetComponent<GameManagerScript>().Get_SecondClearInfo() == false)
            {
                Dbt[2].transform.GetChild(0).transform.GetComponent<Text>().text = "진입불가";
                Dbt[2].transform.GetComponent<Button>().interactable = false;
            }
            else
            {
                Dbt[2].transform.GetChild(0).transform.GetComponent<Text>().text = "진입가능";
                Dbt[2].transform.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void EnterFirstDungeon()
    {
        SceneMgr.GetComponent<SceneManagerScript>().EnterDungeonFirst();
    }

    public void EnterSecondDungeon()
    {
        if(Managers[(int)Enum.Managerlist.Game])
        SceneMgr.GetComponent<SceneManagerScript>().EnterDungeonSecond();
    }

    public void EnterThirdDungeon()
    {
        if (Managers[(int)Enum.Managerlist.Game])
            SceneMgr.GetComponent<SceneManagerScript>().EnterDungeonThird();
    }
    public void ExitBtn()
    {
        DungeonSelecter.SetActive(false);
    }
}
