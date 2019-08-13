using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManagersScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] Character = new GameObject[10];
    [SerializeField]
    GameObject[] Manager = new GameObject[10]; // 0 : Scene 
                                               // 1 : Inventory
                                               // 2 : Data
                                               // 3 : Player
                                               // 4 : Interface
                                               // 5 : Skill
                                               // 6 : Game

    private void Awake()
    {
        Manager[0] = GameObject.Find("SceneManager");
        Manager[1] = GameObject.Find("InventoryManager");
        Manager[2] = GameObject.Find("DataManager");
        Manager[3] = GameObject.Find("PlayerManager");
        Manager[4] = GameObject.Find("InterfaceManager");
        Manager[5] = GameObject.Find("SkillManager");
        Manager[6] = GameObject.Find("GameManager");
    }

    private void Start()
    {
      //if (Manager[3].GetComponent<PlayerManagerScripts>().Load_Name() == "Pirate") // 전 씬에서 저장한 캐릭터의 이름이 Pirate이면 해적 오브젝트 생성
      //{
            if (SceneManager.GetActiveScene().name == "InBlackSmithScene")
            {
                GameObject LoadPOS = GameObject.FindGameObjectWithTag("Load_Point");
                Instantiate(Character[0], LoadPOS.transform);
                GameObject User = GameObject.Find("Player(Clone)");
                User.gameObject.tag = "User";

            }

     // }
     
    }
}
