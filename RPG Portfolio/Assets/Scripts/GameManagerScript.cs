using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    string oldscene = null;
    private int state = 0;
    private Vector3 oldposition;

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

    
}
