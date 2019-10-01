using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DragonBoss : MonoBehaviour
{

    [SerializeField] float hP;
    [SerializeField] float mP;
    private int state; // 보스의 현재 상태 0 이면 초기 페이지 1이면 화남 페이지 2면 광폭화 페이지... 
    
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Transform target; // 유저의 좌표 값이 타겟이 됨...
    [SerializeField] private Animator anim;
    Vector3 original_position;
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...

    // Start is called before the first frame update
    void Start()
    {
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
        if (hP <= hP / 2)
            state = 1;

        if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 10f)
        {
            nav.enabled = true;
            Debug.Log("가까움");
            this.transform.LookAt(target);
            count++;

            if (count >= 5) // 만약 머물러있는 시간이 5초 이상이면 
            {
                nav.SetDestination(target.transform.position); // 따라가기...
            }

        }
        else
        {
            count = 0; // 거리가 멀어지면 시간은 0으로 초기화시킨다.
            nav.SetDestination(original_position); // 다시 원래 위치로 돌아간다.


        }
    }

    public void Set_HP(float _in)
    {
        hP = _in;
    }

    public float Get_HP()
    {
        return hP;
    }

    public void Set_MP(float _in)
    {
        mP = _in;
    }

    public float Get_MP()
    {
        return mP;
    }

    public void Skill1()
    {

    }

    public void Skill2()
    {

    }

    public void Skill3()
    {

    }
}
