// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderScript : MonoBehaviour
{
    delegate void EnterCamp();

    private EnterCamp e_c;

    // Start is called before the first frame update
    void Start()
    {
      e_c = new SceneManagerScript().EnterCamp;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            e_c();
    }
}
