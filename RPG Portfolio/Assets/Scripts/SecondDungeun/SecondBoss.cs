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
        this.gameObject.transform.LookAt(target.transform);
        nav.SetDestination(target.transform.position); // 플레이어의 위치로 nav의 목적지를 지정함.
    
       
        anim.SetBool("Running", true);
        nav.enabled = true;

        if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 15f) // 보스와 플레이어의 거리가 일정 거리이면
        {
            Debug.Log("가까움");
          
            
             nav.enabled = false;
             anim.SetTrigger("Skill1");
                
                 
            

        }
        
        else
        {
            
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Damage_Obstacle") // 만약 충돌한 대상이 장애물이라면!
        {
            // 지속 데미지 및 이동속도 느리게 하는 부분
        }
    }

}
