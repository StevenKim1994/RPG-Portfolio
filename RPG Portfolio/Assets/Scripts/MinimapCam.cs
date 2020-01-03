// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{
    private GameObject PlayerPosition;
    private Vector3 distance;
    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").gameObject;
        distance.y = 10f;
    }
    void Update()
    {

        this.gameObject.transform.position = PlayerPosition.gameObject.transform.position;
        this.gameObject.transform.position += distance;

    }

    
}
