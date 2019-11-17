using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    string oldscene = null;
    private int state = 0;
    private Vector3 oldposition;
    bool First = false;
    bool Second = false;
    bool Third = false;
    // Start is called before the first frame update


    public void set_state()
    {
        state++;
    }

    public int get_state()
    {
        return state;
    }
    public void Set_OldScene(string _in)
    {
        if (_in == "CampScene")
            oldscene = null;
        else
            oldscene = _in;
    }

    public string Get_OldScene()
    {

        return oldscene;
    }

    public void Init_ClearInfo()
    {
        First = false;
        Second = false;
        Third = false;
    }

    public void Set_ClearInfo(int _num)
    {
        switch(_num)
        {
            case 1:
                First = true;
                break;

            case 2:
                Second = true;
                break;

            case 3:
                Third = true;
                break;
        }
    }

    public bool Get_FirstClearInfo()
    {
        return First;
    }

    public bool Get_SecondClearInfo()
    {
        return Second;
    }

    public bool Get_ThirdClearInf()
    {
        return Third;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
