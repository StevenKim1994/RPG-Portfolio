using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenItemUse : MonoBehaviour
{
    // Start is called before the first frame update
    public void UseItem()
    {
        ManagerSingleton MGR = new ManagerSingleton();
        int num = int.Parse(this.gameObject.name);

        switch (num)
        {
            case 0:
                Debug.Log("1번 칸 아이템");
                if(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(0) == null)
                {
                    Debug.Log("1칸 비어있음");
                }
                break;

            case 1:
                Debug.Log("2번 칸 아이템");
                break;

            case 2:
                Debug.Log("3번 칸 아이템");
                break;

            case 3:
                Debug.Log("4번 칸 아이템");
                break;

            case 4:
                Debug.Log("5번칸 아이템");
                break;

            case 5:
                Debug.Log("6번칸 아이템");
                break;


        }

    }
}
