using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "User")
        {
            Debug.Log("대장간 입장");
           // SceneMgr.GetComponent<SceneManagerScript>().EnterBlackSmith();
        }
    }


}
