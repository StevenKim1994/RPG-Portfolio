using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManagerScript : MonoBehaviour
{
    [SerializeField]
    Texture2D cursor_default;
    [SerializeField]
    Texture2D cursor_attack;
    [SerializeField]
    Texture2D cursor_use;
    [SerializeField]
    Texture2D cursor_rooting;

    CursorMode cursormode = CursorMode.ForceSoftware;
    Vector2 hotspot = Vector2.zero;
    [SerializeField]
    GameObject NoGOLD;
    [SerializeField]
    Sprite[] UnitPortaitImage = new Sprite[3];
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject UnitPortrait;
    [SerializeField] private GameObject EnermyPortrait;
    [SerializeField]
    GameObject FloatingTXT;
    public GameObject[] InterfaceButton = new GameObject[12]; // 12개의 중간 인터페이스 바의 각각의 버튼을 의미함.
    ManagerSingleton MGR = new ManagerSingleton();

    public void Start()
    {
        DefaultCursor();
    }
    public void HPPoSet()
    {
        InterfaceButton[10].transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_HPPo().ToString();
    }

    public void MPPoSet()
    {
        InterfaceButton[11].transform.GetChild(0).GetComponent<Text>().text = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_MPPo().ToString();
    }

    public void AttackCursor()
    {
        Cursor.SetCursor(cursor_attack, hotspot, cursormode);
    }

    public void UseCursor()
    {
        Cursor.SetCursor(cursor_use, hotspot, cursormode);
    }

    public void RootCursor()
    {
        Cursor.SetCursor(cursor_rooting, hotspot, cursormode);
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(cursor_default, hotspot, cursormode);
    }
}
