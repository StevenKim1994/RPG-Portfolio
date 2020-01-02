// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    Vector3 temp;
    private void Start()
    {
      
     
    }
    void Update()
    {
        
        this.gameObject.transform.position = temp;
    }

    void SetMinimapPosition() // 이거 딜리게이트로 Player 생성할때 호출하는거 추가하기!
    {
        if (SceneManager.GetActiveScene().name != "CharacterSelectScene")
        {
            temp = GameObject.FindGameObjectWithTag("Player").transform.position;

        }
    }
}
