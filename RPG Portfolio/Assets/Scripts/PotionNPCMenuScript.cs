using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionNPCMenuScript : MonoBehaviour
{
    GameObject Player;
    GameObject[] Managers = new GameObject[10];

    void Awake()
    {
        Managers[0] = GameObject.Find("SceneManager");
        Managers[1] = GameObject.Find("InventoryManager");
        Managers[2] = GameObject.Find("DataManager");
        Managers[3] = GameObject.Find("PlayerManager");
        Managers[4] = GameObject.Find("InterfaceManager");
        Managers[5] = GameObject.Find("SkillManager");
        Managers[6] = GameObject.Find("GameManager");
    }
    void Start()
    {
        Player=  GameObject.Find("Player(" + Managers[3].GetComponent<PlayerManagerScripts>().Load_Job() +")(Clone)");
        this.gameObject.SetActive(false);
    }
    public void SellMPPotion()
    {

    }
    
    public void SellHPPotion()
    {

    }

    public void BuyMPPotion()
    {

    }

    public void BuyHPPotion()
    {

    }

    public void ExitBtn()
    {
        this.gameObject.SetActive(false);
    }
}
