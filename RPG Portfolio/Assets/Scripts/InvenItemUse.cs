using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InvenItemUse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] GameObject tooltipUI;
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
                    Debug.Log("비어있음");
                }
                else
                {
                    switch (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(0).kind)
                    {
                        case 1:
                            Debug.Log("방어구");
                            Debug.Log(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(0).description.ToString());
                            break;

                        case 2:
                            Debug.Log("무기류");
                            break;

                    }
                    Debug.Log("아이템명: "+ MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(0).name.ToString());
                    Debug.Log("가치 : " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(0).value.ToString());
                }
                break;

            case 1:
                Debug.Log("2번 칸 아이템");
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(1) == null)
                {
                    Debug.Log("비어있음");
                }
                else
                {
                    switch (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(1).kind)
                    {
                        case 1:
                            Debug.Log("방어구");
                            Debug.Log(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(1).description.ToString());
                            break;

                        case 2:
                            Debug.Log("무기류");
                            break;

                    }
                    Debug.Log("아이템명: " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(1).name.ToString());
                    Debug.Log("가치 : " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(1).value.ToString());
                }
                break;

            case 2:
                Debug.Log("3번 칸 아이템");
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(2) == null)
                {
                    Debug.Log("비어있음");
                }
                else
                {
                    switch (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(2).kind)
                    {
                        case 1:
                            Debug.Log("방어구");
                            Debug.Log(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(2).description.ToString());
                            break;

                        case 2:
                            Debug.Log("무기류");
                            break;

                    }
                    Debug.Log("아이템명: " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(2).name.ToString());
                    Debug.Log("가치 : " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(2).value.ToString());
                }
                break;

            case 3:
                Debug.Log("4번 칸 아이템");

                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(3) == null)
                {
                    Debug.Log("비어있음");
                }
                else
                {
                    switch (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(3).kind)
                    {
                        case 1:
                            Debug.Log("방어구");
                            Debug.Log(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(3).description.ToString());
                            break;

                        case 2:
                            Debug.Log("무기류");
                            break;

                    }
                    Debug.Log("아이템명: " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(3).name.ToString());
                    Debug.Log("가치 : " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(3).value.ToString());
                }

                break;

            case 4:
                Debug.Log("5번칸 아이템");
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(4) == null)
                {
                    Debug.Log("비어있음");
                }
                else
                {
                    switch (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(4).kind)
                    {
                        case 1:
                            Debug.Log("방어구");
                            Debug.Log(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(4).description.ToString());
                            break;

                        case 2:
                            Debug.Log("무기류");
                            break;

                    }
                    Debug.Log("아이템명: " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(4).name.ToString());
                    Debug.Log("가치 : " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(4).value.ToString());
                }

                break;

            case 5:
                Debug.Log("6번칸 아이템");
                if (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(5) == null)
                {
                    Debug.Log("비어있음");
                }
                else
                {
                    switch (MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(5).kind)
                    {
                        case 1:
                            Debug.Log("방어구");
                            Debug.Log(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(5).description.ToString());
                            break;

                        case 2:
                            Debug.Log("무기류");
                            break;

                    }
                    Debug.Log("아이템명: " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(5).name.ToString());
                    Debug.Log("가치 : " + MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Inventory).transform.GetComponent<InventoryManagerScript>().GetInven().transform.GetComponent<Inventory>().Get_Block(5).value.ToString());
                }

                break;


        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("마우스오버!");
        tooltipUI.SetActive(true);
        tooltipUI.transform.GetChild(0).transform.GetComponent<Text>().text = "마우스오버!!";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipUI.SetActive(false);
    }

}
