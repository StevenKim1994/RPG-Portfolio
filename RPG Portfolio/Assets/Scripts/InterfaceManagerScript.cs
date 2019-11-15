using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManagerScript : MonoBehaviour
{
    [SerializeField]
    GameObject NoGOLD;
    [SerializeField]
    Sprite[] UnitPortaitImage = new Sprite[3];
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject UnitPortrait;
    [SerializeField] private GameObject EnermyPortrait;
    [SerializeField]
    GameObject FloatingTXT;
    public GameObject[] InterfaceButton = new GameObject[12]; // 12개의 중간 인터페이스 바의 각각의 버튼을 의미함.
    ManagerSingleton MGR = new ManagerSingleton();

    public void HPPoSet()
    {
        InterfaceButton[10].transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_HPPo().ToString();
    }

    public void MPPoSet()
    {
        InterfaceButton[11].transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_MPPo().ToString();
    }

  
}
