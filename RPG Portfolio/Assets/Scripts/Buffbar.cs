using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buffbar : MonoBehaviour
{
    [SerializeField]
    Sprite[] BuffIcon = new Sprite[3];
    [SerializeField]
    GameObject[] Buff = new GameObject[5];
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Buff[i].SetActive(false);
        }
    }

    public void BuffOn(int num)
    {
        if(num == 1)
        {
            StartCoroutine(BuffStart(BuffIcon[0], 10f));
        }
        else if(num ==2)
        {
            StartCoroutine(BuffStart(BuffIcon[1], 10f));
        }
    }


    IEnumerator BuffStart(Sprite _image, float _time)
    {
        int temp = count;
        Buff[count].SetActive(true);
        Buff[count].gameObject.transform.GetComponent<Image>().sprite = _image;
        count++;
        yield return new WaitForSeconds(_time);
        Buff[temp].SetActive(false);
        count--;
        yield break;
    }
}
