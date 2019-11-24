// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public float FadeTime = 2f;
    Image fadeIMG;
    float start = 1f;
    float end = 0f;
    float time = 0f;
    bool isPlaying = false;

    private void Awake()
    {
        fadeIMG = GetComponent<Image>();

    }
    // Start is called before the first frame update


    // Update is called once per frame
    private void Start()
    {
        InStartFadeAnim();
    }
    public void InStartFadeAnim()
    {
        if (isPlaying == true)
        {
            return;
        }

        StartCoroutine(fadein());
    }
    IEnumerator fadein()
    {
        isPlaying = true;

        Color fadecolor = fadeIMG.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);

        while (fadecolor.a > 0f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeIMG.color = fadecolor;

            yield return null;
        }
        isPlaying = false;
        Destroy(this.gameObject);
    }
}
