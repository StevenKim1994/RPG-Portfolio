﻿// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class NPC : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    //GameObject PotionNPCMenu;
    //GameObject ArmorNPCMenu;
    GameObject NPCMenu;
    [SerializeField]
    private GameObject PlayerInventory;

    [SerializeField]
    GameObject Goal;
    public float WalkSpeed;
    NavMeshAgent Nav;
    Vector3 StartPos;
    Animator Anim;
    bool CouroutineCheck = false;
    bool Animcheck = false;
    private ManagerSingleton MGR = new ManagerSingleton();
    private UISingleton UI = new UISingleton();

    delegate string LoadJob();

    private LoadJob l_j;
    


  
    void Start()
    {
        l_j = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Job;

        if (Player == null)
            Player = GameObject.FindGameObjectWithTag("Player");

        Anim = this.GetComponent<Animator>();


        if (SceneManager.GetActiveScene().name == "CampScene")
        {
            Nav = this.GetComponent<NavMeshAgent>();
            Nav.speed = WalkSpeed;
            Nav.enabled = false; // 코루틴으로 시간이 지나면 이동하기...
        }


        StartPos = this.GetComponent<Transform>().position;


        NPCMenu = GameObject.Find(this.gameObject.transform.name.ToString() + "Menu");
        NPCMenu.SetActive(false);

        if (NPCMenu != null)
            NPCMenu.SetActive(false);
    }

   
    void Update()
    {
        if (CouroutineCheck == false)
        {
            if (SceneManager.GetActiveScene().name == "CampScene")
                StartCoroutine("Wait");
        }
        float distance = Vector3.Distance(Player.transform.position, this.gameObject.transform.position);
        if(distance >= 10)
        { 
           

            if(NPCMenu != null)
            NPCMenu.SetActive(false);
        }

    }

    IEnumerator Wait()
    {
        
        CouroutineCheck = true;
        Nav.enabled = true;
        Nav.SetDestination(Goal.GetComponent<Transform>().position);
        Anim.SetBool("Walk", true);
        
        yield return new WaitForSeconds(3f); // 움직이는데 걸리는시간
 
  
        Anim.SetBool("Walk", false);
        yield return new WaitForSeconds(10f);
        Nav.ResetPath();
        Nav.SetDestination(StartPos);
    
   
        Anim.SetBool("Walk", true);
        yield return new WaitForSeconds(3f); // 움직이는데 걸리는 시간

        Anim.SetBool("Walk", false);
        yield return new WaitForSeconds(10f);
        CouroutineCheck = false;
    }

    void OnMouseDown()
    {
       
        float distance = Vector3.Distance(Player.transform.position, this.gameObject.transform.position);
       
        if(this.gameObject.tag == "PotionNPC")
        {
           
            if (distance <= 5f)
            {
                OnMenu();
            }
        }

        else if(this.gameObject.tag == "ArmorNPC")
        {
            if (distance <= 5f)
            {
                OnMenu();
            }
        }

        else if (this.gameObject.tag == "WeaponNPC")
        {
            if (distance <= 5f)
            {
                OnMenu();
            }
        }
    }



    void OnMenu()
    {
        NPCMenu.SetActive(true);
        UI.Get_Instance().transform.GetChild(5).transform.gameObject.SetActive(true);
    }

    public void Set_Player(GameObject _in)
    {
        Player = _in;
    }


}
