// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManagersScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] Character = new GameObject[10];

    delegate void SavePosition(Vector3 _in);
    delegate string LoadJob();
    delegate void SetPlayer(GameObject _in);
    delegate void ReturnName();
    private SetPlayer s_u;
    private LoadJob l_j;
    private SavePosition s_p;
    private GameObject Player;
    private string Job;
    private ManagerSingleton MGR = new ManagerSingleton();
    private ReturnName r_n;


    private void Awake()
    {

        l_j = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Job;
        s_u = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Skill).GetComponent<SkillManagerScript>().Set_Player;
        s_p = MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Set_OldPosition;

    }

    private void Start()
    {

            Job = l_j();

            if (Job == "Pirate")
                Player = Character[(int)Enum.Playerlist.Pirate];

            else if (Job == "Barbarian")
                Player = Character[(int)Enum.Playerlist.Barbarian];

            else if (Job == "Wizard")
                Player = Character[(int)Enum.Playerlist.Wizard];


            if (SceneManager.GetActiveScene().name == "InBlackSmithScene")
            {

                GameObject User = Instantiate(Player);
                User.gameObject.name = "Player";
                User.gameObject.tag = "Player";
                User.gameObject.name += "(" + Job.ToString() + ")";
                User.transform.position = new Vector3(8.35f, 3.858f, 1.76f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                GameObject weaponnpc = GameObject.FindWithTag("WeaponNPC");
               
            }

            else if (SceneManager.GetActiveScene().name == "FirstDungeonScene")
            {
                GameObject User = Instantiate(Player);
                User.gameObject.name = "Player";
                User.gameObject.tag = "Player";
                User.gameObject.name += "(" + Job.ToString() + ")";
                User.transform.position = new Vector3(41.8f,1.0f,-10.3f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if (SceneManager.GetActiveScene().name == "SecondDungeonScene")
            {
                GameObject User = Instantiate(Player);
                User.gameObject.name = "Player";
                User.gameObject.tag = "Player";
                User.gameObject.name += "(" + Job.ToString() + ")";
                User.transform.position = new Vector3(6.1f, 1f, 152.7f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if (SceneManager.GetActiveScene().name == "InChurchScene")
            {
                GameObject User = Instantiate(Player);
                User.gameObject.name = "Player";
                User.gameObject.tag = "Player";
            User.gameObject.name += "(" + Job.ToString() + ")";
            User.transform.position = new Vector3(0.6f, 1.68f, 7.88f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if (SceneManager.GetActiveScene().name == "ThirdDungeonScene")
            {
            GameObject User = Instantiate(Player);
            User.gameObject.name = "Player";
            User.gameObject.tag = "Player";
            User.gameObject.name += "(" + Job.ToString() + ")";
            User.transform.position = new Vector3(1.5f, 1.83f, 15.28f);
            User.transform.GetComponent<Rigidbody>().isKinematic = false;
            User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if (SceneManager.GetActiveScene().name == "CampScene")
            {
                GameObject User = Instantiate(Player);
                User.gameObject.name = "Player";
                User.gameObject.tag = "Player";
                User.gameObject.name += "(" + Job.ToString() + ")";
                User.transform.position = new Vector3(14.04f, 3f, 10.15f);
                User.transform.GetComponent<Rigidbody>().isKinematic = false;
                User.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).GetComponent<InventoryManagerScript>().SetTitleName(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Load_Name());

    }

}
