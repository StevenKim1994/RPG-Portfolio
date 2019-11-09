using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;

    [SerializeField]
    GameObject DungeonSelecter;

    private GameObject[] Managers;
    private GameObject[] UI;

    
    private void Start()
    {
        Managers = GameObject.FindGameObjectsWithTag("Manager");
        UI = GameObject.FindGameObjectsWithTag("UI");
        //foreach (var VARIABLE in Managers)
        //{
        //    if (VARIABLE.gameObject.transform.name == "SceneManager")
        //    {
        //        SceneMgr = VARIABLE;
        //    }
        //}

        //foreach (var VARIABLE in UI)
        //{
        //    if (VARIABLE.gameObject.transform.name == "DungeonSelecter")
        //    {
        //        DungeonSelecter = VARIABLE;
        //    }
        //}

        SceneMgr = GameObject.Find("SceneManager");
        DungeonSelecter = GameObject.Find("DungeonSelecter");

        if(DungeonSelecter != null)
         DungeonSelecter.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
         
            DungeonSelecter.SetActive(true); // 여기서 부터 GameManager에서 각던전 클리어정보 보고 버튼 활성화 하는 기능 추가하기. 일어나면 여기부터!!! 19.11.09
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
    public void ExitBtn()
    {
        DungeonSelecter.SetActive(false);
    }
}
