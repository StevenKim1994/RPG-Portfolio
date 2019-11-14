using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
using UnityEngine;


public class SaveData
{
    public string Name;
    public string Job;
    public string Armor;
    public string Damage;
    public string HP;
    public string MP;
    public string STR;
    public string DEX;
    public string INT;

    public SaveData(string _name, string _job , string _armor,string _damage, string _hp, string _mp, string _str, string _dex, string _int)
    {
        this.Name = _name;
        this.Job = _job;
        this.Armor = _armor;
        this.Damage = _damage;
        this.HP = _hp;
        this.MP = _mp;
        this.STR = _str;
        this.DEX = _dex;
        this.INT = _int;
    }
}
public class JSONManagerScript : MonoBehaviour
{
    public List<SaveData> SaveDataList = new List<SaveData>();
    ManagerSingleton MGR = new ManagerSingleton();

    public void SetData(string _name, string _job, string _armor, string _damage, string _hp, string _mp, string _str, string _dex, string _int)
    {
        SaveData temp;
        SaveDataList.Add(new SaveData(_name, _job, _armor, _damage, _hp, _mp, _str, _dex, _int));

    }
   
    public void Save()
    {
        string[] data = new string[9];
        Debug.Log("toSave");

        data[0] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Name();
        data[1] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Job();
        data[2] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Armor().ToString();
        data[3] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_Damage().ToString();
        data[4] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP().ToString();
        data[5] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_MP().ToString();
        data[6] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_STR().ToString();
        data[7] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_DEX().ToString();
        data[8] = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_INT().ToString();
       
        SetData(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
        JsonData SaveJson = JsonMapper.ToJson(SaveDataList);
 
        File.WriteAllText(Application.dataPath + "/Resources/PlayerData.json",SaveJson.ToString());
        Debug.Log("Success");

        MGR.Get_instance().gameObject.transform.GetChild((int)Enum.Managerlist.Game).transform.GetComponent<GameManagerScript>().QuitGame(); // 게임종료
    }

    public void Load()
    {
        Debug.Log("toLoad");

        string Jsonstring = File.ReadAllText(Application.dataPath + "/Resources/PlayerData.json");

        Debug.Log(Jsonstring);

        JsonData PlayerData = JsonMapper.ToObject(Jsonstring);

        for(int i= 0; i < PlayerData.Count; i++)
        {
            Debug.Log(PlayerData[i]["Name"].ToString());
            Debug.Log(PlayerData[i]["Job"].ToString());
        }
    }
}
