using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManagerScript : MonoBehaviour
{
    [SerializeField] GameObject TargetUI;
    ManagerSingleton MGR = new ManagerSingleton();
    // Start is called before the first frame update
    void Start()
    {
      if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target() == null)
        {
            TargetUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target() == null)
        {
            TargetUI.SetActive(false);
        }
        else
        {
            TargetUI.SetActive(true);
            // 현재 던전1만 처리댐.
            TargetUI.transform.GetChild(2).transform.GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().gameObject.name;
            TargetUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().fillAmount = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).GetComponent<PlayerManagerScripts>().Get_Target().transform.GetComponent<FirstBoss>().Get_HP() * 0.01f;


        }
    }
}
