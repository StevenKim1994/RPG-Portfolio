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
            Debug.Log("던전입장");
            DungeonSelecter.SetActive(true);
        }
    }

    public void EnterFirstDungeon()
    {
        SceneMgr.GetComponent<SceneManagerScript>().EnterDungeonFirst();
    }

    public void ExitBtn()
    {
        DungeonSelecter.SetActive(false);
    }
}
