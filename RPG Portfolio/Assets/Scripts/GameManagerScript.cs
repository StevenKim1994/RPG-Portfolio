using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    string oldscene = null;

    private Vector3 oldposition;

    // Start is called before the first frame update

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

    public void Set_OldPosition(Vector3 _in)
    { 
        oldposition = _in;
    }

    public Vector3 Get_OldPosition()
    {
        return oldposition;
    }
    
}
