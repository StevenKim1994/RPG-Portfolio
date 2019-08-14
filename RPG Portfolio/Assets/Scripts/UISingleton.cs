using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISingleton : MonoBehaviour
{
    private static UISingleton uiinstance = null;

    public UISingleton Get_Instance()
    {
        return uiinstance;
    }

    void Awake()
    {
        if (Get_Instance())
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        uiinstance = this;
    }
}
