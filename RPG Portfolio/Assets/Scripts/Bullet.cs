// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float MoveSpeed;

    ManagerSingleton MGR = new ManagerSingleton();
    void Start()
    {
        target = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Get_Target().transform;
        RotationSpeed = 5f;
        MoveSpeed = 5f;

    }


    void Update()
    {
        if (target == null)
            Destroy(this.gameObject);

        Vector3 dir = target.position - this.transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        Quaternion sl = Quaternion.Slerp(this.transform.rotation, rot, RotationSpeed * Time.deltaTime);
        this.transform.rotation = sl;

        this.transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime);
    }



}
