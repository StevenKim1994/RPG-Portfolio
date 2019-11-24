// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponNPCMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject itemblock_prefeb;
    [SerializeField] private GameObject itemblock;
    [SerializeField] private GameObject itemblock_parents;
    [SerializeField] GameObject[] Itemicon = new GameObject[3];
    private GameObject input_temp;
    private List<GameObject> itemlist = new List<GameObject>();


    void Start()
    {
        List<Dictionary<string, object>> data = CSVReaderScript.Read("weapon_table");

        for (var i = 0; i < data.Count; i++)
        {
            if(data[i]["Name"] != null)
            {
                Debug.Log("생성");
                input_temp = Instantiate(itemblock_prefeb,itemblock_parents.transform);
                input_temp.transform.GetChild(1).GetComponent<Text>().text = data[i]["Name"].ToString() + "\n 가치 :" + data[i]["Value"].ToString();
                input_temp.transform.GetChild(2).GetComponent<Text>().text = "공격력: " + data[i]["Damage"].ToString() + "\n" + "공격 속도: " + data[i]["Speed"].ToString();
                itemlist.Add(input_temp);
            }
        }

        this.gameObject.SetActive(false);
    }

    public void ExtBtn()
    {
        this.gameObject.SetActive(false);
    }


}
