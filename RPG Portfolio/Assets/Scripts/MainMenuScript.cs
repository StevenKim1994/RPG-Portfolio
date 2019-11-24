// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] Btn = new GameObject[3];
    // 0:System 1:Skill 2:Inventory(이건 예외적으로 InventoryManager에서 관리)

    public void OnSystemMenu()
    {
        if (Btn[0].activeSelf == false)
            Btn[0].SetActive(true);

        else
            Btn[0].SetActive(false);
    }
}
