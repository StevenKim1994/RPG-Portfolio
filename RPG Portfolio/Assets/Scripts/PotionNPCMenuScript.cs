using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionNPCMenuScript : MonoBehaviour
{
   [SerializeField] private GameObject itemblock_prefeb;
    [SerializeField] private GameObject itemblock;
    [SerializeField] private GameObject itemblock_parents;

    private GameObject input_temp;
    private List<GameObject> itemlist = new List<GameObject>();


    void Start()
    {
        List<Dictionary<string, object>> data = CSVReaderScript.Read("potion_table");
        
        for (var i = 0; i < data.Count; i++)
        {          
            if(data[i]["Name"] != null)
            {

                input_temp = Instantiate(itemblock_prefeb,itemblock_parents.transform);
                input_temp.transform.GetChild(1).GetComponent<Text>().text = data[i]["Name"].ToString() + "\n 가치 :" + data[i]["Value"].ToString();
                input_temp.transform.GetChild(2).GetComponent<Text>().text = "종류: " + data[i]["Kind"].ToString() + "\n" + "회복량: " + data[i]["Increase"].ToString();
                itemlist.Add(input_temp);    
            }
        }

    
    }

    public void ExtBtn()
    { 
        this.gameObject.SetActive(false);
    }

    
}
