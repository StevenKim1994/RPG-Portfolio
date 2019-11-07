using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] MenuBtn = new GameObject[3]; // 0 : System 1 : Skill  2: Inventory(이것은 예외로 InventoryManager에서 관리함
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSystemMenu()
    {
        MenuBtn[0].SetActive(true);

        
    }
}
