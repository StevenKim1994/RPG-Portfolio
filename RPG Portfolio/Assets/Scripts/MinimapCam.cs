using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCam : MonoBehaviour
{

    void Update()
    {
        Vector3 temp = GameObject.FindGameObjectWithTag("Player").transform.position;
        temp.y += 10f;
        this.gameObject.transform.position = temp;
    }
}
