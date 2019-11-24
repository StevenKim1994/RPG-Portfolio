// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitcanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hit;
    public void Start()
    {
        Instantiate(hit);
    }
}
