// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;
    Text timebox;  
    // Start is called before the first frame update
    void Start()
    {
        timebox = this.gameObject.transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            timebox.text = System.DateTime.Now.ToString("HH:m:s tt zzz");
        }
    }
}
