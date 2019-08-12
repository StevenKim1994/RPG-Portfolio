using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnterColliderScript : MonoBehaviour
{
    [SerializeField]
    GameObject SceneMgr;

    [SerializeField]
    GameObject DungeonSelecter;

    private void Start()
    {
        DungeonSelecter.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "User")
        {
            Debug.Log("던전입장");
            DungeonSelecter.SetActive(true);
        }
    }

    public void ExitBtn()
    {
        DungeonSelecter.SetActive(false);
    }
}
