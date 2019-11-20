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
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject Skill1Range; // 스킬1 사용시 나올 BoxCollider
    ManagerSingleton MGR = new ManagerSingleton();
    int count = 0; // 근처에 플레이어가 머물러 있는 시간...
    bool cocheck = false;
    Vector3 original_position;
    int state;
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


        if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= 9f) // 보스와 플레이어의 거리가 일정 거리이면
        {
            Debug.Log("가까움");


            nav.enabled = true;
             anim.SetTrigger("Skill1");

            if (cocheck == false)
            {
                cocheck = true;
                StartCoroutine(Skill1Attack()); // 공격 범위 생성 코루틴 .. ( 범위 콜라이더 생성 1초후 Destroy )
            }



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
        if (col.gameObject.tag == "User_Weapon")
        {

            if (col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk01") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk02") || col.gameObject.transform.root.GetComponent<Player>().get_state().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.atk03"))
            {
                Instantiate(HitParticle, this.gameObject.transform);
                //anim.SetTrigger("Hurt");
                Set_HP(Get_HP() - 10f);
                Debug.Log(Get_HP());
                GameObject txtclone = Instantiate(floatingtext, Camera.main.WorldToScreenPoint(this.gameObject.transform.position), Quaternion.Euler(Vector3.zero));
                txtclone.GetComponent<FloatingText>().text.text = "-10";
                txtclone.transform.SetParent(GameObject.Find("UI").transform);
            }
        }

        if(col.gameObject.tag == "Damage_Obstacle")
        {
            StartCoroutine(ObstacleEvent());
            StartCoroutine(ObstacleDamage());
        }
    }
    private void OnMouseDown()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Player).transform.GetComponent<PlayerManagerScripts>().Set_Target(this.gameObject);


    }

    IEnumerator ObstacleEvent()
    {
        Debug.Log("장애물 이벤트발생!!");
        this.gameObject.transform.GetComponent<NavMeshAgent>().speed = 7f;
        yield return new WaitForSeconds(3f);
        this.gameObject.transform.GetComponent<NavMeshAgent>().speed = 10f;
        Debug.Log("장애물 이벤트종료!!");
        yield break;
    }

    IEnumerator ObstacleDamage()
    {
        Debug.Log("지속피해!!");
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
        yield break;
    }

    private void OnMouseOver()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().AttackCursor();
    }

    private void OnMouseExit()
    {
        MGR.Get_instance().transform.GetChild((int)Enum.Managerlist.Interface).transform.GetComponent<InterfaceManagerScript>().DefaultCursor();
    }
}


