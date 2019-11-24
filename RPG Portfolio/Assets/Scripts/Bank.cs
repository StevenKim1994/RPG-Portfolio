// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [SerializeField] GameObject[] Slot = new GameObject[16]; // 왼쪽 상단부터 0 ... 오른쪽 하단이 15
    List<Item> itemlist = new List<Item>();
    int count = 0;


    public void Set_Block(Item _input)
    {
        if(count == 16)
        {
            Debug.Log("창고가 가득찼습니다");
        }
        itemlist.Add(_input);
        Slot[count].transform.GetComponent<Image>().sprite = _input.image;
        count++;
    }

    public void ItemUse(int _num)
    {
        switch (_num+1)
        {

            case 1:
                Debug.Log(itemlist[_num].name);
                break;

            case 2:
                Debug.Log(itemlist[_num].name);
                break;

            case 3:
                Debug.Log(itemlist[_num].name);
                break;

            case 4:
                Debug.Log(itemlist[_num].name);
                break;
            case 5:
                Debug.Log(itemlist[_num].name);
                break;
            case 6:
                Debug.Log(itemlist[_num].name);
                break;
            case 7:
                Debug.Log(itemlist[_num].name);
                break;
            case 8:
                Debug.Log(itemlist[_num].name);
                break;
            case 9:
                Debug.Log(itemlist[_num].name);
                break;

            case 10:
                Debug.Log(itemlist[_num].name);
                break;
            case 11:
                Debug.Log(itemlist[_num].name);
                break;

            case 12:
                Debug.Log(itemlist[_num].name);
                break;

            case 13:
                Debug.Log(itemlist[_num].name);
                break;

            case 14:
                Debug.Log(itemlist[_num].name);
                break;

            case 15:
                Debug.Log(itemlist[_num].name);
                break;

        }
    }

}
