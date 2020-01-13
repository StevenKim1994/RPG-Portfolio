// Author : Steven Kim (Kim Siyon 김시윤)
// E-mail : dev@donga.ac.kr
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondBoss : MonoBehaviour
{
    [SerializeField] private float hP;
    [SerializeField] private float mP;
    [SerializeField] private GameObject HitParticle;
    [SerializeField] private GameObject floatingtext;
    [SerializeField] private GameObject floatingcanvas;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Transform target; // 유저의 좌표 값이 타겟이 됨...
    [SerializeField] public Animator anim;
    [SerializeField] private GameObject Skill1Range; // 스킬1 사용시 나올 BoxCollider
    [SerializeField] GameObject Dropbox;

    ManagerSingleton MGR = new ManagerSingleton();
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...
    bool cocheck = false;
    Vector3 original_position;
    int state;
    bool die = false;
    void Start()
    {
        anim = this.gameObject.transform.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = this.gameObject.transform.GetComponent<NavMeshAgent>();
        state = 0;
        hP = 100f;
        mP = 10000f;

        original_position = this.gameObject.transform.position;

        if (this.gameObject.transform.name != "SecondBoss")
            hP = 20f;

    }

    // Update is called once per frame
    void Update()
    {
        if (hP <= 0)
        {
            anim.SetBool("Stand", false);
            anim.SetBool("Runing", false);
            if (die == false)
            {
                die = true;
                StartCoroutine(Dead());
                if(this.gameObject.transform.name == "SecondBoss")
                    Instantiate(Dropbox, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 10f, this.gameObject.transform.position.z), Quaternion.identity); // 아이템박드드랍
            }
        }

        if (die == false) // 살아있으면
        {
            if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 30f)
            {
                this.gameObject.transform.LookAt(target.transform);

                
                    nav.enabled = true;
                    nav.SetDestination(target.transform.position); // 플레이어의 위치로 nav의 목적지를 지정함.
                   

                    anim.SetBool("Running", true);
                    anim.SetBool("Stand", false);
                

                if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 10f) // 보스와 플레이어의 거리가 일정 거리이면
                {

                    nav.enabled = false;
                    anim.SetBool("Running",false);
                    anim.SetBool("Stand", true);
                    anim.SetTrigger("Skill1");

                }

                else
                {
                    anim.SetBool("Stand", false);
                    anim.SetBool("Running", true);
                    nav.enabled = true;

                }
            }
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

    IEnumerator Skill1Attack()
    {
        GameObject temp = Instantiate(Skill1Range, this.gameObject.transform); // 스킬1 콜라이더 생성

        yield return new WaitForSeconds(2.65f);
        cocheck = false;
        Destroy(temp);
        yield break;

    }
    private void OnTriggerEnter(Collider col) // 여기 계속 수정해야함 19.11.14;
    {

        if(col.gameObject.tag == "Damage_Obstacle")
        {
            StartCoroutine(ObstacleEvent());
            StartCoroutine(ObstacleDamage());
        }

        if(col.gameObject.tag == "User_Bullet")
        {

            Instantiate(HitParticle, this.gameObject.transform);

            anim.SetTrigger("Hurt");
            Set_HP(Get_HP() - 5f);
            GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
            txtclone.GetComponent<FloatingText>().text.text = "-5";
            txtclone.transform.SetParent(GameObject.Find("UI").transform);
            Destroy(col.gameObject);
            Instantiate(HitParticle, this.gameObject.transform);


        }

    }
    private void OnMouseDown()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_Target(this.gameObject);


    }

    IEnumerator ObstacleEvent()
    {

        this.gameObject.transform.GetComponent<NavMeshAgent>().speed = 7f;
        yield return new WaitForSeconds(3f);
        this.gameObject.transform.GetComponent<NavMeshAgent>().speed = 10f;

        yield break;
    }

    IEnumerator ObstacleDamage()
    {

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i.ToString());
            this.Set_HP(this.Get_HP() - 7f);
            GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
            txtclone.GetComponent<FloatingText>().text.text = "-7";
            txtclone.transform.SetParent(GameObject.Find("UI").transform);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("지속피해종료!");

    }

    private void OnMouseOver()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().AttackCursor();
    }

    private void OnMouseExit()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().DefaultCursor();
    }

    IEnumerator Dead()
    {
        die = true;
        anim.SetTrigger("Dead");

        yield return new WaitForSeconds(7f);

        Destroy(this.gameObject);

        yield break;
    }

    public void MeleeAttack()
    {
        Debug.Log("공격공격");
        float Target_HP = MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP();

        if (target != null)
        {
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(Target_HP - 5f);
            //Instantiate(PlayerHitEffect, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation); // 타격 피이펙트 생성...
            target.GetComponent<Animator>().SetTrigger("Attacked");
            MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Save_HP(MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Load_HP() - 5);

        }
    }
}


