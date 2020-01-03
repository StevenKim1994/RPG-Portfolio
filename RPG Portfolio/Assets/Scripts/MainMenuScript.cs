// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] Btn = new GameObject[3];
    // 0:System 1:ChacracterInfo 2:Inventory

    public void OnSystemMenu()
    {
        if (Btn[0].activeSelf == false)
            Btn[0].SetActive(true);

        else
            Btn[0].SetActive(false);
    }

    public void OnCharacterInfoMenu()
    {
        if(Btn[1].activeSelf == false)
            Btn[1].SetActive(true);

        else
            Btn[1].SetActive(false);
    }

    public void OnInventoryMenu()
    {
        if(Btn[2].activeSelf == false)
            Btn[2].SetActive(true);

        else
            Btn[2].SetActive(false);
    }
}
