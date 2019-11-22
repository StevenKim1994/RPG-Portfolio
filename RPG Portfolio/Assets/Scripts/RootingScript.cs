using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RootingScript : MonoBehaviour
{
    [SerializeField] Sprite[] Dropitemicon = new Sprite[3]; // 0 : First 1: Second 2: Third
    [SerializeField] GameObject Icon;
    [SerializeField] Text Description;
    [SerializeField] Text Bossname;
    [SerializeField] Text Itemname;
    private List<Item> ItemList = new List<Item>();
    ManagerSingleton MGR = new ManagerSingleton();

    public void SetItem()
    {
        if(SceneManager.GetActiveScene().name == "FirstDungeonScene")
        {
            List<Dictionary<string, object>> data = CSVReaderScript.Read("FirstBossItem_table");
            Bossname.text = "FirstBoss";
            Icon.transform.GetComponent<Image>().sprite = Dropitemicon[0];
            Itemname.text = data[0]["Name"].ToString();
            Description.text = "가치: " + data[0]["Value"].ToString() + "    " + "종류: " + data[0]["Kind"].ToString() + "\n" + data[0]["Description"].ToString();


        }

        else if(SceneManager.GetActiveScene().name =="SecondDungeonScene")
        {
            List<Dictionary<string, object>> data = CSVReaderScript.Read("SecondBossItem_table");
            Bossname.text = "SecondBoss";
            Icon.transform.GetComponent<Image>().sprite = Dropitemicon[1];
            Itemname.text = data[0]["Name"].ToString();
            Description.text = "가치: " + data[0]["Value"].ToString() + "    " + "종류: " + data[0]["Kind"].ToString() + "\n" + data[0]["Description"].ToString();
        }

        else if(SceneManager.GetActiveScene().name == "ThirdDungeonScene")
        {
            List<Dictionary<string, object>> data = CSVReaderScript.Read("ThirdBossItem_table");
            Bossname.text = "ThirdBoss";
            Icon.transform.GetComponent<Image>().sprite = Dropitemicon[2];
            Itemname.text = data[0]["Name"].ToString();
            Description.text = "가치: " + data[0]["Value"].ToString() + "    " + "종류: " + data[0]["Kind"].ToString() + "\n" + data[0]["Description"].ToString();
        }
    }

    public void ExtBtn()
    {
        gameObject.SetActive(false);
    }

    public void Rooting()
    {





        this.gameObject.SetActive(false);
        // 상자 파괴하기
    }
}
