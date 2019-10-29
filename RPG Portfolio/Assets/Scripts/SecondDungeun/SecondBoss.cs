using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondBoss : MonoBehaviour
{
    [SerializeField] private float hP;
    [SerializeField] private float mP;
    private int state;

    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Transform target; // 유저의 좌표 값이 타겟이 됨...
    [SerializeField] private Animator anim;
    Vector3 original_position;
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...

    void Start()
    {
        anim = this.gameObject.transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = this.gameObject.transform.GetComponent<NavMeshAgent>();
        state = 0;
        hP = 10000f;
        mP = 10000f;

        original_position = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
