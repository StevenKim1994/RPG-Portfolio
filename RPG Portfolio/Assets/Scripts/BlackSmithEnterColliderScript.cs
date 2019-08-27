using System.Collections;
using System.Collections.Generic;
using SimpleHealthBar_SpaceshipExample;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackSmithEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;
    [SerializeField]
    GameObject PlayerMgr;

    [SerializeField] private GameObject GameMgr;

    private GameObject[] Managers;

    void Start()
    {
        //Managers  = GameObject.FindGameObjectsWithTag("Manager");
        //foreach (var VARIABLE in Managers)
        //{
        //    if (VARIABLE.gameObject.transform.name == "SceneManager")
        //        SceneMgr = VARIABLE;


        //    if (VARIABLE.gameObject.transform.name == "PlayerManager")
        //        PlayerMgr = VARIABLE;

        //    if (VARIABLE.gameObject.transform.name == "GameManager")
        //        GameMgr = VARIABLE;
        //} // 왜 안될까?...

        GameMgr =GameObject.Find("GameManager");
        SceneMgr = GameObject.Find("SceneManager");
        PlayerMgr = GameObject.Find("PlayerManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("대장간 입장");
           PlayerMgr.GetComponent<PlayerManagerScripts>().Set_OldPosition(new Vector3(-19.839f,0.57050f,-18.615f));
           
            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_DEX(collision.gameObject.GetComponent<Player>().Get_DEX());
            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_INT(collision.gameObject.GetComponent<Player>().Get_INT());
            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_STR(collision.gameObject.GetComponent<Player>().Get_STR());

            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_Armor(collision.gameObject.GetComponent<Player>().Get_Armor());
            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_Damage(collision.gameObject.GetComponent<Player>().Get_Damage());
            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_HP(collision.gameObject.GetComponent<Player>().Get_HP());
            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_MP(collision.gameObject.GetComponent<Player>().Get_MP());

            PlayerMgr.GetComponent<PlayerManagerScripts>().Save_Name(collision.gameObject.GetComponent<Player>().Get_Name());
            

            SceneMgr.GetComponent<SceneManagerScript>().EnterBlackSmith();
        }
    }


}
