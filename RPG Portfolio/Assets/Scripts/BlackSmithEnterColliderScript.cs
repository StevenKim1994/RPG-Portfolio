using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;
    [SerializeField]
    GameObject PlayerMgr;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "User")
        {
            Debug.Log("대장간 입장");
           
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
