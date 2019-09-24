using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Inventory : MonoBehaviour
{
    float distance = 10f;
    public void OnMouseDrag()
    {
        Debug.Log("Draging");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.gameObject.transform.position = objPosition;
    }


}
