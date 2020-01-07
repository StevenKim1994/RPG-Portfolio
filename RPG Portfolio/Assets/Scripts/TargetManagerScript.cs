// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TargetManagerScript : MonoBehaviour
{
    [SerializeField] GameObject TargetUI;
    private GameObject Target;
    private ManagerSingleton MGR;

    private bool notSelectScene;
    // Start is called before the first frame update
    void Start()
    {
        MGR = new ManagerSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        if (notSelectScene == false)
        {
            TargetUI = GameObject.Find("TargetFrame");
           
            if(TargetUI != null)
            {
                notSelectScene = true;
            }
        }

        if (SceneManager.GetActiveScene().name != "CharacterSelectScene")
        {
            if (MGR.Get_instance().transform.GetChild((int) Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target() == null)
            {
                if(TargetUI)
                    TargetUI.SetActive(false);
            }
            // 타겟 없으면 TargetUI off
            else
            {
                TargetUI.SetActive(true);
            }
            /*else if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target() != null)
            {
                Target = MGR.Get_instance().transform.GetChild((int))
                TargetUI.SetActive(true);
                
                if(SceneManager.GetActiveScene().name == "FirstDungeonScene")
                {
                    TargetUI.gameObject.transform.GetComponent<Image>().fillAmount = 
                }
                else if (SceneManager.GetActiveScene().name == "SecondDungeonScene")
                {

                }
                else if (SceneManager.GetActiveScene().name == "ThirdDungeonScene")
                {

                }
            }*/ // 타겟 있으면 TargetUI on
        }
    }
}
