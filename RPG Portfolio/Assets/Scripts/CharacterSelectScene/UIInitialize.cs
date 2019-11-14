using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInitialize : MonoBehaviour
{
    [SerializeField]
    GameObject UI;

    int UIcount;
    // Start is called before the first frame update
    void Start()
    {
        UIcount = UI.gameObject.transform.childCount;
        UISetOff();
     }


    public void UISetOff()
    {
            for (int i = 0; i < UIcount; i++)
                UI.gameObject.transform.GetChild(i).gameObject.SetActive(false);
     }

    public void UISetOn()
    {
        for (int i = 0; i < UIcount; i++)
        {
            if(UI.gameObject.transform.GetChild(i).gameObject.name.ToString() == "Bank")
            {
                continue;
            }
            if(UI.gameObject.transform.GetChild(i).gameObject.name.ToString() == "Tooltip")
            {
                continue;
            }
            if (UI.gameObject.transform.GetChild(i).gameObject.name.ToString() == "Inventory")
            {
                continue;
            }
            else if (UI.gameObject.transform.GetChild(i).gameObject.name.ToString() == "Root")
            {
                continue;
            }
            else if(UI.gameObject.transform.GetChild(i).gameObject.name.ToString() == "System")
            {
                continue;
            }
            else if(UI.gameObject.transform.GetChild(i).gameObject.name.ToString() == "CharacterInfo")
            {
                continue;
            }
            else
            {
                UI.gameObject.transform.GetChild(i).gameObject.SetActive(true);


            }
        }
    }
}