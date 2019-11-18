using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossItemBoxScript : MonoBehaviour
{
    [SerializeField] GameObject ItemCanvas;
    void Start()
    {
        ItemCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        ItemCanvas.SetActive(true);
    }

    public void Exitbtn()
    {
        ItemCanvas.SetActive(false);
    }
}
