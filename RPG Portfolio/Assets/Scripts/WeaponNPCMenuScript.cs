using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponNPCMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject itemblock_prefeb;
    [SerializeField] private GameObject itemblock;
    [SerializeField] private GameObject itemblock_parents;

    private GameObject input_temp;
    private List<GameObject> itemlist = new List<GameObject>();


    void Start()
    {
        List<Dictionary<string, object>> data = CSVReaderScript.Read("weapon_table");
        
        if (data[0]["Name"] != null)
        {
            itemblock.SetActive(true);
            itemblock.transform.GetChild(1).GetComponent<Text>().text = data[0]["Name"].ToString() + "\n 가치 :" + data[0]["Value"].ToString();
            itemblock.transform.GetChild(2).GetComponent<Text>().text = "공격력: " + data[0]["Damage"].ToString() + "\n" + "공격 속도: " + data[0]["Speed"].ToString();
            itemlist.Add(itemblock);
        }

        else
            itemblock.SetActive(false);

        

        for (var i = 1; i < data.Count; i++)
        {          
            if(data[i]["Name"] != null)
            {
                Debug.Log("생성");
                input_temp = Instantiate(itemblock_prefeb,itemblock_parents.transform);
                input_temp.transform.GetComponent<RectTransform>().offsetMax = new Vector2(input_temp.transform.GetComponent<RectTransform>().offsetMax.x, (+141.5f)*i);
                input_temp.transform.GetComponent<RectTransform>().offsetMin = new Vector2(input_temp.transform.GetComponent<RectTransform>().offsetMin.x, (-141.5f)*i);
                input_temp.transform.GetChild(1).GetComponent<Text>().text = data[i]["Name"].ToString() + "\n 가치 :" + data[i]["Value"].ToString();
                input_temp.transform.GetChild(2).GetComponent<Text>().text = "공격력: " + data[i]["Damage"].ToString() + "\n" + "공격 속도: " + data[i]["Speed"].ToString();
                itemlist.Add(input_temp);

                // top += 141.5f;
                // bottom -= 141.f;
            }
        }

        
    }


    public void ExtBtn()
    {
     
        Debug.Log("!!!");
        this.gameObject.SetActive(false);
    }
}
