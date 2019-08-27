using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManagersScript : MonoBehaviour
{

    private GameObject Player;
    private string Job;
    private ManagerSingleton Mgrs = new ManagerSingleton();
    [SerializeField]
    GameObject[] Character = new GameObject[10];

    private GameObject Manager;
 

    private void Awake()
    {
        // 싱글톤 으로 각 매니저 할당받기 추가해야함..

    }

    private void Start()
    {

        Job = Manager[(int)Enum.Managerlist.Player].GetComponent<PlayerManagerScripts>().Load_Job();

            if (Job == "Pirate")
                Player = Character[(int)Enum.Playerlist.Pirate];

            else if (Job == "Barbarian")
                Player = Character[(int)Enum.Playerlist.Barbarian];

            else if (Job == "Wizard")
                Player = Character[(int)Enum.Playerlist.Wizard];


            if (SceneManager.GetActiveScene().name == "InBlackSmithScene")
            {
                
                Instantiate(Player);
                GameObject User = GameObject.Find("Player(" + Job + ")(Clone)");

                User.gameObject.tag = "Player";
                User.transform.position = new Vector3(8.35f, 3.858f, 1.76f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                GameObject weaponnpc = GameObject.FindWithTag("WeaponNPC");
                weaponnpc.GetComponent<NPC>().Set_Player(User);
                Manager[(int)Enum.Managerlist.Skill].GetComponent<SkillManagerScript>().Set_Player(User);
            }

            else if (SceneManager.GetActiveScene().name == "FirstDungeonScene")
            {
                Instantiate(Player);
                 GameObject User = GameObject.Find("Player(" + Job + ")(Clone)");

                User.gameObject.tag = "Player";
                User.transform.position = new Vector3(41.8f,1.0f,-10.3f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if (SceneManager.GetActiveScene().name == "InChurchScene")
            {
                Instantiate(Player);
                GameObject User = GameObject.Find("Player("+Job + ")(Clone)");

                User.gameObject.tag = "Player";
                User.transform.position = new Vector3(0.6f, 1.68f, 7.88f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if (SceneManager.GetActiveScene().name == "CampScene")
            {
                Instantiate(Player);
                GameObject User = GameObject.Find("Player(" + Job + ")(Clone)");

                User.gameObject.tag = "Player";
                User.transform.position = new Vector3(14.04f, 0.5f, 10.15f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    public GameObject Get_Managers(int _in)
    {
        return Manager[_in];
    }
}
