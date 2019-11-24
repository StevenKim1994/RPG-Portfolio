// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSelecterScript : MonoBehaviour
{
    [SerializeField]
    GameObject DungeonSelecter;
    
    public void ExitBtn()
    {

        DungeonSelecter.SetActive(false);
    }
}
