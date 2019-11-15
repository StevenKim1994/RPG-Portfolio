using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorNPCMenuScript : MonoBehaviour
{
    [SerializeField] private Sprite[] itemicon = new Sprite[3];
    [SerializeField] private GameObject itemblock_prefeb;
    [SerializeField] private GameObject itemblock;
    [SerializeField] private GameObject itemblock_parents;

    private GameObject input_temp;
    private List<GameObject> itemlist = new List<GameObject>();
    private List<Item> itemdata = new List<Item>();



    void Start()
    {
        List<Dictionary<string, object>> data = CSVReaderScript.Read("armor_table");

        for (var i = 0; i < data.Count; i++)
        {
            if (data[i]["Name"] != null)
            {

                input_temp = Instantiate(itemblock_prefeb, itemblock_parents.transform);
                input_temp.transform.GetChild(1).GetComponent<Text>().text = data[i]["Name"].ToString() + "\n 가치 :" + data[i]["Value"].ToString();
                input_temp.transform.GetChild(2).GetComponent<Text>().text = "방어력: " + data[i]["Defense"].ToString() + "\n" + "무게: " + data[i]["Weight"].ToString();

                if(data[i]["Name"].ToString() == "1단계 방어구")
                {
                    input_temp.transform.GetChild(0).GetComponent<Image>().sprite = itemicon[0];
                    input_temp.transform.GetComponent<Item>().image = itemicon[0];
                }
                else if(data[i]["Name"].ToString() == "2단계 방어구")
                {
                    input_temp.transform.GetChild(0).GetComponent<Image>().sprite = itemicon[1];
                    input_temp.transform.GetComponent<Item>().image = itemicon[1];
                }
                else if(data[i]["Name"].ToString() == "3단계 방어구")
                {
                    input_temp.transform.GetChild(0).GetComponent<Image>().sprite = itemicon[2];
                    input_temp.transform.GetComponent<Item>().image = itemicon[2];
                }


                input_temp.transform.GetComponent<Item>().name = data[i]["Name"].ToString();
                input_temp.transform.GetComponent<Item>().kind = 1;
                input_temp.transform.GetComponent<Item>().num = 1;
                input_temp.transform.GetComponent<Item>().armor = float.Parse(data[i]["Defense"].ToString());
                input_temp.transform.GetComponent<Item>().value = int.Parse(data[i]["Value"].ToString());

                itemlist.Add(input_temp);
            }
        }


    }

    public void ExtBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void BuyItem()
    {
        string tmp = this.gameObject.transform.GetChild(1).GetComponent<Text>().text;

        if (tmp == "1단계 방어구 가치: 5")
            Debug.Log("구입");

    }

}
