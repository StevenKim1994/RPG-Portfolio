using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator Anim;

    public float MoveSpeed;
    public float RotSpeed;
    bool MoveFlag = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCtrl();
        RotCtrl();
    }
    void MoveCtrl()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("Input W");
            MoveFlag = true;
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        else
        {
            MoveFlag = false;
        }
    }

    void RotCtrl()
    {
        if(Input.GetMouseButton(1))
        {
            float RotX = Input.GetAxis("Mouse Y") * RotSpeed;
            float RotY = Input.GetAxis("Mouse X") * RotSpeed;

            this.transform.localRotation *= Quaternion.Euler(0, RotY, 0);
        }
    }
}
