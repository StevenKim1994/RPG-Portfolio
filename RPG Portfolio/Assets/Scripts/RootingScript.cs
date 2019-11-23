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
    Item First;
    Item Second;
    Item Third;

    public void SetItem()
    {
        if(SceneManager.GetActiveScene().name == "FirstDungeonScene")
        {
            List<Dictionary<string, object>> data = CSVReaderScript.Read("FirstBossItem_table");
            Bossname.text = "FirstBoss";
            Icon.transform.GetComponent<Image>().sprite = Dropitemicon[0];
            Itemname.text = data[0]["Name"].ToString();
            Description.text = "가치: " + data[0]["Value"].ToString() + "    " + "종류: " + data[0]["Kind"].ToString() + "\n" + data[0]["Description"].ToString();
            First = new Item(Dropitemicon[0], false, int.Parse(data[0]["Kind"].ToString()), data[0]["Name"].ToString(), int.Parse(data[0]["Value"].ToString()), 0f, 0f, 0f, 0, data[0]["Description"].ToString());

        }

        else if(SceneManager.GetActiveScene().name =="SecondDungeonScene")
        {
            List<Dictionary<string, object>> data = CSVReaderScript.Read("SecondBossItem_table");
            Bossname.text = "SecondBoss";
            Icon.transform.GetComponent<Image>().sprite = Dropitemicon[1];
            Itemname.text = data[0]["Name"].ToString();
            Description.text = "가치: " + data[0]["Value"].ToString() + "    " + "종류: " + data[0]["Kind"].ToString() + "\n" + data[0]["Description"].ToString();
            Second = new Item(Dropitemicon[1], false, int.Parse(data[0]["Kind"].ToString()), data[0]["Name"].ToString(), int.Parse(data[0]["Value"].ToString()), 0f, 0f, 0f, 0, data[0]["Description"].ToString());

        }

        else if(SceneManager.GetActiveScene().name == "ThirdDungeonScene")
        {
            List<Dictionary<string, object>> data = CSVReaderScript.Read("ThirdBossItem_table");
            Bossname.text = "ThirdBoss";
            Icon.transform.GetComponent<Image>().sprite = Dropitemicon[2];
            Itemname.text = data[0]["Name"].ToString();
            Description.text = "가치: " + data[0]["Value"].ToString() + "    " + "종류: " + data[0]["Kind"].ToString() + "\n" + data[0]["Description"].ToString();
            Third = new Item(Dropitemicon[2], false, int.Parse(data[0]["Kind"].ToString()), data[0]["Name"].ToString(), int.Parse(data[0]["Value"].ToString()), 0f, 0f, 0f, 0, data[0]["Description"].ToString());

        }
    }

    public void ExtBtn()
    {
        gameObject.SetActive(false);
    }

    public void Rooting()
    {
        if (SceneManager.GetActiveScene().name == "FirstDungeonScene")
            MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Set_Block(First);

        else if (SceneManager.GetActiveScene().name == "SecondDungeonScene")
            MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Set_Block(Second);

        else if(SceneManager.GetActiveScene().name == "ThirdDungeonScene")
            MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Set_Block(Third);

        Destroy(GameObject.Find("FirstBossItemBox(Clone)"));
        this.gameObject.SetActive(false);
        // 상자 파괴하기
    }
}
