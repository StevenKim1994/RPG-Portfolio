// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnterCampScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;

    void Start()
    {
        SceneMgr = GameObject.Find("SceneManager");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("충돌됨");
            SceneMgr.GetComponent<SceneManagerScript>().EnterCamp();
        }
    }
}
