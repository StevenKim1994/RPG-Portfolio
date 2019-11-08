using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Fireball : MonoBehaviour
{
  
    [SerializeField] private Transform target;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float MoveSpeed;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        RotationSpeed = 5f;
        MoveSpeed = 5f;
        
    }

  
    void Update()
    {
        
        Vector3 dir = target.position - this.transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        Quaternion sl = Quaternion.Slerp(this.transform.rotation, rot, RotationSpeed *Time.deltaTime);
        this.transform.rotation = sl;

        this.transform.Translate(new Vector3(0,0,1) * MoveSpeed * Time.deltaTime);
    }

  

}
