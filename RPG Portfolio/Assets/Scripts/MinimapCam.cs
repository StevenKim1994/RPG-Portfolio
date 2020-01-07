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
        // 이전 Player위치 Scene 바꿀때 마다 Delegate로 설정하는 거 추가하기.
        this.gameObject.transform.position = PlayerPosition.gameObject.transform.position;
        this.gameObject.transform.position += distance;

    }

    
}
