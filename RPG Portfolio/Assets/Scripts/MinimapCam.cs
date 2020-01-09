// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    private GameObject Player;
    Vector3 temp;
    Vector3 position;
 
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "CharacterSelectScene" && SceneManager.GetActiveScene().name != "LoadingScene")
        {

            if (temp.y == 0f && temp.x == 0f && temp.z ==0f || Player == null)
            {
                SetMinimapPosition();
            }
            else
            {
                this.gameObject.transform.position = GetPlayerPotision();
                
            }
        }
    }

    void SetMinimapPosition() 
    {
        if (SceneManager.GetActiveScene().name != "CharacterSelectScene" && SceneManager.GetActiveScene().name != "LoadingScene")
        {
            temp = GameObject.FindGameObjectWithTag("Player").transform.position;
            Player = GameObject.FindGameObjectWithTag("Player");
            temp.y = temp.y + 10f;
        }
    }

    Vector3 GetPlayerPotision()
    {

        position = Player.transform.position;
        position.y += 10f;
        return position;
    }
}
