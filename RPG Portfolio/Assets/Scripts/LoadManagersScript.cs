using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManagersScript : MonoBehaviour
{
    private GameObject Player;
    private string Job;

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
            Job = Manager[3].GetComponent<PlayerManagerScripts>().Load_Job();

            if (Job == "Pirate")
                Player = Character[0];

            else if (Job == "Barbarian")
                Player = Character[1];

            else if (Job == "Mage")
                Player = Character[2];


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
                Manager[5].GetComponent<SkillManagerScript>().Set_Player(User);
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
