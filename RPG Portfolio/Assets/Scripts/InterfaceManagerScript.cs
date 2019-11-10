using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Sprite[] UnitPortaitImage = new Sprite[3];
    public GameObject[] InterfaceButton = new GameObject[12]; // 12개의 중간 인터페이스 바의 각각의 버튼을 의미함.
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject UnitPortrait;
    [SerializeField] private GameObject EnermyPortrait;
    [SerializeField]
    GameObject SkillMgr;
    [SerializeField]
    GameObject InvenMgr;
    [SerializeField]
    GameObject FloatingTXT;

    void Start()
    {
        
    }


 

}
