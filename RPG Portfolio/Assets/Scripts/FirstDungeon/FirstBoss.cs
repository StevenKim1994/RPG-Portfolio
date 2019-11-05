using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FirstBoss : MonoBehaviour
{

    [SerializeField] float hP;
    [SerializeField] float mP;
    [SerializeField] float damage;

    private int state; // 보스의 현재 상태 0 이면 초기 페이지 1이면 화남 페이지 2면 광폭화 페이지... 
    
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Transform target; // 유저의 좌표 값이 타겟이 됨...
    [SerializeField] private Animator anim;
    Vector3 original_position;
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...
    
    ManagerSingleton MGR = new ManagerSingleton();
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = this.gameObject.transform.GetComponent<NavMeshAgent>();
        state = 0;
      

        original_position = this.gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (hP <= 0)
        {
            //사망 이펙트 화염 분출 ... 추가하기
            Destroy(this.gameObject);
        }
       /* // Debug.Log(Vector3.Distance(this.gameObject.transform.position, target.transform.position).ToString());
        if (hP <= hP / 2)
        {
            state = 1; // 화남페이지
            damage += 20f; // 화가 나면 데미지 20상승

        }

        if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 10f)
        {
            nav.enabled = true;
            Debug.Log("가까움");
            this.transform.LookAt(target);
            count++;


            anim.SetBool("Running", true);
            nav.SetDestination(target.transform.position); // 따라가기...
            
            if(Vector3.Distance(this.gameObject.transform.position, target.transform.position) <6f)
            {
                nav.enabled = false;
                
                // 공격 트리거가 실행될때는 이게 호출이 되면 안됨.
                anim.SetTrigger("Skill1");
            }

            else
            {
                // 거리가 멀어지면 트리거종료...
            }

            

        }
        else
        {
            count = 0; // 거리가 멀어지면 시간은 0으로 초기화시킨다.
            nav.SetDestination(original_position); // 다시 원래 위치로 돌아간다.
            if ((Vector3.Distance(this.gameObject.transform.position, original_position) < 3f)) // 다시 원래 위치이면??...
            {
                Debug.Log("아이들상태로");
                anim.SetBool("Running", false);
            }

        }
        */  // 19.11.05  현시점 수정...
       
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

    private void OnMouseDown() // 마우스 클릭시 대상의 초상화 정보 이 보스로 변경...
    {
        Debug.Log("보스 마우스클릭됨");
        // 이때 Delegate로 InterfaceManager 내에 있는 TargetFrame 설정 세팅하기 19.10.30...
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "User_Weapon")
        {
            Debug.Log("타격타격!");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "User_Weapon")
        {
            Debug.Log("타격타격@");
            anim.SetTrigger("Hurt");
            Set_HP(Get_HP() - 10f);
            Debug.Log(Get_HP());
        }
    }

}
